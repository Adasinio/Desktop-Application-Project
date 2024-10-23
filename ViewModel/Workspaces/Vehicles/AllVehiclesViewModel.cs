using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.Vehicles
{
    internal class AllVehiclesViewModel:AllViewModel<VehicleForView>
    {

        #region Commands

        private VehicleForView _SelectedVehicle;

        public VehicleForView SelectedVehicle
        {
            set
            {
                if (_SelectedVehicle != value)
                {
                    _SelectedVehicle = value;
                    Messenger.Default.Send(_SelectedVehicle);
                    OnRequestClose();
                }

            }
            get
            {
                return _SelectedVehicle;
            }
        }

        #endregion


        #region Contructor

        public AllVehiclesViewModel():base("Wszystkie Pojazdy")
        {
            IdentificationString = "PojazdyAdd";
        }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Numer Rejestracyjny", "Rocznik", "Marka",
                                    "Model", "Numer Podwozia", "Typ Pojazdu","W naprawie" };
        }

        public override void sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.Name));
            if (SortField == "Numer Rejestracyjny")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.Registration));
            if (SortField == "Rocznik")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.Year));
            if (SortField == "Marka")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.Make));
            if (SortField == "Model")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.Model));
            if (SortField == "Numer Podwozia")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.ChassisNumber));
            if (SortField == "Typ Pojazdu")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.VehicleType));
            if (SortField == "W naprawie")
                List = new ObservableCollection<VehicleForView>(List.OrderBy(item => item.Repair));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa", "Numer Rejestracyjny", "Rocznik", "Marka",
                                    "Model", "Numer Podwozia", "Typ Pojazdu"};
        }
        public override void find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.Name
           != null && item.Name.Contains(FindTextBox)));
            if (FindField == "Numer Rejestracyjny")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.Registration
           != null && item.Registration.Contains(FindTextBox)));
            if (FindField == "Rocznik")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.Year
           != null && item.Year.Equals(FindTextBox)));
            if (FindField == "Marka")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.Make
           != null && item.Make.Contains(FindTextBox)));
            if (FindField == "Model")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.Model
           != null && item.Model.Contains(FindTextBox)));
            if (FindField == "Numer Podwozia")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.ChassisNumber
           != null && item.ChassisNumber.Contains(FindTextBox)));
            if (FindField == "Typ Pojazdu")
                List = new ObservableCollection<VehicleForView>(List.Where(item => item.VehicleType
           != null && item.VehicleType.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<VehicleForView>
                (
                    from vehicle in firmaTransportDBEntities.Vehicles
                    select new VehicleForView
                    {
                        VehicleID=vehicle.VehicleId,
                        Name=vehicle.Name,
                        Registration=vehicle.Registration,
                        Year=vehicle.Year,
                        Make=vehicle.Make,
                        Model=vehicle.Model,
                        ChassisNumber=vehicle.ChassisNumber,
                        VehicleType=vehicle.VehicleTypeNavigation.Name,
                        Repair=vehicle.Repair,
                    }
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Vehicles.Remove((from v in firmaTransportDBEntities.Vehicles
                                                      where v.VehicleId == RemoveId
                                                    select v).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
