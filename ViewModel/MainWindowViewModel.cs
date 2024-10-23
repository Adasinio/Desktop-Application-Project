using Firma_Transport.Helpers;
using Firma_Transport.ViewModel.Workspaces.CargoTypes;
using Firma_Transport.ViewModel.Workspaces.Clients;
using Firma_Transport.ViewModel.Workspaces.Drivers;
using Firma_Transport.ViewModel.Workspaces.Invoices;
using Firma_Transport.ViewModel.Workspaces.Jobs;
using Firma_Transport.ViewModel.Workspaces.NoForeignKey.Adresses;
using Firma_Transport.ViewModel.Workspaces.NoForeignKey.Availabilities;
using Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.JobTitles;
using Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.Reccurencies;
using Firma_Transport.ViewModel.Workspaces.NoForeignKey.DictionaryTables.VehicleTypes;
using Firma_Transport.ViewModel.Workspaces.NoForeignKey.PassangerTypes;
using Firma_Transport.ViewModel.Workspaces.Routes;
using Firma_Transport.ViewModel.Workspaces.Vehicles;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Firma_Transport.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {

        #region MenuCommands

        public ICommand NewVehicleCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewVehicleViewModel(), true));
            }
        }

        public ICommand AllVehiclesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllVehiclesViewModel()));
            }
        }

        public ICommand NewDriverCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewDriverViewModel(), true));
            }
        }

        public ICommand AllDriversCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllDriversViewModel(), true));
            }
        }

        public ICommand NewInvoiceCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewInvoiceViewModel(), true));
            }
        }

        public ICommand AllInvoicesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllInvoicesViewModel(), true));
            }
        }

        public ICommand NewJobCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewJobViewModel(), true));
            }
        }

        public ICommand AllJobsCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllJobsViewModel(), true));
            }
        }

        public ICommand NewRouteCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewRouteViewModel(), true));
            }
        }

        public ICommand NewPassangerTypeCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewPassangerTypeViewModel(), true));
            }
        }

        public ICommand AllPassangerTypesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllPassangerTypesViewModel(), true));
            }
        }

        public ICommand NewAdressCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewAdressViewModel(), true));
            }
        }

        public ICommand AllAdressesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllAdressesViewModel(), true));
            }
        }

        public ICommand NewAvailabilityCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewAvailabilityViewModel(), true));
            }
        }

        public ICommand AllAvailabilitiesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllAvailabilitiesViewModel(), true));
            }
        }

        public ICommand NewReccurencyCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new NewReccurencyViewModel(), true));
            }
        }

        public ICommand AllReccurenciesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllReccurenciesViewModel(), true));
            }
        }

        public ICommand AllRoutesCommand
        {
            get
            {
                return new BaseCommand(() => ShowView(new AllRoutesViewModel(), true));
            }
        }

        public ICommand CloseAppCommand
        {
            get 
            {
                return new BaseCommand(() =>System.Windows.Application.Current.Shutdown());
            }
        }
        #endregion

        internal void ManageSubmenu(ObservableCollection<CommandViewModel> collection, BaseCommand creator1, string displayname1, BaseCommand creator2, string displayname2, string baseDisplayName)
        {
            var command1 = new CommandViewModel(displayname1, creator1);
            var command2 = new CommandViewModel(displayname2, creator2);
            var check1 = collection.FirstOrDefault(name => name.DisplayName == displayname1);
            var check2 = collection.FirstOrDefault(name => name.DisplayName == displayname2);
            int baseIndex = collection.IndexOf(collection.FirstOrDefault(name => name.DisplayName == baseDisplayName));

            if (check1 == null && check2 == null)
            {
                collection.Insert(baseIndex + 1, command1);
                collection.Insert(baseIndex + 2, command2);
            }
            else
            {
                collection.Remove(collection.FirstOrDefault(name => name.DisplayName == displayname1));
                collection.Remove(collection.FirstOrDefault(name => name.DisplayName == displayname2));
            }
        }

        #region ListCommands
        private ObservableCollection<CommandViewModel> _Commands;
        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                if(_Commands == null)
                {
                    List<CommandViewModel> cmds = CreateCommands();
                    _Commands = new ObservableCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }

        private List<CommandViewModel> CreateCommands() 
        {
            Messenger.Default.Register<string>(this, open);
            return new List<CommandViewModel>
            {
                new CommandViewModel("Zamknij Zakładki", new BaseCommand(ClearWorkspaces)),
                new CommandViewModel("Pojazdy", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewVehicleViewModel(),true)), "Dodaj Pojazd",new BaseCommand(() =>ShowView(new AllVehiclesViewModel())),"Wszystkie Pojazdy","Pojazdy"))),
                new CommandViewModel("Pracownicy", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewDriverViewModel(),true)), "Dodaj Pracownika",new BaseCommand(() =>ShowView(new AllDriversViewModel())),"Wszyscy Pracownicy","Pracownicy"))),
                new CommandViewModel("Faktury", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewInvoiceViewModel(),true)), "Dodaj Fakture",new BaseCommand(() =>ShowView(new AllInvoicesViewModel())),"Wszystkie Faktury","Faktury"))),
                new CommandViewModel("Zadania", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewJobViewModel(),true)), "Dodaj Zadanie",new BaseCommand(() =>ShowView(new AllJobsViewModel())),"Wszystkie Zadania","Zadania"))),
                new CommandViewModel("Trasy", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewRouteViewModel(),true)), "Dodaj Trasę",new BaseCommand(() =>ShowView(new AllRoutesViewModel())),"Wszystkie Trasy","Trasy"))),
                new CommandViewModel("Typy Pasażerskie", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewPassangerTypeViewModel(),true)), "Dodaj Typ Pasażerski",new BaseCommand(() =>ShowView(new AllPassangerTypesViewModel())),"Wszystkie Typy Pasażerskie","Typy Pasażerskie"))),
                new CommandViewModel("Adresy", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewAdressViewModel(),true)), "Dodaj Adres",new BaseCommand(() =>ShowView(new AllAdressesViewModel())),"Wszystkie Adresy","Adresy"))),
                new CommandViewModel("Dostępności", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewAvailabilityViewModel(),true)), "Dodaj Dostępność",new BaseCommand(() =>ShowView(new AllAvailabilitiesViewModel())),"Wszystkie Dostępności","Dostępności"))),
                new CommandViewModel("Okresy Powtarzania", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewReccurencyViewModel(),true)), "Dodaj Okres Powtarzania",new BaseCommand(() =>ShowView(new AllReccurenciesViewModel())),"Wszystkie Okresy Powtarzania","Okresy Powtarzania"))),
                new CommandViewModel("Typy Pojazdu", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewVehicleTypeViewModel(),true)), "Dodaj Typ Pojazdu",new BaseCommand(() =>ShowView(new AllVehicleTypesViewModel())),"Wszystkie Typy Pojazdów","Typy Pojazdu"))),
                new CommandViewModel("Tytyły Pracowników", new BaseCommand(() => ManageSubmenu(Commands,new BaseCommand(() =>ShowView(new NewJobTitleViewModel(),true)), "Dodaj Tytuł Pracownika",new BaseCommand(() =>ShowView(new AllJobTitlesViewModel())),"Wszystkie Tytyły Pracowników","Tytyły Pracowników")))
            };
        }

        private void open(string IdentificationString)
        {
            switch(IdentificationString)
            {
                case "PracownicyAdd":
                    {
                        ShowView(new NewDriverViewModel(), true);
                    }break;
                case "FakturyAdd": 
                    {
                        ShowView(new NewInvoiceViewModel(), true);
                    }break;
                case "ZadaniaAdd":
                    {
                        ShowView(new NewJobViewModel(), true);
                    }
                    break;
                case "PojazdyAdd":
                    {
                        ShowView(new NewVehicleViewModel(), true);
                    }
                    break;
                case "AdresyAdd":
                    {
                        ShowView(new NewAdressViewModel(), true);
                    }
                    break;
                case "PojazdyTypyAdd":
                    {
                        ShowView(new NewVehicleTypeViewModel(), true);
                    }
                    break;
                case "TytulyPracownikaAdd":
                    {
                        ShowView(new NewReccurencyViewModel(), true);
                    }
                    break;
                case "OkresyPowtarzaniaAdd":
                    {
                        ShowView(new NewJobTitleViewModel(), true);
                    }
                    break;
                case "AddressesShow":
                    {
                        ShowView(new AllAdressesViewModel(), true);
                    }
                    break;
                case "ClientsShow":
                    {
                        ShowView(new AllClientsViewModel(), true);
                    }
                    break;
                case "EmployeesShow":
                    {
                        ShowView(new AllDriversViewModel(), true);
                    }
                    break;
                case "RoutesShow":
                    {
                        ShowView(new AllRoutesViewModel(), true);
                    }
                    break;
                case "VehiclesShow":
                    {
                        ShowView(new AllVehiclesViewModel(), true);
                    }
                    break;
                case "CargoTypesShow":
                    {
                        ShowView(new AllCargoTypesViewModel(), true);
                    }
                    break;
                case "PassangerTypesShow":
                    {
                        ShowView(new AllPassangerTypesViewModel(), true);
                    }
                    break;

            }
        }

        #endregion

        #region Workspaces

        private ObservableCollection<WorkspaceViewModel> _Workspaces;

        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null) 
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        #endregion

        #region Zakładki
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Funkcje wywołujące zakadki

        private void ClearWorkspaces()
        { Workspaces.Clear(); }

        private void ShowView<T>(T workspaceViewModel, bool allowMulti = false)
        {
            var workspace = Workspaces.FirstOrDefault(vm => vm.GetType() == workspaceViewModel.GetType());

            if (workspace == null || allowMulti) 
            {
                workspace = workspaceViewModel as WorkspaceViewModel;
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion

    }
}
