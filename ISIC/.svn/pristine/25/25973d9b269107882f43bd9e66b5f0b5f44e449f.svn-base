using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISIC.Persistence.Context;
using MPBA.DataAccess;
using ISIC.Entities;

namespace TestProject
{
    [TestClass]
    public class TestAutorMappings
    {
        [TestMethod]
        public void TestMethod1()
        {
            ISICContext ctx = new ISICContext();
            IUnitOfWork uw = new UnitOfWork(ctx);
            
            // Pruebo crear un Autor
            var autor = new Autor();

            var persona = new Persona();
            var domicilio1 = new Domicilio { 
                
            };
            var descripcionTemporal = new DescripcionTemporal();

            autor.Persona = persona;
            //autor.Domicilio = domicilio1;
            //autor.DescripcionTemporal = descripcionTemporal;

            uw.RegisterNew(autor);
            uw.Commit();

            Assert.IsNotNull(autor.Id);
            Assert.AreNotEqual(0,autor.Id);
        }
    }
}
