using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Firma_Transport.ViewModel.Workspaces.Clients
{
    internal class AllClientsViewModel:AllViewModel<ClientForView>
    {

        #region Commands

        private ClientForView _SelectedClient;

        public ClientForView SelectedClient
        {
            set
            {
                if (_SelectedClient != value)
                {
                    _SelectedClient = value;
                    Messenger.Default.Send(_SelectedClient);
                    OnRequestClose();
                }

            }
            get
            {
                return _SelectedClient;
            }
        }

        #endregion

        #region Contructor
        public AllClientsViewModel()
            : base("Wszyscy Kontrahenci")
        { IdentificationString = "ClientAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> {"Nazwa","Kod","Identyfikacja","Adres"};
        }

        public override void sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<ClientForView>(List.OrderBy(item => item.ClientName));
            if (SortField == "Kod")
                List = new ObservableCollection<ClientForView>(List.OrderBy(item => item.Code));
            if (SortField == "Identyfikacja")
                List = new ObservableCollection<ClientForView>(List.OrderBy(item => item.ClientNumber));
            if (SortField == "Adres")
                List = new ObservableCollection<ClientForView>(List.OrderBy(item => item.Address));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> {"Nazwa", "Kod", "Identyfikacja", "Adres" };
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<ClientForView>(List.Where(item => item.ClientName
           != null && item.ClientName.Contains(FindTextBox)));
            if (FindField == "Kod")
                List = new ObservableCollection<ClientForView>(List.Where(item => item.Code
           != null && item.Code.Contains(FindTextBox)));
            if (FindField == "Identyfikacja")
                List = new ObservableCollection<ClientForView>(List.Where(item => item.ClientNumber
           != null && item.ClientNumber.Contains(FindTextBox)));
            if (FindField == "Adres")
                List = new ObservableCollection<ClientForView>(List.Where(item => item.Address
           != null && item.Address.Contains(FindTextBox)));


        }
        public override void load()
        {
            List = new ObservableCollection<ClientForView>
                (
                    from client in firmaTransportDBEntities.Clients
                    select new ClientForView
                    {
                        ClientID=client.ClientId,
                        Code=client.Code,
                        ClientName=client.Name+" "+client.Surname,
                        ClientNumber=client.Nip+client.Pesel,
                        Address = client.AddressNavigation.City + " " +
                                client.AddressNavigation.Street + " " +
                                client.AddressNavigation.Building + " " +
                                client.AddressNavigation.PostalCode,
                    }
                );
        }
        public override void remove()
        {
            firmaTransportDBEntities.Clients.Remove((from client in firmaTransportDBEntities.Clients
                                                        where client.ClientId == RemoveId
                                                        select client).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }
        #endregion
    }
}
