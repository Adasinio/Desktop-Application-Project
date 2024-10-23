using System;
using Firma_Transport.Helpers;
using Firma_Transport.Model.BusinessLogic;
using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Firma_Transport.Validators;

namespace Firma_Transport.ViewModel.Workspaces.Jobs
{
    internal class NewJobViewModel: NewViewModel<Job>, IDataErrorInfo
    {

        #region Commands

        private BaseCommand _ShowEmployeesCommand;

        public ICommand ShowEmployeesCommand
        {
            get
            {
                if (_ShowEmployeesCommand == null)
                {
                    _ShowEmployeesCommand = new BaseCommand(() =>
                    Messenger.Default.Send("EmployeesShow"));
                }
                return _ShowEmployeesCommand;
            }
        }

        private BaseCommand _ShowRoutesCommand;

        public ICommand ShowRoutesCommand
        {
            get
            {
                if (_ShowRoutesCommand == null)
                {
                    _ShowRoutesCommand = new BaseCommand(() =>
                    Messenger.Default.Send("RoutesShow"));
                }
                return _ShowRoutesCommand;
            }
        }

        private BaseCommand _ShowVehiclesCommand;

        public ICommand ShowVehiclesCommand
        {
            get
            {
                if (_ShowVehiclesCommand == null)
                {
                    _ShowVehiclesCommand = new BaseCommand(() =>
                    Messenger.Default.Send("VehiclesShow"));
                }
                return _ShowVehiclesCommand;
            }
        }

        private BaseCommand _ShowCargoTypesCommand;

        public ICommand ShowCargoTypesCommand
        {
            get
            {
                if (_ShowCargoTypesCommand == null)
                {
                    _ShowCargoTypesCommand = new BaseCommand(() =>
                    Messenger.Default.Send("CargoTypesShow"));
                }
                return _ShowCargoTypesCommand;
            }
        }

        private BaseCommand _ShowPassangerTypesCommand;

        public ICommand ShowPassangerTypesCommand
        {
            get
            {
                if (_ShowPassangerTypesCommand == null)
                {
                    _ShowPassangerTypesCommand = new BaseCommand(() =>
                    Messenger.Default.Send("PassangerTypesShow"));
                }
                return _ShowPassangerTypesCommand;
            }
        }

        private BaseCommand _CalculateJobPriceCommand;

        public ICommand CalculateJobPriceCommand
        {
            get
            {
                if (_CalculateJobPriceCommand == null)
                {
                    _CalculateJobPriceCommand = new BaseCommand(() => CalculateJobPrice());
                   
                }
                return _CalculateJobPriceCommand;
            }
        }

        private void CalculateJobPrice()
        {
            Price = new JobB(firmaTransportDBEntities).JobPrice(PassangerPrice, CargoPrice, Discount);
        }

        #endregion

        #region Constructor

        public NewJobViewModel() : base("Dodaj Zadanie")
        {
            item = new Job();
            Messenger.Default.Register<EmployeeForView>(this, getSelectedEmployee);
            Messenger.Default.Register<RouteForView>(this, getSelectedRoute);
            Messenger.Default.Register<VehicleForView>(this, getSelectedVehicle);
            Messenger.Default.Register<PassangerType>(this, getSelectedPassangerType);
            Messenger.Default.Register<CargoTypeForView>(this, getSelectedCargoType);
        }

        #endregion

        #region Helpers

        private void getSelectedEmployee(EmployeeForView employee)
        {
            JobDriver = employee.EmployeeID;
            DriverName = employee.Name;
            DriverSurname = employee.Surname;
            DriverPhoneNumber = employee.Phone;
        }

        private void getSelectedRoute(RouteForView route)
        {
            JobRoute = route.RouteId;
            RouteLenght = route.Lenght;
            RouteDuration = route.EstimatedDuration;
            RouteStartingLocation = route.StartLocation;
            RouteEndingLocation = route.EndLocation;
        }

        private void getSelectedVehicle(VehicleForView vehicle)
        {
            JobVehicle = vehicle.VehicleID;
            VehicleMake = vehicle.Make;
            VehicleModel = vehicle.Model;
            VehicleYear = vehicle.Year;
        }


        private void getSelectedPassangerType(PassangerType passangerType)
        {
            PassangerType = passangerType.PassangerTypeId;
            NumberMin = passangerType.NumberMin;
            NumberMax = passangerType.NumberMax;
            LuggageWeightMin = passangerType.LuggageWeightMin;
            LuggageWeightMax = passangerType.LuggageWeightMax;
            PassangerPrice = passangerType.Price;
            if (passangerType.Accessibility == true)
                Accessibility = "Wymagana";
            else
                Accessibility = "Nie Wymagana";


        }


        private void getSelectedCargoType(CargoTypeForView cargoType)
        {
            CargoType = cargoType.CargoTypeId;
            WeightMin = cargoType.WeightMin;
            WeightMax = cargoType.WeightMax;
            CargoNature = cargoType.CargoNature;
            CargoPrice = cargoType.Price;
        }



        #endregion

        #region Properties

        #region Driver

        public int? JobDriver
        {
            get { return item.JobDriver; }
            set
            {
                if (item.JobDriver != value)
                {
                    item.JobDriver = value;
                    base.OnPropertyChanged(() => JobDriver);
                }
            }
        }


        private string? _DriverName;
        public string? DriverName
        {
            get { return _DriverName; }
            set
            {
                if (_DriverName != value)
                {
                    _DriverName = value;
                    base.OnPropertyChanged(() => _DriverName);
                }
            }
        }

        private string? _DriverSurname;
        public string? DriverSurname
        {
            get { return _DriverSurname; }
            set
            {
                if (_DriverSurname != value)
                {
                    _DriverSurname = value;
                    base.OnPropertyChanged(() => _DriverSurname);
                }
            }
        }

        private string? _DriverPhoneNumber;
        public string? DriverPhoneNumber
        {
            get { return _DriverPhoneNumber; }
            set
            {
                if (_DriverPhoneNumber != value)
                {
                    _DriverPhoneNumber = value;
                    base.OnPropertyChanged(() => _DriverPhoneNumber);
                }
            }
        }
        #endregion

        #region Vehicle

        public int? JobVehicle
        {
            get { return item.JobVehicle; }
            set
            {
                if (item.JobVehicle != value)
                {
                    item.JobVehicle = value;
                    base.OnPropertyChanged(() => JobVehicle);
                }
            }
        }

        private string? _VehicleMake;
        public string? VehicleMake
        {
            get { return _VehicleMake; }
            set
            {
                if (_VehicleMake != value)
                {
                    _VehicleMake = value;
                    base.OnPropertyChanged(() => _VehicleMake);
                }
            }
        }

        private string? _VehicleModel;
        public string? VehicleModel
        {
            get { return _VehicleModel; }
            set
            {
                if (_VehicleModel != value)
                {
                    _VehicleModel = value;
                    base.OnPropertyChanged(() => _VehicleModel);
                }
            }
        }


        private short _VehicleYear;
        public short VehicleYear
        {
            get { return _VehicleYear; }
            set
            {
                if (_VehicleYear != value)
                {
                    _VehicleYear = value;
                    base.OnPropertyChanged(() => _VehicleYear);
                }
            }
        }

        #endregion

        #region Route

        public int? JobRoute
        {
            get { return item.JobRoute; }
            set
            {
                if (item.JobRoute != value)
                {
                    item.JobRoute = value;
                    base.OnPropertyChanged(() => JobRoute);
                }
            }
        }

        private string? _RouteLenght;
        public string? RouteLenght
        {
            get { return _RouteLenght; }
            set
            {
                if (_RouteLenght != value)
                {
                    _RouteLenght = value;
                    base.OnPropertyChanged(() => _RouteLenght);
                }
            }
        }

        private string? _RouteDuration;
        public string? RouteDuration
        {
            get { return _RouteDuration; }
            set
            {
                if (_RouteDuration != value)
                {
                    _RouteDuration = value;
                    base.OnPropertyChanged(() => _RouteDuration);
                }
            }
        }

        private string? _RouteStartingLocation;
        public string? RouteStartingLocation
        {
            get { return _RouteStartingLocation; }
            set
            {
                if (_RouteStartingLocation != value)
                {
                    _RouteStartingLocation = value;
                    base.OnPropertyChanged(() => _RouteStartingLocation);
                }
            }
        }

        private string? _RouteEndingLocation;
        public string? RouteEndingLocation
        {
            get { return _RouteEndingLocation; }
            set
            {
                if (_RouteEndingLocation != value)
                {
                    _RouteEndingLocation = value;
                    base.OnPropertyChanged(() => _RouteEndingLocation);
                }
            }
        }

        #endregion

        #region PassangerType

        public int? PassangerType
        {
            get { return item.PassangerType; }
            set
            {
                if (item.PassangerType != value)
                {
                    item.PassangerType = value;
                    base.OnPropertyChanged(() => PassangerType);
                }
            }
        }

        private int? _NumberMin;
        public int? NumberMin
        {
            get { return _NumberMin; }
            set
            {
                if (_NumberMin != value)
                {
                    _NumberMin = value;
                    base.OnPropertyChanged(() => _NumberMin);
                }
            }
        }

        private int? _NumberMax;
        public int? NumberMax
        {
            get { return _NumberMax; }
            set
            {
                if (_NumberMax != value)
                {
                    _NumberMax = value;
                    base.OnPropertyChanged(() => _NumberMax);
                }
            }
        }

        private double? _LuggageWeightMin;
        public double? LuggageWeightMin
        {
            get { return _LuggageWeightMin; }
            set
            {
                if (_LuggageWeightMin != value)
                {
                    _LuggageWeightMin = value;
                    base.OnPropertyChanged(() => _LuggageWeightMin);
                }
            }
        }

        private double? _LuggageWeightMax;
        public double? LuggageWeightMax
        {
            get { return _LuggageWeightMax; }
            set
            {
                if (_LuggageWeightMax != value)
                {
                    _LuggageWeightMax = value;
                    base.OnPropertyChanged(() => _LuggageWeightMax);
                }
            }
        }

        private decimal? _PassangerPrice;
        public decimal? PassangerPrice
        {
            get { return _PassangerPrice; }
            set
            {
                if (_PassangerPrice != value)
                {
                    _PassangerPrice = value;
                    base.OnPropertyChanged(() => _PassangerPrice);
                }
            }
        }

        private string _Accessibility;

        public string Accessibility
        {
            get { return _Accessibility; }
            set
            {
                if (_Accessibility != value)
                {
                    _Accessibility = value;
                    base.OnPropertyChanged(() => _Accessibility);
                }
            }
        }
        #endregion

        #region CargoType

        public int? CargoType
        {
            get { return item.CargoType; }
            set
            {
                if (item.CargoType != value)
                {
                    item.CargoType = value;
                    base.OnPropertyChanged(() => CargoType);
                }
            }
        }

        private double? _WeightMin;
        public double? WeightMin
        {
            get { return _WeightMin; }
            set
            {
                if (_WeightMin != value)
                {
                    _WeightMin = value;
                    base.OnPropertyChanged(() => _WeightMin);
                }
            }
        }

        private double? _WeightMax;
        public double? WeightMax
        {
            get { return _WeightMax; }
            set
            {
                if (_WeightMax != value)
                {
                    _WeightMax = value;
                    base.OnPropertyChanged(() => _WeightMax);
                }
            }
        }

        private string? _CargoNature;
        public string? CargoNature
        {
            get { return _CargoNature; }
            set
            {
                if (_CargoNature != value)
                {
                    _CargoNature = value;
                    base.OnPropertyChanged(() => _CargoNature);
                }
            }
        }

        private decimal? _CargoPrice;
        public decimal? CargoPrice
        {
            get { return _CargoPrice; }
            set
            {
                if (_CargoPrice != value)
                {
                    _CargoPrice = value;
                    base.OnPropertyChanged(() => _CargoPrice);
                }
            }
        }


        #endregion

        #region Cost

        public int? Reccurency
        {
            get { return item.Reccurency; }
            set
            {
                if (item.Reccurency != value)
                {
                    item.Reccurency = value;
                    base.OnPropertyChanged(() => Reccurency);
                }
            }
        }
        public IQueryable<Reccurency> ReccurenciesComboBoxItems
        {
            get
            {
                return
                    (
                    from Reccurency in firmaTransportDBEntities.Reccurencies
                    select Reccurency
                    ).ToList().AsQueryable();
            }
        }


        public float? Discount
        {
            get { return item.Discount; }
            set
            {
                if (item.Discount != value)
                {
                    item.Discount = value;
                    Price = null;
                    base.OnPropertyChanged(() => Discount);
                }
            }
        }

        public decimal? Price
        {
            get { return item.Price; }
            set
            {
                if (item.Price != value)
                {
                    item.Price = value;
                    base.OnPropertyChanged(() => Price);
                }
            }
        }

        #endregion



        #endregion

        #region Validation

        public bool HasError { get; set; } = false;
        public string Error => string.Empty;

        public string this[string fieldName]
        {
            get
            {
                var result = string.Empty;
                switch (fieldName)
                {
                    case nameof(Discount):
                        {
                            HasError = JobValidator.ValidateDiscountFormat(Discount, out result);
                            break;
                        }
                    case nameof(Price):
                        {
                            HasError = JobValidator.ValidatePricePresence(Price, out result);
                            break;
                        }
                }
                return result;
            }
        }

        public override bool IsValid()
        {
            return !HasError;
        }
        #endregion
    }
}
