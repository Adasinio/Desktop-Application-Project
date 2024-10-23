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

namespace Firma_Transport.ViewModel.Workspaces.Drivers
{
    internal class AllDriversViewModel : AllViewModel<EmployeeForView>
    {

        #region Commands

        private EmployeeForView _SelectedEmployee;

        public EmployeeForView SelectedEmployee
        {
            set
            {
                if (_SelectedEmployee != value)
                {
                    _SelectedEmployee = value;
                    Messenger.Default.Send(_SelectedEmployee);
                    OnRequestClose();
                }

            }
            get
            {
                return _SelectedEmployee;
            }
        }

        #endregion

        #region Contructor
        public AllDriversViewModel()
            : base("Wszyscy Pracownicy")
        { IdentificationString = "PracownicyAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Imię", "Nazwisko", "Nr Telefonu", "Tytuł", "Forma Zatrudnienia",
                                    "Adres Zamieszkania","Dostępność"};
        }

        public override void sort()
        {
            if (SortField == "Imię")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.Name));
            if (SortField == "Nazwisko")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.Surname));
            if (SortField == "Nr Telefonu")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.Phone));
            if (SortField == "Tytuł")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.JobTitle));
            if (SortField == "Forma Zatrudnienia")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.EmploymentForm));
            if (SortField == "Adres Zamieszkania")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.Address));
            if (SortField == "Dostępność")
                List = new ObservableCollection<EmployeeForView>(List.OrderBy(item => item.Availability));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Imię", "Nazwisko", "Nr Telefonu", "Tytuł", "Forma Zatrudnienia",
                                    "Adres Zamieszkania","Dostępność"};
        }
        public override void find()
        {
            if (FindField == "Imię")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.Name
           != null && item.Name.Contains(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.Surname
           != null && item.Surname.Contains(FindTextBox)));
            if (FindField == "Nr Telefonu")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.Phone
           != null && item.Phone.Contains(FindTextBox)));
            if (FindField == "Tytuł")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.JobTitle
           != null && item.JobTitle.Contains(FindTextBox)));
            if (FindField == "Forma Zatrudnienia")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.EmploymentForm
           != null && item.EmploymentForm.Contains(FindTextBox)));
            if (FindField == "Adres Zamieszkania")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.Address
           != null && item.Address.Contains(FindTextBox)));
            if (FindField == "Dostępność")
                List = new ObservableCollection<EmployeeForView>(List.Where(item => item.Availability
           != null && item.Availability.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<EmployeeForView>
                (
                    from employee in firmaTransportDBEntities.Employees
                    select new EmployeeForView
                    {
                        EmployeeID=employee.EmployeeId,
                        Name=employee.Name,
                        Surname=employee.Surname,
                        Phone=employee.Phone,
                        JobTitle=employee.JobTitleNavigation.Name,
                        EmploymentForm=employee.EmploymentFormNavigation.Name,
                        Address=employee.AddressNavigation.City+" "+
                                employee.AddressNavigation.Street+" "+
                                employee.AddressNavigation.Building+" "+
                                employee.AddressNavigation.PostalCode,
                        Availability=employee.AvailabilityNavigation.Code
                    }
                );
        }

        public override void remove()
        {
            firmaTransportDBEntities.Employees.Remove((from e in firmaTransportDBEntities.Employees
                                                     where e.EmployeeId == RemoveId
                                                     select e).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }
        #endregion
    }
}
