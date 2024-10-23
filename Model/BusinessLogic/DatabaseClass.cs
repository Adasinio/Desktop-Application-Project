using Firma_Transport.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.BusinessLogic
{

    //do wykorzystywania przez klasy logiki biznesowej

    public class DatabaseClass
    {
        #region Fields

        protected FirmaTransportDBEntities firmaTransportDBEntities;

        #endregion

        #region Constructor

        public DatabaseClass (FirmaTransportDBEntities firmaTransportDBEntities)
        {
            this.firmaTransportDBEntities = firmaTransportDBEntities;
        }

        #endregion
    }
}
