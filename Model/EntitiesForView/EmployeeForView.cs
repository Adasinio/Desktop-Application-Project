using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.EntitiesForView
{
    class EmployeeForView
    {
        #region Data

        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? JobTitle { get; set; }
        public string? EmploymentForm { get; set; }
        public string? Address { get; set; }
        public string? Availability { get; set; }
        #endregion
    }
}
