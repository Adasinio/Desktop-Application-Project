using Firma_Transport.Helpers;
using Firma_Transport.Model.BusinessLogic;
using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using Firma_Transport.Validators;
using Firma_Transport.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel.Workspaces.Drivers
{
    internal class NewDriverViewModel : NewViewModel<Employee>, IDataErrorInfo
    {

        #region Commands

        private BaseCommand _ShowAddressesCommand;

        public ICommand ShowAddressesCommand
        {
            get
            {
                if (_ShowAddressesCommand == null)
                {
                    _ShowAddressesCommand = new BaseCommand(() =>
                    Messenger.Default.Send("AddressesShow"));
                }
                return _ShowAddressesCommand;
            }
        }

        private void DefaultEmploymentForm()
        {
            EmploymentForm = new EmployeeB(firmaTransportDBEntities).JobTitleEmploymentForm(JobTitle);
        }

        #endregion

        #region Contructor

        public NewDriverViewModel() : base("Dodaj Pracownika")
        {
            item = new Employee();
            Messenger.Default.Register<Address>(this, getSelectedAddress);
        }

        #endregion

        #region Helpers

        private void getSelectedAddress(Address address)
        {
            Address = address.AddressId;
            Street = address.Street;
            Building = address.Building;
            PostalCode = address.PostalCode;
            City = address.City;
        }

        #endregion

        #region Properties

        public string Name
        {
            get { return item.Name; }
            set
            {
                if (item.Name != value)
                {
                    item.Name = value;
                    base.OnPropertyChanged(() => Name);
                }
            }
        }

        public string Surname
        {
            get { return item.Surname; }
            set
            {
                if (item.Surname != value)
                {
                    item.Surname = value;
                    base.OnPropertyChanged(() => Surname);
                }
            }
        }

        public string? Phone
        {
            get { return item.Phone; }
            set
            {
                if (item.Phone != value)
                {
                    item.Phone = value;
                    base.OnPropertyChanged(() => Phone);
                }
            }
        }

        public int JobTitle
        {
            get { return item.JobTitle; }
            set
            {
                if (item.JobTitle != value)
                {
                    item.JobTitle = value;
                    this.DefaultEmploymentForm();
                    base.OnPropertyChanged(() => JobTitle);
                }
            }
        }
        public IQueryable<JobTitle> JobTitlesComboBoxItems
        {
            get
            {
                return
                    (
                    from JobTitle in firmaTransportDBEntities.JobTitles
                    select JobTitle
                    ).ToList().AsQueryable();
            }
        }

        public int EmploymentForm
        {
            get { return item.EmploymentForm; }
            set
            {
                if (item.EmploymentForm != value)
                {
                    item.EmploymentForm = value;
                    base.OnPropertyChanged(() => EmploymentForm);
                }
            }
        }
        public IQueryable<EmploymentForm> EmploymentFormsComboBoxItems
        {
            get
            {
                return
                    (
                    from EmploymentForm in firmaTransportDBEntities.EmploymentForms
                    select EmploymentForm
                    ).ToList().AsQueryable();
            }
        }
        public int Address
        {
            get { return item.Address; }
            set
            {
                if (item.Address != value)
                {
                    item.Address = value;
                    base.OnPropertyChanged(() => Address);
                }
            }
        }

        private string? _Street;
        public string? Street
        {
            get { return _Street; }
            set
            {
                if (_Street != value)
                {
                    _Street = value;
                    base.OnPropertyChanged(() => _Street);
                }
            }
        }

        private string _Building;
        public string Building
        {
            get { return _Building; }
            set
            {
                if (_Building != value)
                {
                    _Building = value;
                    base.OnPropertyChanged(() => _Building);
                }
            }
        }

        private string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if (_PostalCode != value)
                {
                    _PostalCode = value;
                    base.OnPropertyChanged(() => _PostalCode);
                }
            }
        }

        private string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    base.OnPropertyChanged(() => _City);
                }
            }
        }

        //public IQueryable<KeyAndValue> AddressesComboBoxItems
        //{
        //    get
        //    {
        //        return
        //            (
        //            from Address in firmaTransportDBEntities.Addresses
        //            select new KeyAndValue
        //            {
        //                Key = Address.AddressId,
        //                Value = Address.City + " " + Address.Street + " " + Address.PostalCode
        //            }
        //            ).ToList().AsQueryable();
        //    }
        //}


        public int Availability
        {
            get { return item.Availability; }
            set
            {
                if (item.Availability != value)
                {
                    item.Availability = value;
                    base.OnPropertyChanged(() => Availability);
                }
            }
        }

        public IQueryable<Availability> AvailabilitiesComboBoxItems
        {
            get
            {
                return
                    (
                    from Availability in firmaTransportDBEntities.Availabilities
                    select Availability
                    ).ToList().AsQueryable();
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
                    case nameof(Name):
                        {
                            result = Name?.ValidateIsFirstLetterUpper( out error) ?? string.Empty;
                            HasError = error;
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
