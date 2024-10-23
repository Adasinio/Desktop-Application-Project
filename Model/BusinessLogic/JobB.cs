using Firma_Transport.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.BusinessLogic
{
    public class JobB:DatabaseClass // bo używa bazy danych
    {
        #region Constructor

        public JobB(FirmaTransportDBEntities firmaTransportDBEntities)
            :base(firmaTransportDBEntities) { }

        #endregion

        #region BusinessFunctions

        public decimal? JobPrice (decimal? passangerPrice, decimal? cargoPrice, float? discount)
        {
            if (discount == null)
            {
                if (passangerPrice == null && cargoPrice == null)
                    return 0;
                else if (passangerPrice == null)
                    return cargoPrice;
                else if (cargoPrice == null)
                    return passangerPrice;
                else
                    return passangerPrice + cargoPrice;
            }
                
            else if (passangerPrice == null && cargoPrice == null)
                return 0;
            else if (passangerPrice == null)
                return cargoPrice * (((decimal)(100 - discount)) / 100);
            else if (cargoPrice == null)
                return passangerPrice * (((decimal)(100 - discount)) / 100);
            else
                return (passangerPrice + cargoPrice) * (((decimal)(100 - discount)) / 100);
        }

        #endregion
    }
}
