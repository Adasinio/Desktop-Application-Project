using Firma_Transport.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.VehicleTypes
{
    internal class AllVehicleTypesViewModel : AllViewModel<VehicleType>
    {
        #region Contructor
        public AllVehicleTypesViewModel()
            : base("Typy Pojazdów")
        { IdentificationString = "PojazdyTypyAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Typ Pojazdu", "Opis" };
        }

        public override void sort()
        {
            if (SortField == "Typ Pojazdu")
                List = new ObservableCollection<VehicleType>(List.OrderBy(item => item.Name));
            if (SortField == "Opis")
                List = new ObservableCollection<VehicleType>(List.OrderBy(item => item.Description));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Typ Pojazdu", "Opis" };
        }
        public override void find()
        {
            if (FindField == "Typ Pojazdu")
                List = new ObservableCollection<VehicleType>(List.Where(item => item.Name
           != null && item.Name.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<VehicleType>(List.Where(item => item.Description
           != null && item.Description.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<VehicleType>
                (
                firmaTransportDBEntities.VehicleTypes
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.VehicleTypes.Remove((from vt in firmaTransportDBEntities.VehicleTypes
                                                          where vt.VehicleTypeId == RemoveId
                                                          select vt).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }


        #endregion
    }
}
