using Firma_Transport.Model.Entities;
using Firma_Transport.Model.EntitiesForView;
using Firma_Transport.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.Vehicles
{
    internal class NewVehicleViewModel:NewViewModel<Vehicle>, IDataErrorInfo
    {

        #region Constructor
 
        public NewVehicleViewModel():base("Dodaj Pojazd")
        {
            item = new Vehicle();
        }
        #endregion

        #region Properties

        public string Name
        {
            get { return item.Name; }
            set
            {
                if (item.Name != value)
                {
                    item.Name = value;
                    base.OnPropertyChanged(() => Name);
                }
            }
        }
        public string Registration
        {
            get { return item.Registration; }
            set
            {
                if (item.Registration != value)
                {
                    item.Registration = value;
                    base.OnPropertyChanged(() => Registration);
                }
            }
        }
        public short Year
        {
            get { return item.Year; }
            set
            {
                if (item.Year != value)
                {
                    item.Year = value;
                    base.OnPropertyChanged(() => Year);
                }
            }
        }
        public string Make
        {
            get { return item.Make; }
            set
            {
                if (item.Make != value)
                {
                    item.Make = value;
                    base.OnPropertyChanged(() => Make);
                }
            }
        }
        public string Model
        {
            get { return item.Model; }
            set
            {
                if (item.Model != value)
                {
                    item.Model = value;
                    base.OnPropertyChanged(() => Model);
                }
            }
        }
        public string ChassisNumber
        {
            get { return item.ChassisNumber; }
            set
            {
                if (item.ChassisNumber != value)
                {
                    item.ChassisNumber = value;
                    base.OnPropertyChanged(() => ChassisNumber);
                }
            }
        }
        public int VehicleType
        {
            get { return item.VehicleType; }
            set
            {
                if (item.VehicleType != value)
                {
                    item.VehicleType = value;
                    base.OnPropertyChanged(() => VehicleType);
                }
            }
        }

        public IQueryable<VehicleType> VehicleTypesComboBoxItems
        {
            get
            {
                return
                    (
                    from VehicleType in firmaTransportDBEntities.VehicleTypes
                    select VehicleType
                    ).ToList().AsQueryable();
            }
        }

        public bool Repair
        {
            get { return item.Repair; }
            set
            {
                if (item.Repair != value)
                {
                    item.Repair = value;
                    base.OnPropertyChanged(() => Repair);
                }
            }
        }

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
                    case nameof(Name):
                        {
                            HasError = VehicleValidator.ValidateFormatName(Name, out result);
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
