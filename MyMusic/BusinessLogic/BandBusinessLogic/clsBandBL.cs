using DataAccess;
using DTO;
using Newtonsoft.Json;
using System;
using Utility;
using System.Collections.Generic;
using tweetupdater;

namespace BusinessLogic.BandBusinessLogic
{
    public class clsBandBL
    {
        clsFacadeDA FacadeDA = new clsFacadeDA();
        clsDeserializeJson DeserializeJson = new clsDeserializeJson();
        Serializer serializer = new Serializer();
        clsArchiveManager ArchiveManager = new clsArchiveManager();

        public string getForm()
        {
            clsForm form = new clsForm();
            clsResponse response = new clsResponse();
            form = FacadeDA.getAllGenres(form, ref response);
            form = FacadeDA.getAllLocations(form, ref response);
            response.Data = serializer.Serialize(form);
            System.Diagnostics.Debug.WriteLine(serializer.Serialize(response));
            return serializer.Serialize(response);

        }
        public string getBandInfo(int pintBandId)
        {
            clsInfoBand InfoBand = new clsInfoBand();
            clsResponse response = new clsResponse();

            FacadeDA.getBandInfo(ref InfoBand, ref response, pintBandId);
            FacadeDA.getGenresBand(ref InfoBand, ref response, pintBandId);
            FacadeDA.getMembersInfo(ref InfoBand, ref response, pintBandId);


            response.Data = serializer.Serialize(InfoBand);
            return serializer.Serialize(response);
        }
        public string getBandPublications(int pintUserId, int pintOffset, int pintLimit)
        {
            clsResponse response = new clsResponse();
            List<clsPublication> publications = FacadeDA.getWallBand(ref response, pintUserId, pintOffset, pintLimit);
            

            response.Data = serializer.Serialize(publications);
            return serializer.Serialize(response);
        }

        public string createBand(string pstringRequest)
        {

            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoBand InfoBand = DeserializeJson.DeserializeBandForm(request.Data.ToString());
            clsResponse response = new clsResponse();


            clsInfoUser InfoUser = new clsInfoUser();
            InfoUser.Username = InfoBand.Username;
            FacadeDA.validateUser(InfoUser, ref response);
            if (!response.Success)//not existing username
            {
                response = new clsResponse();//clear the response
                InfoBand.Salt = clsHasher.genSalt();
                InfoBand.SaltHashed = clsHasher.hashPassword(InfoBand.Password, InfoBand.Salt);
                InfoBand = FacadeDA.createBand(InfoBand, ref response);

                //save image here!
                ArchiveManager.saveUserImage(InfoBand.Id, InfoBand.Picture, ref response);
                InfoUser.Salt = null; // clear the object before sending
                InfoUser.SaltHashed = null; // clear the object before sending

            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Existing Username";
                response.Code = 3;
            }

            response.Data = serializer.Serialize(InfoBand);
            return serializer.Serialize(response);
        }

        public string checkHashtag(string pstringHashtag)
        {
            clsInfoBand InfoBand = new clsInfoBand();
            InfoBand.Hashtag = pstringHashtag;
            clsResponse response = new clsResponse();

            FacadeDA.validateHashTag(InfoBand, ref response);
            //Data = null
            return serializer.Serialize(response);

        }

        public string updateBand(string pstringRequest, int pintFanId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsInfoBand InfoBand = DeserializeJson.DeserializeBandForm(request.Data);
            InfoBand.Id = request.Id;
            clsResponse response = new clsResponse();

            if (InfoBand.Id == pintFanId)
            {
                InfoBand = FacadeDA.updateBand(InfoBand, ref response);
                if (InfoBand.Picture.CompareTo("") != 0) // change image 
                {
                    ArchiveManager.updateUserImage(InfoBand.Id, InfoBand.Picture, ref response);
                }
            }
            else
            {
                //error info
                response.Success = false;
                response.Message = "Invalid Operation";
                response.Code = 401;
            }
            //Data = null
            return serializer.Serialize(response);
        }

        public string getBandReviews(int pintBandId)
        {
            List<clsReview> reviews = new List<clsReview>();
            clsResponse response = new clsResponse();

            FacadeDA.getAllBandReviews(ref reviews,ref response,pintBandId);

            response.Data = serializer.Serialize(reviews);
            return serializer.Serialize(response);
        }

        public string getOwnBandReview(string pstringRequest, int pintBandId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsReview review = new clsReview();
            clsResponse response = new clsResponse();

            FacadeDA.getReviewBandUser(ref review,ref response,request.Id,pintBandId);

            response.Data = serializer.Serialize(review);
            return serializer.Serialize(response);
        }

        public string reviewBand(string pstringRequest, int pintBandId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsReview review = DeserializeJson.DeserializeReview(request.Data);
            clsResponse response = new clsResponse();
            TwitterCom twitter = new TwitterCom();

            // bool existBand = FacadeDA.existreviewdisk(pintBandId, request.Id, ref response);
            // if (!existBand && response.Success)
            // {
            System.Diagnostics.Debug.WriteLine(request.Id + " En rafa " + pintBandId);
                FacadeDA.createReviewBand(ref review, request.Id, pintBandId, ref response);

                try
                {
                    string hashtag = FacadeDA.getHashTag(ref response, pintBandId);
                    string fanName = FacadeDA.getFanName(ref response, request.Id);
                    string msj = fanName + " reseñó a " + "#" + hashtag;
                    twitter.sendTweet(msj);
                    
                }
                catch
                {
                    //error info
                    response.Success = false;
                    response.Message = "Error with twitter";
                    response.Code = 5;
                }
           // }

            //data null
            return serializer.Serialize(response);
        }

        public string getBandStats(int pintBandId)
        {
            clsResponse response = new clsResponse();
            clsBandStats BandStats = new clsBandStats();

            BandStats.Calification = FacadeDA.getCalificationBand(ref response,pintBandId);
            BandStats.Followers = FacadeDA.getFollowersBand(ref response, pintBandId);

            if (BandStats.Calification==0)
            {
                BandStats.Calification = 1; //minimun calification
            }

            response.Data = serializer.Serialize(BandStats);
            return serializer.Serialize(response);
        }
        public string Dashboard(int pintBandId)
        {
            clsResponse response = new clsResponse();
            clsBandDashboard dashboard = new clsBandDashboard();

            //BandStats.Calification = FacadeDA.getCalificationBand(ref response, pintBandId);
            //BandStats.Followers = FacadeDA.getFollowersBand(ref response, pintBandId);

            response.Data = serializer.Serialize(dashboard);
            return serializer.Serialize(response);
        }


        public string deleteBandReview(string pstringRequest, int pintBandId)
        {
            clsRequest request = JsonConvert.DeserializeObject<clsRequest>(pstringRequest);
            clsResponse response = new clsResponse();

            FacadeDA.deleteBandReview( ref response,request.Id, pintBandId);
            
            return serializer.Serialize(response);
        }

        public string createGenre(string pstringGenre)
        {
            clsResponse response = new clsResponse();

            FacadeDA.createNewGenero(pstringGenre,ref response);

            return serializer.Serialize(response);
            
        }
    }
}
