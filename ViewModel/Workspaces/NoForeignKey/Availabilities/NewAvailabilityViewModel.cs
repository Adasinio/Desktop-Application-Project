using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.Availabilities
{
    internal class NewAvailabilityViewModel: NewViewModel<Availability>
    {
        #region Constructor

        public NewAvailabilityViewModel():base("Dodaj Dostępność") 
        {
            item = new Availability();
        }

        #endregion

        #region Data

        public string Code
        {
            get
            {
                return item.Code;
            }
            set
            {
                if (item.Code != value)
                {
                    item.Code = value;
                    OnPropertyChanged(() => Code);
                }
            }
        }
        public bool Monday
        {
            get
            {
                return item.Monday;
            }
            set
            {
                if (item.Monday != value)
                {
                    item.Monday = value;
                    OnPropertyChanged(() => Monday);
                }
            }
        }

        public bool Tuesday
        {
            get
            {
                return item.Tuesday;
            }
            set
            {
                if (item.Tuesday != value)
                {
                    item.Tuesday = value;
                    OnPropertyChanged(() => Tuesday);
                }
            }
        }

        public bool Wednesday
        {
            get
            {
                return item.Wednesday;
            }
            set
            {
                if (item.Wednesday != value)
                {
                    item.Wednesday = value;
                    OnPropertyChanged(() => Wednesday);
                }
            }
        }

        public bool Thursday
        {
            get
            {
                return item.Thursday;
            }
            set
            {
                if (item.Thursday != value)
                {
                    item.Thursday = value;
                    OnPropertyChanged(() => Thursday);
                }
            }
        }

        public bool Friday
        {
            get
            {
                return item.Friday;
            }
            set
            {
                if (item.Friday != value)
                {
                    item.Friday = value;
                    OnPropertyChanged(() => Friday);
                }
            }
        }

        public bool Saturday
        {
            get
            {
                return item.Saturday;
            }
            set
            {
                if (item.Saturday != value)
                {
                    item.Saturday = value;
                    OnPropertyChanged(() => Saturday);
                }
            }
        }

        public bool Sunday
        {
            get
            {
                return item.Sunday;
            }
            set
            {
                if (item.Sunday != value)
                {
                    item.Sunday = value;
                    OnPropertyChanged(() => Sunday);
                }
            }
        }

        /* public string Code
        {
            get
            {
                return item.Code;
            }
            set
            {
                string temp = "";
                if (Monday == true) { temp += "M"; }
                if (Tuesday == true) { temp += "T"; }
                if (Wednesday == true) { temp += "W"; }
                if (Thursday == true) { temp += "T"; }
                if (Friday == true) { temp += "F"; }
                if (Saturday == true) { temp += "S"; }
                if (Sunday == true) { temp += "S"; }
                item.Code = temp;
                OnPropertyChanged(()=> Code);
            }
        } */
        #endregion
    }

}
