using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    class CargoTypeForView
    {
        #region Data

        public int CargoTypeId { get; set; }

        public string Code { get; set; }

        public double? WeightMin { get; set; } 

        public double? WeightMax { get; set; }

        public decimal? Price { get; set; }

        public string CargoNature { get; set; }

        #endregion
    }
}
