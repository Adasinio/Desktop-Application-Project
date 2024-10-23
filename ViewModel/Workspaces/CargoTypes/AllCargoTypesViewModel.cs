using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.CargoTypes
{
    internal class AllCargoTypesViewModel : AllViewModel<CargoTypeForView>
    {

        #region Commands

        private CargoTypeForView _SelectedCargoType;

        public CargoTypeForView SelectedCargoType
        {
            set
            {
                if (_SelectedCargoType != value)
                {
                    _SelectedCargoType = value;
                    Messenger.Default.Send(_SelectedCargoType);
                    OnRequestClose();
                }

            }
            get
            {
                return _SelectedCargoType;
            }
        }

        #endregion

        #region Constructor
        public AllCargoTypesViewModel()
            : base("Wszystkie Typy Towaru")
        { IdentificationString = "TypyTowaruAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Kod","Waga Minimalna","Waga Maksymalna","Cena","Charakterystyka"};
        }

        public override void sort()
        {
            if (SortField == "Kod")
                List = new ObservableCollection<CargoTypeForView>(List.OrderBy(item => item.Code));
            if (SortField == "Waga Minimalna")
                List = new ObservableCollection<CargoTypeForView>(List.OrderBy(item => item.WeightMin));
            if (SortField == "Waga Maksymalna")
                List = new ObservableCollection<CargoTypeForView>(List.OrderBy(item => item.WeightMax));
            if (SortField == "Cena")
                List = new ObservableCollection<CargoTypeForView>(List.OrderBy(item => item.Price));
            if (SortField == "Charakterystyka")
                List = new ObservableCollection<CargoTypeForView>(List.OrderBy(item => item.CargoNature));
        }

        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod","Charakterystyka" };
        }

        public override void find()
        {
            if (FindField == "Kod")
                List = new ObservableCollection<CargoTypeForView>(List.Where(item => item.Code
           != null && item.Code.Contains(FindTextBox)));
            if (FindField == "Charakterystyka")
                List = new ObservableCollection<CargoTypeForView>(List.Where(item => item.CargoNature
           != null && item.CargoNature.Contains(FindTextBox)));

        }

        #endregion

        public override void load()
        {

            List = new ObservableCollection<CargoTypeForView>
                (
                    from cargo in firmaTransportDBEntities.CargoTypes

                    select new CargoTypeForView
                    {
                        CargoTypeId = cargo.CargoTypeId,
                        Code = cargo.Code,
                        WeightMin = cargo.WeightMin,
                        WeightMax = cargo.WeightMax,
                        Price = cargo.Price,
                        CargoNature = String.Join(", ", (from nature in firmaTransportDBEntities.CargoNatures
                                       where cargo.CargoNatures.Contains(nature)
                                       select nature.Name).ToList()),

                    }
                    );
        }

        public override void remove()
        {
            firmaTransportDBEntities.CargoTypes.Remove((from cargo in firmaTransportDBEntities.CargoTypes
                                                       where cargo.CargoTypeId == RemoveId
                                                       select cargo).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }
    }
}
