using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ydRSoft.Model;
using ydRSoft.BL;
namespace ydRSoft.Pruebas
{
    [TestClass]
    public class ComprasUT
    {


        [TestMethod]
        public void ut_Login()
        {
            var solicitud = new CompraSolModel();
            CompraBL bl = new CompraBL();
            var resultado = bl.AddSolicitud(solicitud);

            Assert.AreEqual(resultado.Error, true);
        }


        [TestMethod]
        public void ut_Login_fail()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ut_AddSolicitud_Nulo()
        {
            var solicitud = new CompraSolModel();
            CompraBL bl = new CompraBL();
            var resultado = bl.AddSolicitud(solicitud);

            Assert.AreEqual(resultado.Error,true);
        }


        [TestMethod]
        public void ut_AddSolicitud_Duplicado()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ut_AddSolicitud_Guardado()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ut_AddOrden_Nulo()
        {
            var solicitud = new CompraSolModel();
            CompraBL bl = new CompraBL();
            var resultado = bl.AddSolicitud(solicitud);

            Assert.AreEqual(resultado.Error, true);
        }


        [TestMethod]
        public void ut_AddOrden_Duplicado()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ut_AddOrden_Guardado()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ut_AddGuia_Nulo()
        {
            var solicitud = new CompraSolModel();
            CompraBL bl = new CompraBL();
            var resultado = bl.AddSolicitud(solicitud);

            Assert.AreEqual(resultado.Error, true);
        }


        [TestMethod]
        public void ut_AddGuia_Duplicado()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

        [TestMethod]
        public void ut_AddGuia_Guardado()
        {

            CompraBL bl = new CompraBL();
            var resultado = bl.ListaAlmaSol();

            Assert.AreEqual(resultado, null);
        }

    }
}
