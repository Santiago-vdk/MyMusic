using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFan_API.Controllers;
using Moq;
using DTO;
using System.Web.Http;
using System.Web.Http.Results;
using System.Net.Http;
using System.Web.Http.Routing;
using Newtonsoft.Json;
using System.Collections.Generic;
using MyFan_API;
using BusinessLogic;

namespace MyFan_API.Tests
{
    [TestClass]
    public class TestFansController
    {
        [TestMethod]
        public void GetReturnsJsonString()
        {
            clsForm form = new clsForm();
            form.genres = new List<string>(new string[] { "Rock", "Metal", "Pop" });
            form.codGenres = new List<int>(new int[] { 1, 2, 3 });
            form.genders = new List<string>(new string[] { "Masculino", "Femenino" });
            form.codGenders = new List<int>(new int[] { 1, 2, 3 });
            form.locations = new List<string>(new string[] { "Costa Rica", "Panama", "Estados Unidos" });
            form.codLocations = new List<int>(new int[] { 1, 2, 3 });


            var _mock = new Mock<FacadeBL>();

            _mock.Setup(x => x.getFanForm()).Returns(JsonConvert.SerializeObject(form));
           
        }
    }
}