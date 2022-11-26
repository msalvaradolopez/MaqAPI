using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaqAPI.Migracion
{
    public class CatalogosMIG
    {
        public ICatalogosMig _catalogosMig;

        public CatalogosMIG(ICatalogosMig catalogosMig)
        {
            this._catalogosMig = catalogosMig;
        }
        public bool MigrarCatalogo() {
            return this._catalogosMig.MigrarCatalogo();
        }

        
    }
}
