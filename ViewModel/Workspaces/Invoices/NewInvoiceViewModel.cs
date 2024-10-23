using Firma_Transport.Helpers;
using Firma_Transport.Model.BusinessLogic;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using Firma_Transport.Validators;
using Firma_Transport.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Firma_Transport.ViewModel.Workspaces.Invoices
{
    internal class NewInvoiceViewModel:NewViewModel<Invoice>,IDataErrorInfo
    {
        #region Commands

        private BaseCommand _ShowClientsCommand;

        public ICommand ShowClientsCommand
        {
            get
            {
                if (_ShowClientsCommand == null)
                {
                    _ShowClientsCommand = new BaseCommand(() =>
                    Messenger.Default.Send("ClientsShow"));
                }
                return _ShowClientsCommand;
            }
        }
        private BaseCommand _CalculateDueDateCommand;

        public ICommand CalculateDueDateCommand
        {
            get
            {
                if (_CalculateDueDateCommand == null)
                {
                    _CalculateDueDateCommand = new BaseCommand(() => CalculateDueDate());

                }
                return _CalculateDueDateCommand;
            }
        }

        private void CalculateDueDate()
        {
            DueDate = new DatesB(firmaTransportDBEntities).DueDateFunction(InvoiceDate);
        }


        #endregion

        #region Contructor
        public NewInvoiceViewModel() : base("Dodaj Fakturę")
        {
            item = new Invoice();
            InvoiceDate = DateTime.Now;
            this.CalculateDueDate();
            Messenger.Default.Register<ClientForView>(this, getSelectedClient);
        }

        #endregion
        
        #region Helpers

        private void getSelectedClient(ClientForView client)
        {
            Client = client.ClientID;
            ClientName = client.ClientName;
            ClientNumber = client.ClientNumber;

        }

        #endregion

        #region Properties

        public int Client
        {
            get { return item.Client; }
            set
            {
                if (item.Client != value)
                {
                    item.Client = value;
                    base.OnPropertyChanged(() => Client);
                }
            }
        }

        private string _ClientName;
        public string ClientName
        {
            get { return _ClientName; }
            set
            {
                if (_ClientName != value)
                {
                    _ClientName = value;
                    base.OnPropertyChanged(() => _ClientName);
                }
            }
        }

        private string _ClientNumber;
        public string ClientNumber
        {
            get { return _ClientNumber; }
            set
            {
                if (_ClientNumber != value)
                {
                    _ClientNumber = value;
                    base.OnPropertyChanged(() => _ClientNumber);
                }
            }
        }

        public IQueryable<KeyAndValue> ClientsComboBoxItems
        {
            get
            {
                return
                    (
                    from Client in firmaTransportDBEntities.Clients
                    select new KeyAndValue
                    {
                        Key=Client.ClientId,
                        Value=Client.Name+" "+Client.Surname+" "+Client.Nip+Client.Pesel+Client.AddressNavigation.City+" "+Client.AddressNavigation.Street+" "+Client.AddressNavigation.Building
                    }
                    ).ToList().AsQueryable();
            }
        }

        public DateTime InvoiceDate
        {
            get { return item.InvoiceDate; }
            set
            {
                if (item.InvoiceDate != value)
                {
                    item.InvoiceDate = value;
                    this.CalculateDueDate();
                    base.OnPropertyChanged(() => InvoiceDate);
                }
            }
        }

        public DateTime DueDate
        {
            get { return item.DueDate; }
            set
            {
                if (item.DueDate != value)
                {
                    item.DueDate = value;
                    base.OnPropertyChanged(() => DueDate);
                }
            }
        }

        public DateTime? PaidDate
        {
            get { return item.PaidDate; }
            set
            {
                if (item.PaidDate != value)
                {
                    item.PaidDate = value;
                    base.OnPropertyChanged(() => PaidDate);
                }
            }
        }

        public int? PaymentMethod
        {
            get { return item.PaymentMethod; }
            set
            {
                if (item.PaymentMethod != value)
                {
                    item.PaymentMethod = value;
                    base.OnPropertyChanged(() => PaymentMethod);
                }
            }
        }

        public IQueryable<PaymentMethod> PaymentMethodsComboBoxItems
        {
            get
            {
                return
                    (
                    from PaymentMethod in firmaTransportDBEntities.PaymentMethods
                    select PaymentMethod
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
                switch (fieldName)
                {
                    case nameof(DueDate):
                        {
                            HasError = InvoiceValidator.ValidateInvoiceDueDate(InvoiceDate,DueDate, out result);
                            break;
                        }
                    case nameof(PaidDate):
                        {
                            HasError = InvoiceValidator.ValidateInvoicePaidDate(PaidDate, DueDate, InvoiceDate, out result);
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
