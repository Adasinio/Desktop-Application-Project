using Firma_Transport.Helpers;
using Firma_Transport.Model.Context;
using System.Windows;
using System.Windows.Input;

namespace Firma_Transport.ViewModel
{
    class NewViewModel<T> :WorkspaceViewModel
    {
        #region DB

        protected FirmaTransportDBEntities firmaTransportDBEntities;

        protected T item;

        #endregion

        #region Commands

        private BaseCommand _SaveAndCloseCommand;
        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                    _SaveAndCloseCommand = new BaseCommand(SaveAndClose);
                return _SaveAndCloseCommand;
            }
        }

        #endregion

        #region Constructor
        public NewViewModel(string displayName)
        {
            base.DisplayName = displayName;
            firmaTransportDBEntities = new
                FirmaTransportDBEntities();
        }
        #endregion

        #region Helpers
        public void Save()
        {
            firmaTransportDBEntities.Add(item);
            firmaTransportDBEntities.SaveChanges();
        }

        private void SaveAndClose()
        {
            if(IsValid())
            {
                Save();
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Popraw dane");
            }
        }
        #endregion

        #region Validation

        public virtual bool IsValid()
        {
            return true;
        }

        #endregion
    }
}
