using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISIC.Persistence.Context;
using MPBA.DataAccess;
using ISIC.Entities;

namespace TestProject
{
    [TestClass]
    public class TestImputadoMappings
    {
        [TestMethod]
        public void TestMethod1()
        {
            ISICContext ctx = new ISICContext();
            IUnitOfWork uw = new UnitOfWork(ctx);
            
            // Pruebo crear un Imputado
            var imputado = new Imputado();

            var persona = new Persona();
            var domicilio1 = new Domicilio { 
                
            };
            var descripcionTemporal = new DescripcionTemporal();

            imputado.Persona = persona;
            //imputado.DescripcionTemporal = descripcionTemporal;

            uw.RegisterNew(imputado);
            uw.Commit();

           // Assert.IsNotNull(Aautor.Id);
           // Assert.AreNotEqual(0,autor.Id);
        }
    }
}
