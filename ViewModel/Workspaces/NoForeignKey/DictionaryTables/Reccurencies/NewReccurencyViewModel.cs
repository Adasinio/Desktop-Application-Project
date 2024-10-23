using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.Reccurencies
{
    internal class NewReccurencyViewModel: NewViewModel<Reccurency>
    {

        #region Constructor

        public NewReccurencyViewModel():base("Dodaj Okres Powtarzania")
        {
            item = new Reccurency();
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
