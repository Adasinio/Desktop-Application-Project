using Firma_Transport.Helpers;
using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using Firma_Transport.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.Adresses
{
    internal class NewAdressViewModel : NewViewModel<Address>, IDataErrorInfo
    {

        #region Constructor
        public NewAdressViewModel() : base("Dodaj Adres")
        {
            item = new Address();
        }
        #endregion

        #region Data

        public string City
        {
            get
            {
                return item.City;
            }
            set
            {
                if (item.City != value)
                {
                    item.City = value;
                    OnPropertyChanged(() => City);
                }
            }
        }

        public string? Street
        {
            get
            {
                return item.Street;
            }
            set
            {
                if (item.Street != value)
                {
                    item.Street = value;
                    OnPropertyChanged(() => Street);
                }
            }
        }

        public string Building
        {
            get
            {
                return item.Building;
            }
            set
            {
                if (item.Building != value)
                {
                    item.Building = value;
                    OnPropertyChanged(() => Building);
                }
            }
        }

        public string? Flat
        {
            get
            {
                return item.Flat;
            }
            set
            {
                if (item.Flat != value)
                {
                    item.Flat = value;
                    OnPropertyChanged(() => Flat);
                }
            }
        }

        public string PostalCode
        {
            get
            {
                return item.PostalCode;
            }
            set
            {
                if (item.PostalCode != value)
                {
                    item.PostalCode = value;
                    OnPropertyChanged(() => PostalCode);
                }
            }
        }

        #endregion

        #region Validation

        public bool HasError { get; set; } = false;
        public string Error => string.Empty;

        public string this[string fieldName]
        {
            get
            {
                var result = string.Empty;
                bool error = false;
                switch (fieldName)
                {
                    case nameof(City):
                        {
                            result = City.ValidateIsFirstLetterUpper(out error);
                            HasError = error;
                            break;
                        }
                    case nameof(PostalCode):
                        {
                            HasError = AddressValidator.ValidatePostalCodeFormat(PostalCode, out result);
                            break;
                        }
                }
                return result;
            }
        }

        public override bool IsValid()
        {
            return !HasError;
        }

        #endregion
    }
}
