using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISIC.Persistence.Context;
using MPBA.DataAccess;
using ISIC.Entities;
using ISIC.Services;
using System.Drawing;
using System.Reflection;
using ISIC.Utils;
using System.Drawing.Imaging;

namespace TestProject
{
    [TestClass]
    public class TestMegaMatcherService
    {
        [TestMethod]
        public void TestImgToBase64()
        {
            MegaMatcherService s = new MegaMatcherService();            
            var stream = Assembly.GetAssembly(this.GetType()).
            GetManifestResourceStream("TestProject.Resources.huella.png");
            var stringBase64 = s.ConvertStreamToWSQBase64(stream, ImageFormat.Png);
            Assert.IsNotNull(stringBase64);
        }

    }
}
