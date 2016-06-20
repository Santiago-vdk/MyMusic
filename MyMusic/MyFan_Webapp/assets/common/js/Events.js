/*function GetMyReview(fanId, bandId, eventId) {

    var request = {
        fanId: fanId,
        bandId: bandId,
        eventId: eventId
    }
    console.log("mine " + request)
    $.ajax({
        url: "/Fans/" + fanId + "/Bands/" + bandId + "/Events/Review/" + eventId,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            console.log("datatata " + data);

                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">' +
                  ' <div class="row ">' +
                      ' <div class="col-xs-12 review-box">' +

                          ' <div class="row">' +

                               '<div class="col-xs-6 review-user"><h3>' + data.Author + '</h3></div>' +

                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data.Calification + '.png"></div>' +
                           '</div>' +

                           '<div class="row">' +

                               '<div class="col-xs-12">' +
                                  ' <p>' + data.Comment + '</p>' +
                               '</div>' +
                           '</div>' +
                       '</div>' +
                   '</div><button type="button" onclick="DeleteMyReview(@Model.Id,@Model"></button>' +
               '</div><br/>')

            
        },
        error: function () {
           // alert('Something goes wrong!');

        }
    });


}*/


function canReview() {
    console.log("can review");
    $("#reviews_show").append('<form id="form-new-album" action="~/Fans/@Model.Id/Bands/@Model.BandProfile.Id/Events/PostReview/@Model.BandProfile.Event.Id" class="form-horizontal"> <input class="form-control" name="fanId" value="@Model.Id" type="hidden" /> <input class="form-control" name="bandId" value="@Model.BandProfile.Id" type="hidden" /> <input class="form-control" name="eventId" value="@Model.BandProfile.Event.Id" type="hidden" /> <input class="form-control" name="fanName" value="@Model.Name" type="hidden" /> <div class="form-group"> <div class="col-xs-3 text-right"> <label for="inputAlbumName">Rate:</label> </div> <div class="col-xs-9"> <input type="text" class="form-control" placeholder="Type a number from 1 to 5" name="rate" id="AlbumName" /> </div> </div> <div class="form-group"> <div class="col-xs-3 text-right"> <label for="inputAlbumName">Comment:</label> </div> <div class="col-xs-9"> <input type="text" class="form-control" placeholder="Comment" name="comment" id="AlbumName" /> </div> </div> <div class="form-group"> <div class="row"> <div class="col-xs-offset-4 col-xs-3"> <button id="post-album-form" type="submit" class="btn btn-success">Publish</button> </div> </div> </div> </form>');
  
}


function GetEventReviews(fanId, bandId, eventId, isConcert, state) {
    console.log("Called event " + state);

    if (isConcert != true) {
        console.log("was not concert");
        return false;
    }

    

    var request = {
        fanId: fanId,
        bandId: bandId,
        eventId: eventId
    }
    console.log(request)
    $.ajax({
        url: "/Fans/" + fanId + "/Bands/" + bandId + "/Events/Reviews/" + eventId,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            if (data.length == 0) {
                return false;
            }

            if (state == "Pending") {

            }
            if (state == "Finalized") {
                canReview();
            
            }
            if (state == "Cancelled") {
                canReview();
               
            }
            


            for (i = 0; i < data.length; i++) {
                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">' +
                  ' <div class="row ">' +
                      ' <div class="col-xs-12 review-box">' +

                          ' <div class="row">' +

                               '<div class="col-xs-6 review-user"><h3>' + data[i].Author + '</h3></div>' +

                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data[i].Calification + '.png"></div>' +
                           '</div>' +

                           '<div class="row">' +

                               '<div class="col-xs-12">' +
                                  ' <p>' + data[i].Comment + '</p>' +
                               '</div>' +
                           '</div>' +
                       '</div>' +
                   '</div>' +
               '</div><br/>');
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}



function GetEventReviewsInBand(bandId, eventId, isConcert) {
    console.log("Called event isnide band" + bandId + " " + " "+eventId + isConcert);

    if (isConcert != true) {
        console.log("was not concert");
        return false;
    }

    var request = {
        userId: bandId,
        id: eventId
    }
    console.log(request)
    $.ajax({
        url: "/Bands/" + bandId + "/Events/Reviews/" + eventId,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            console.log(data);
            for (i = 0; i < data.length; i++) {
                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">' +
                  ' <div class="row ">' +
                      ' <div class="col-xs-12 review-box">' +

                          ' <div class="row">' +

                               '<div class="col-xs-6 review-user"><h3>' + data[i].Author + '</h3></div>' +

                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data[i].Calification + '.png"></div>' +
                           '</div>' +

                           '<div class="row">' +

                               '<div class="col-xs-12">' +
                                  ' <p>' + data[i].Comment + '</p>' +
                               '</div>' +
                           '</div>' +
                       '</div>' +
                   '</div>' +
               '</div><br/>')

            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}