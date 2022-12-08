using MaqAPI.Datos.Operaciones;
using MaqAPI.Entidades;
using MaqAPI.Datos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Servicios
{
    public class srvFactoryCRUD
    {
        public object srvFabrica(tipoCRUD pCRUDS)
        {
            switch (pCRUDS)
            {
                case tipoCRUD.BITSEG:
                    {
                        return new BitSegABC<BitSegEntidad>();
                    }
                default:
                    break;
            }

            return "";
        }
    }
}
