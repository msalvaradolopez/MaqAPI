using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaqAPI.Interface;
using MaqAPI.DTO;

namespace MaqAPI.DAO
{
    public class InsPecDAO : ICatalogoItem<InsPecDTO>, IConsultaItem<InsPecDTO>
    {
        public bool DeleteItem(InsPecDTO pItem)
        {
            throw new NotImplementedException();
        }

        public InsPecDTO GetItemById(FiltrosDTO pFiltros)
        {
            throw new NotImplementedException();
        }

        public List<InsPecDTO> GetItemList(FiltrosDTO pFiltros)
        {
            throw new NotImplementedException();
        }

        public InsPecDTO InsertItem(InsPecDTO pItem)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(InsPecDTO pItem)
        {
            throw new NotImplementedException();
        }
    }
}
