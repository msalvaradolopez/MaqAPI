using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Migracion
{
    public class srvMigracion
    {
        public bool MigrarObras()
        {
            try
            {
                var _obrasMIG = new ObrasMIG();
                var _catalogosMIG = new CatalogosMIG(_obrasMIG);
                _catalogosMIG.MigrarCatalogo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool MigrarOperadores()
        {
            try
            {
                var _operadoresMIG = new OperadoresMIG();
                var _catalogosMIG = new CatalogosMIG(_operadoresMIG);
                _catalogosMIG.MigrarCatalogo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool MigrarMaquinaria()
        {
            try
            {
                var _maquinariaMIG = new MaquinariaMIG();
                var _catalogosMIG = new CatalogosMIG(_maquinariaMIG);
                _catalogosMIG.MigrarCatalogo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool MigrarUbicaciones()
        {
            try
            {
                var _ubicacionesMIG = new UbicacionesMIG();
                var _catalogosMIG = new CatalogosMIG(_ubicacionesMIG);
                _catalogosMIG.MigrarCatalogo();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
