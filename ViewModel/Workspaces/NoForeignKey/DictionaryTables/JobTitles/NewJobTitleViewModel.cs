using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.JobTitles
{
    internal class NewJobTitleViewModel : NewViewModel<JobTitle>
    {

        #region Constructor

        public NewJobTitleViewModel() : base("Dodaj Tytuł Pracownika")
        {
            item = new JobTitle();
        }

        #endregion

        #region Data

        public string Name
        {
            get
            {
                return item.Name;
            }
            set
            {
                if (item.Name != value)
                {
                    item.Name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        public string? Description
        {
            get
            {
                return item.Description;
            }
            set
            {
                if (item.Description != value)
                {
                    item.Description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        #endregion
    }
}
