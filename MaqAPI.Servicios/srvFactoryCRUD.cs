using MaqAPI.Datos.Operaciones;
using MaqAPI.Datos.Catalogos;
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
            if (tipoCRUD.OBRAS == pCRUDS)
                return new ObrasABC<ObraEntidad>();

            if (tipoCRUD.OPERADORES == pCRUDS)
                return new OperadoresABC<OperadorEntidad>();

            if (tipoCRUD.EQUIPOS == pCRUDS)
                return new MaquinariaABC<MaquinariaEntidad>();

            if (tipoCRUD.BITSEG == pCRUDS)
                return new BitSegABC<BitSegEntidad>();

            if (tipoCRUD.UBICACION == pCRUDS)
                return new UbicacionesABC<UbicacionEntidad>();


            return null;
        }
    }
}
