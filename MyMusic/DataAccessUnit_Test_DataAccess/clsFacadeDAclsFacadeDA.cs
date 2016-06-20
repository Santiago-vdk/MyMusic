using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataAccess.Tests
{
    [TestClass()]
    public class clsFacadeDAclsFacadeDA
    {
        
        [TestMethod()]
        public void getAllGenresTest()
        {
            clsFacadeDA Facade = new clsFacadeDA();
            clsResponse Response = new clsResponse();
            clsForm Form = new clsForm();
            Facade.getAllGenres(Form, ref Response);
            Assert.AreEqual(Response.Code,0);
        }

       
        [TestMethod()]
        public void getBandsTest()
        {
            clsFacadeDA Facade = new clsFacadeDA();
            clsResponse Response = new clsResponse();
            clsBandsBlock Block = new clsBandsBlock();
            Facade.getBands(Block, ref Response, 89, 0, 5);
            Assert.AreEqual(Response.Code, 0);
        }

       [TestMethod()]
        public void getdiskinfoTest()
        {
            clsFacadeDA Facade = new clsFacadeDA();
            clsResponse Response = new clsResponse();
            clsDisk Disc = new clsDisk();
            Facade.getdiskinfo(ref Disc, ref Response, 32);
            Assert.AreEqual(Response.Code, 0);
        }

        [TestMethod()]
        public void getCalificationBandTest()
        {
            clsFacadeDA Facade = new clsFacadeDA();
            clsResponse Response = new clsResponse();
            int Result = Facade.getCalificationBand(ref Response, 124);
            Assert.AreEqual(Response.Code, 0);
        }


        [TestMethod()]
        public void createNewGeneroTest()
        {
            clsFacadeDA Facade = new clsFacadeDA();
            clsResponse Response = new clsResponse();
            String GeneroNuevo = "Rancheras";
            Facade.createNewGenero(GeneroNuevo,ref Response);
            Assert.AreEqual(Response.Code, 0);
        }
    }
}