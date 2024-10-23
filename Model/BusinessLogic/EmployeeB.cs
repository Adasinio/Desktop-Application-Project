using Firma_Transport.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.Model.BusinessLogic
{
    class EmployeeB:DatabaseClass
    {
        #region Constructor

        public EmployeeB(FirmaTransportDBEntities firmaTransportDBEntities)
            : base(firmaTransportDBEntities) { }

        #endregion

        #region BusinessFunctions

        public int JobTitleEmploymentForm ( int jobTitle)
        {
            int form;
            var title = string.Empty;
            title = JobTitleName(jobTitle);
            switch (title)
            {
                case "Kierowca":
                    {
                        form = EmploymentFormNameToId("Umowa Zlecenie");
                    }
                    break;
                case "Księgowy":
                case "Menedżer":
                    {
                        form = EmploymentFormNameToId("Umowa o Pracę");
                    }
                    break;
                default:
                    {
                        form = EmploymentFormNameToId("Umowa o Dzieło");
                    }
                    break;
            }
            return form;


        }

        public string JobTitleName( int jobTitle)
        {
            var result = string.Empty;
            result=
                (from j in firmaTransportDBEntities.JobTitles
                where j.JobTitleId == jobTitle
                select j.Name).FirstOrDefault().ToString();
            return result;
        }

        public int EmploymentFormNameToId(string name)
        {
            int result;
            result=
                (from e in firmaTransportDBEntities.EmploymentForms
                 where  e.Name == name
                 select e.EmploymentFormId).FirstOrDefault();
            return result;
        }


        #endregion

    }
}
