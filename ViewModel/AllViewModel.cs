using Firma_Transport.Helpers;
using Firma_Transport.Model.Context;
using Firma_Transport.Model.Entities;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel
{
    public abstract class AllViewModel<T>: WorkspaceViewModel
    {

        #region DB
        protected readonly FirmaTransportDBEntities firmaTransportDBEntities;
        protected T removeditem;
        #endregion

        #region Command
        private BaseCommand _LoadCommand;

        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }

        private BaseCommand _AddCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }

        private BaseCommand _RemoveCommand;

        public ICommand RemoveCommand
        {
            get
            {
                if (_RemoveCommand == null)
                {
                    _RemoveCommand = new BaseCommand(() => remove());
                }
                return _RemoveCommand;
            }
        }

        private BaseCommand _SortCommand;

        private BaseCommand _FindCommand;

        #endregion
        #region Collection
        private ObservableCollection<T> _List;

        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                {
                    load();
                }
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        public string SortField { get; set; }

        public List<string> SortComboboxItems
        {
            get 
            {
                return getComboboxSortList();
            }
        }

        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => sort());
                }
                return _SortCommand;
            }
        }

        public string FindField { get; set; }

        public string FindTextBox { get; set; }

        public int RemoveId { get; set; }

        public List<string> FindComboboxItems
        {
            get
            {
                return getComboboxFindList();
            }
        }

        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => find());
                }
                return _FindCommand;
            }
        }


        #endregion

        #region Helpers

        public abstract void load();

        public abstract void remove();

        public abstract void sort();
        public abstract List<string> getComboboxSortList();

        public abstract void find();
        public abstract List<string> getComboboxFindList();

        public string IdentificationString { get; set; }

        private void add()
        {
            Messenger.Default.Send(this.IdentificationString);
        }

        #endregion

        #region Constructor

        public AllViewModel(string displayName)
        {
            base.DisplayName = displayName;
            firmaTransportDBEntities = new FirmaTransportDBEntities();
        }

        #endregion
    }
}
