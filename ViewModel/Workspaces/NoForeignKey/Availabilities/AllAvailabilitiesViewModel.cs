using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.Availabilities
{
    internal class AllAvailabilitiesViewModel: AllViewModel<Availability>
    {
        #region Contructor
        public AllAvailabilitiesViewModel()
            : base("Wszystkie Dostępności")
        { }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Kod", "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piatek", "Sobota", "Niedziela" };
        }

        public override void sort()
        {
            if (SortField == "Kod")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Code));
            if (SortField == "Poniedziałek")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Monday));
            if (SortField == "Wtorek")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Tuesday));
            if (SortField == "Środa")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Wednesday)); 
            if (SortField == "Czwartek")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Thursday));
            if (SortField == "Piatek")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Friday));
            if (SortField == "Sobota")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Saturday));
            if (SortField == "Niedziela")
                List = new ObservableCollection<Availability>(List.OrderBy(item => item.Sunday));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod"};
        }
        public override void find()
        {
            if (FindField == "Kod")
                List = new ObservableCollection<Availability>(List.Where(item => item.Code
           != null && item.Code.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<Availability>
                (
                firmaTransportDBEntities.Availabilities
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Availabilities.Remove((from a in firmaTransportDBEntities.Availabilities
                                                       where a.AvailabilityId == RemoveId
                                                       select a).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
