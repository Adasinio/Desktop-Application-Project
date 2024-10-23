using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.Jobs
{
    internal class AllJobsViewModel : AllViewModel<JobForView>
    {
        #region Contructor
        public AllJobsViewModel()
            : base("Wszystkie Zadania")
        { IdentificationString = "ZadaniaAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Kod Ładunku", "Typ Pasażerski", "Kierowca", "Pojazd", "Okres Powtarzania","Cena","Zniżka" };
        }

        public override void sort()
        {
            if (SortField == "Kod Ładunku")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.CargoCode));
            if (SortField == "Typ Pasażerski")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.PassangerTypeCode));
            if (SortField == "Kierowca")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.DriverName));
            if (SortField == "Pojazd")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.VehicleName));
            if (SortField == "Okres Powtarzania")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.Reccurency));
            if (SortField == "Cena")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.Price));
            if (SortField == "Zniżka")
                List = new ObservableCollection<JobForView>(List.OrderBy(item => item.Discount));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod Ładunku","Typ Pasażerski", "Kierowca", "Pojazd","Okres Powtarzania","Cena","Zniżka"};
        }
        public override void find()
        {
            if (FindField == "Kod Ładunku")
                List = new ObservableCollection<JobForView>(List.Where(item => item.CargoCode
           != null && item.CargoCode.Contains(FindTextBox)));
            if (FindField == "Typ Pasażerski")
                List = new ObservableCollection<JobForView>(List.Where(item => item.PassangerTypeCode
           != null && item.PassangerTypeCode.Contains(FindTextBox)));
            if (FindField == "Kierowca")
                List = new ObservableCollection<JobForView>(List.Where(item => item.DriverName
           != null && item.DriverName.Contains(FindTextBox)));
            if (FindField == "Pojazd")
                List = new ObservableCollection<JobForView>(List.Where(item => item.VehicleName
           != null && item.VehicleName.Contains(FindTextBox)));
            if (FindField == "Okres Powtarzania")
                List = new ObservableCollection<JobForView>(List.Where(item => item.Reccurency
           != null && item.Reccurency.Contains(FindTextBox)));
            if (FindField == "Cena")
                List = new ObservableCollection<JobForView>(List.Where(item => item.Price
           != null && item.Price.Equals(FindTextBox)));
            if (FindField == "Zniżka")
                List = new ObservableCollection<JobForView>(List.Where(item => item.Discount
           != null && item.Discount.Equals(FindTextBox)));

        }

        public override void load()
        {
            List = new ObservableCollection<JobForView>
                (
                    from job in firmaTransportDBEntities.Jobs
                    select new JobForView
                    {
                        JobID= job.JobId,
                        CargoCode= job.CargoTypeNavigation.Code,
                        PassangerTypeCode= job.PassangerTypeNavigation.Code,
                        DriverName=
                        job.JobDriverNavigation.Name+" "+
                        job.JobDriverNavigation.Surname,
                        VehicleName=
                        job.JobVehicleNavigation.Name+"( "+
                        job.JobVehicleNavigation.VehicleTypeNavigation.Name+")",
                        Reccurency= job.ReccurencyNavigation.Name,
                        Price= job.Price,
                        Discount= job.Discount,
                    }
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Jobs.Remove((from j in firmaTransportDBEntities.Jobs
                                                  where j.JobId == RemoveId
                                                      select j).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
