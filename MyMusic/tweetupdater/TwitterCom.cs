using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using TweetSharp;

namespace tweetupdater
{
    public class TwitterCom
    {
        
        
        public void sendTweet(String Tweet)
        {
            var service = new TwitterService("geHKpv8EaL70fJzGpJwg03Glo", "FY0NN8vAFzUn6JTqi3bQMuCikph6kT6isqOBouAY2t4Al4Ttm7");
            service.AuthenticateWith("2191703324-GCtGVHkM2283ZnPWbfYOJ9Bl6ArWlmx8abw7OLT", "gFsqUatS43wXUvTagkfO4SDW4K6TiEOXNr5KR6BM1S5q6");
            service.SendTweet(new SendTweetOptions { Status =  Tweet });
        }


        public static void Main()
        {
            new TwitterCom().sendTweet("hell yeah!");

        }
    }
}
