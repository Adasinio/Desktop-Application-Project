using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.Routes
{
    internal class AllRoutesViewModel: AllViewModel<RouteForView>
    {

        #region Commands

        private RouteForView _SelectedRoute;

        public RouteForView SelectedRoute
        {
            set
            {
                if (_SelectedRoute != value)
                {
                    _SelectedRoute = value;
                    Messenger.Default.Send(_SelectedRoute);
                    OnRequestClose();
                }
            }
            get
            {
                return _SelectedRoute;
            }
        }

        #endregion

        #region Constructor
        public AllRoutesViewModel()
            :base("Wszystkie Trasy") 
        { IdentificationString = "TrasyAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Długość Trasy", "Czas Przebycia", "Punkt Startowy","Punkt Końcowy"};
        }

        public override void sort()
        {
            if (SortField == "Długość Trasy")
                List = new ObservableCollection<RouteForView>(List.OrderBy(item => item.Lenght));
            if (SortField == "Czas Przebycia")
                List = new ObservableCollection<RouteForView>(List.OrderBy(item => item.EstimatedDuration));
            if (SortField == "Punkt Startowy")
                List = new ObservableCollection<RouteForView>(List.OrderBy(item => item.StartLocation));
            if (SortField == "Punkt Końcowy")
                List = new ObservableCollection<RouteForView>(List.OrderBy(item => item.EndLocation));
        }

        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Długość Trasy", "Czas Przebycia", "Punkt Startowy", "Punkt Końcowy" };
        }

        public override void find()
        {
            if (FindField == "Długość Trasy")
                List = new ObservableCollection<RouteForView>(List.Where(item => item.Lenght
           != null && item.Lenght.Contains(FindTextBox)));
            if (FindField == "Czas Przebycia")
                List = new ObservableCollection<RouteForView>(List.Where(item => item.EstimatedDuration
           != null && item.EstimatedDuration.Contains(FindTextBox)));
            if (FindField == "Punkt Startowy")
                List = new ObservableCollection<RouteForView>(List.Where(item => item.StartLocation
           != null && item.StartLocation.Contains(FindTextBox)));
            if (FindField == "Punkt Końcowy")
                List = new ObservableCollection<RouteForView>(List.Where(item => item.EndLocation
           != null && item.EndLocation.Contains(FindTextBox)));

        }

        public override void load()
        {

            List = new ObservableCollection<RouteForView>
                (
                    from route in firmaTransportDBEntities.Routes
                    select new RouteForView
                    {
                        RouteId = route.RouteId,
                        Lenght = route.Lenght,
                        EstimatedDuration = route.EstimatedDuration,

                        StartLocation = 
                                (from r in firmaTransportDBEntities.Routes
                                join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                where stop.StartLocation == true
                                select adress.City).FirstOrDefault() + " " +

                                (from r in firmaTransportDBEntities.Routes
                                 join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                 join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                 where stop.StartLocation == true
                                 select adress.Street).FirstOrDefault() + " " +

                                 (from r in firmaTransportDBEntities.Routes
                                  join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                  join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                  where stop.StartLocation == true
                                  select adress.Building).FirstOrDefault() + " " +

                                  (from r in firmaTransportDBEntities.Routes
                                   join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                   join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                   where stop.StartLocation == true
                                   select adress.PostalCode).FirstOrDefault() + " ",

                        EndLocation = 
                                (from r in firmaTransportDBEntities.Routes
                                join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                where stop.EndLocation == true
                                select adress.City).FirstOrDefault() + " " +

                                (from r in firmaTransportDBEntities.Routes
                                 join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                 join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                 where stop.EndLocation == true
                                 select adress.Street).FirstOrDefault() + " " +

                                 (from r in firmaTransportDBEntities.Routes
                                  join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                  join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                  where stop.EndLocation == true
                                  select adress.Building).FirstOrDefault() + " " +

                                  (from r in firmaTransportDBEntities.Routes
                                   join stop in firmaTransportDBEntities.RouteStops on route.RouteId equals stop.RouteId
                                   join adress in firmaTransportDBEntities.Addresses on stop.AddressId equals adress.AddressId
                                   where stop.EndLocation == true
                                   select adress.PostalCode).FirstOrDefault() + " ",

                    }
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Routes.Remove((from r in firmaTransportDBEntities.Routes
                                                    where r.RouteId == RemoveId
                                                            select r).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion

    }
}
