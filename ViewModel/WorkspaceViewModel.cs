 using Firma_Transport.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma_Transport.ViewModel
{
    public class WorkspaceViewModel : BaseViewModel
    {
        #region Pola i właściwości
        public string DisplayName { get; set; }

        private BaseCommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(OnRequestClose);
                return _CloseCommand;
            }
        }
        #endregion

        #region RequestClose [event]
        public event EventHandler RequestClose;
        protected void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion

    }
}
