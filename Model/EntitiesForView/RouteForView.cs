using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    class RouteForView
    {
        #region Data

        public int RouteId { get; set; }

        public string Lenght { get; set; }

        public string EstimatedDuration { get; set; }

        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        #endregion
    }
}
