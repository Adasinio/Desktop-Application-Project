using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    public class JobForView
    {
        #region Data

        public int JobID { get; set; }

        //instead of CargoID, maybe add Cargo Nature?
        public string? CargoCode { get; set; }

        //Instead of PassangerTypeID
        public string? PassangerTypeCode { get; set; }

        //Instead of DriverID
        public string? DriverName { get; set; }

        //Instead of Vehicle ID
        public string? VehicleName { get; set; }

        //Instead of ReccurencyID
        public string? Reccurency  { get; set; }

        public decimal? Price { get; set; }

        public float? Discount { get; set; }
        #endregion
    }
}
