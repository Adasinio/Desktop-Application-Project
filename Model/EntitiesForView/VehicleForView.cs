using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    class VehicleForView
    {
        #region Data

        public int VehicleID { get; set; }
        public string Name { get; set; }
        public string Registration { get; set; }
        public short Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ChassisNumber { get; set; }
        public string VehicleType { get; set; }
        public bool Repair { get; set; }

        #endregion
    }
}
