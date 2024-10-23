using Firma_Transport.Helpers;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.Adresses
{
    internal class AllAdressesViewModel:AllViewModel<Address>
    {
        #region Commands

        private Address _SelectedAddress;

        public Address SelectedAddress
        {
            set
            {
                if (_SelectedAddress != value) 
                {
                    _SelectedAddress = value;
                    Messenger.Default.Send(_SelectedAddress);
                    OnRequestClose();
                }

            }
            get
            {
                return _SelectedAddress;
            }
        }

        #endregion

        #region Contructor
        public AllAdressesViewModel()
            : base("Wszystkie Adresy")
        { IdentificationString = "AdresyAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Miejscowość", "Ulica", "Nr Budynku", "Numer Mieszkania", "Kod Pocztowy" };
        }

        public override void sort()
        {
            if (SortField == "Kod Miejscowość")
                List = new ObservableCollection<Address>(List.OrderBy(item => item.City));
            if (SortField == "Ulica")
                List = new ObservableCollection<Address>(List.OrderBy(item => item.Street));
            if (SortField == "Nr Budynku")
                List = new ObservableCollection<Address>(List.OrderBy(item => item.Building));
            if (SortField == "Numer Mieszkania")
                List = new ObservableCollection<Address>(List.OrderBy(item => item.Flat));
            if (SortField == "Kod Pocztowy")
                List = new ObservableCollection<Address>(List.OrderBy(item => item.PostalCode));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Miejscowość", "Ulica","Nr Budynku","Numer Mieszkania","Kod Pocztowy"};
        }
        public override void find()
        {
            if (FindField == "Miejscowość")
                List = new ObservableCollection<Address>(List.Where(item => item.City
           != null && item.City.Contains(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<Address>(List.Where(item => item.Street
           != null && item.Street.Contains(FindTextBox)));
            if (FindField == "Nr Budynku")
                List = new ObservableCollection<Address>(List.Where(item => item.Building
           != null && item.Building.Contains(FindTextBox)));
            if (FindField == "Numer Mieszkania")
                List = new ObservableCollection<Address>(List.Where(item => item.Flat
           != null && item.Flat.Contains(FindTextBox)));
            if (FindField == "Kod Pocztowy")
                List = new ObservableCollection<Address>(List.Where(item => item.PostalCode
           != null && item.PostalCode.Contains(FindTextBox)));

        }

        public override void load()
        {
            List = new ObservableCollection<Address>
                (
                firmaTransportDBEntities.Addresses
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Addresses.Remove((from a in firmaTransportDBEntities.Addresses
                                                  where a.AddressId == RemoveId
                                                  select a).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
