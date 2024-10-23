using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    class ClientForView
    { 
        #region Data

        public int ClientID { get; set; }
        public string? Code { get; set; }
        public string? ClientName { get; set; }
        public string? ClientNumber { get; set; }
        public string? Address { get; set; }

        #endregion
    }
}
