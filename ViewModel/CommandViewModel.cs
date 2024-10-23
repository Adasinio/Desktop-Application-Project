﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Firma_Transport.ViewModel
{
    public class CommandViewModel : BaseViewModel
    {
        #region Properties
        public ICommand Command { get; private set; }
        #endregion

        #region Constructor
        public CommandViewModel(string displayName, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException("command");
            DisplayName = displayName;
            Command = command;
        }
        #endregion

    }
}