using Firma_Transport.Helpers;
using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel.Workspaces.NoForeignKey.PassangerTypes
{
    internal class AllPassangerTypesViewModel: AllViewModel<PassangerType>
    {

        #region Commands

        private PassangerType _SelectedPassangerType;

        public PassangerType SelectedPassangerType
        {
            set
            {
                if (_SelectedPassangerType != value)
                {
                    _SelectedPassangerType = value;
                    Messenger.Default.Send(_SelectedPassangerType);
                    OnRequestClose();
                }

            }
            get
            {
                return _SelectedPassangerType;
            }
        }

        #endregion

        #region Contructor
        public AllPassangerTypesViewModel() 
            :base("Typy Pasażerskie")
        { }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Kod", "OsóbMin", "OsóbMax","BagażMin","BagażMax","Przystępność","Cena" };
        }

        public override void sort()
        {
            if (SortField == "Kod")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.Code));
            if (SortField == "OsóbMin")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.NumberMin));
            if (SortField == "OsóbMax")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.NumberMax));
            if (SortField == "BagażMin")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.LuggageWeightMin));
            if (SortField == "BagażMax")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.LuggageWeightMax));
            if (SortField == "Przystępność")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.Accessibility));
            if (SortField == "Cena")
                List = new ObservableCollection<PassangerType>(List.OrderBy(item => item.Price));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod", "OsóbMin", "OsóbMax", "BagażMin", "BagażMax", "Cena" };
        }
        public override void find()
        {
            if (FindField == "Typ Pojazdu")
                List = new ObservableCollection<PassangerType>(List.Where(item => item.Code
           != null && item.Code.Contains(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PassangerType>(List.Where(item => item.NumberMin
           != null && item.NumberMin.Equals(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PassangerType>(List.Where(item => item.NumberMax
           != null && item.NumberMax.Equals(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PassangerType>(List.Where(item => item.LuggageWeightMin
           != null && item.LuggageWeightMin.Equals(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PassangerType>(List.Where(item => item.LuggageWeightMax
           != null && item.LuggageWeightMax.Equals(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<PassangerType>(List.Where(item => item.Price
           != null && item.Price.Equals(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<PassangerType>
                (
                firmaTransportDBEntities.PassangerTypes
                );
        }


        public override void remove()
        {
            firmaTransportDBEntities.PassangerTypes.Remove((from pt in firmaTransportDBEntities.PassangerTypes
                                                            where pt.PassangerTypeId == RemoveId
                                                          select pt).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }



        #endregion
    }
}
