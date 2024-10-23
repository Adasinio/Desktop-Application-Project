using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.JobTitles
{
        internal class AllJobTitlesViewModel : AllViewModel<JobTitle>
        {
            #region Contructor
            public AllJobTitlesViewModel()
                : base("Tytuły Pracowników")
            { IdentificationString = "TytulyPracownikaAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Tytuł Pracowniczy", "Opis" };
        }

        public override void sort()
        {
            if (SortField == "Tytuł Pracowniczy")
                List = new ObservableCollection<JobTitle>(List.OrderBy(item => item.Name));
            if (SortField == "Opis")
                List = new ObservableCollection<JobTitle>(List.OrderBy(item => item.Description));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Tytuł Pracowniczy", "Opis" };
        }
        public override void find()
        {
            if (FindField == "Tytuł Pracowniczy")
                List = new ObservableCollection<JobTitle>(List.Where(item => item.Name
           != null && item.Name.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<JobTitle>(List.Where(item => item.Description
           != null && item.Description.Contains(FindTextBox)));
        }

        public override void load()
            {
                List = new ObservableCollection<JobTitle>
                    (
                    firmaTransportDBEntities.JobTitles
                    );
            }

        public override void remove()
        {
            firmaTransportDBEntities.JobTitles.Remove((from jt in firmaTransportDBEntities.JobTitles
                                                       where jt.JobTitleId == RemoveId
                                                            select jt).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
