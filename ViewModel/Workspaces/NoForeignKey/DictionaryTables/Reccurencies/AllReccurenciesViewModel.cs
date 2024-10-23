using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.Reccurencies
{
    internal class AllReccurenciesViewModel: AllViewModel<Reccurency>
    {
        #region Contructor
        public AllReccurenciesViewModel()
            : base("Okresy Powtarzania")
        { IdentificationString = "OkresyPowtarzaniaAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Okres Powtarzania", "Opis" };
        }

        public override void sort()
        {
            if (SortField == "Okres Powtarzania")
                List = new ObservableCollection<Reccurency>(List.OrderBy(item => item.Name));
            if (SortField == "Opis")
                List = new ObservableCollection<Reccurency>(List.OrderBy(item => item.Description));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Okres Powtarzania", "Opis" };
        }
        public override void find()
        {
            if (FindField == "Okres Powtarzania")
                List = new ObservableCollection<Reccurency>(List.Where(item => item.Name
           != null && item.Name.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<Reccurency>(List.Where(item => item.Description
           != null && item.Description.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<Reccurency>
                (
                firmaTransportDBEntities.Reccurencies
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Reccurencies.Remove((from r in firmaTransportDBEntities.Reccurencies
                                                       where r.ReccurencyId == RemoveId
                                                       select r).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
