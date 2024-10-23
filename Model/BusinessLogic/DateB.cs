using Firma_Transport.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.BusinessLogic
{
    internal class DatesB : DatabaseClass // bo używa bazy danych
    {
        #region Constructor

        public DatesB(FirmaTransportDBEntities firmaTransportDBEntities)
            : base(firmaTransportDBEntities) { }

        #endregion

        #region BusinessFunctions

        public DateTime DueDateFunction (DateTime invoiceDate)
        {
            return invoiceDate.AddDays(14);
        }

        #endregion

    }
}
