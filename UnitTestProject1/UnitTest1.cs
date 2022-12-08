using MaqAPI.Entidades;
using MaqAPI.Servicios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var _srvCRUD = new srvCRUD<BitSegEntidad>(tipoCRUD.BITSEG);


            var pBitSeg = new BitSegEntidad {
                fecha = DateTime.Now,
                idOperador = "0088",
                idEconomico = "621-G1",
                idObra = "CAJONES",
                area = "AREA 01",
                hora_inicio = DateTime.Now,
                hora_termino = DateTime.Now,
                actividad = "ACTIVIDAD",
                pto_exacto = "PTO EXACTO",
                chequeo_medico = "SI",
                
                idUsuario = "0088"
            };

            _srvCRUD.Insertar(pBitSeg);
        }
    }
}
