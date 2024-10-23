using Firma_Transport.Helpers;
using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.PassangerTypes
{
    internal class NewPassangerTypeViewModel : NewViewModel<PassangerType>
    {

        #region Constructor
        public NewPassangerTypeViewModel():base("Dodaj Typ Pasażerski")
        {
            item = new PassangerType();
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

        public int NumberMin
        {
            get
            {
                return item.NumberMin;
            }
            set
            {
                if (item.NumberMin != value)
                {
                    item.NumberMin = value;
                    OnPropertyChanged(() => NumberMin);
                }
            }
        }

        public int NumberMax
        {
            get
            {
                return item.NumberMax;
            }
            set
            {
                if (item.NumberMax != value)
                {
                    item.NumberMax = value;
                    OnPropertyChanged(() => NumberMax);
                }
            }
        }

        public double LuggageWeightMin
        {
            get
            {
                return item.LuggageWeightMin;
            }
            set
            {
                if (item.LuggageWeightMin != value)
                {
                    item.LuggageWeightMin = value;
                    OnPropertyChanged(() => LuggageWeightMin);
                }
            }
        }

        public double LuggageWeightMax
        {
            get
            {
                return item.LuggageWeightMax;
            }
            set
            {
                if (item.LuggageWeightMax != value)
                {
                    item.LuggageWeightMax = value;
                    OnPropertyChanged(() => LuggageWeightMax);
                }
            }
        }

        public bool Accessibility
        {
            get
            {
                return item.Accessibility;
            }
            set
            {
                if (item.Accessibility != value)
                {
                    item.Accessibility = value;
                    OnPropertyChanged(() => Accessibility);
                }
            }
        }

        public decimal Price
        {
            get
            {
                return item.Price;
            }
            set
            {
                if (item.Price != value)
                {
                    item.Price = value;
                    OnPropertyChanged(() => Price);
                }
            }
        }

        #endregion
    }

}
