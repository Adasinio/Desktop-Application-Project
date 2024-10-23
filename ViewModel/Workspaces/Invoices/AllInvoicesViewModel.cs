using Firma_Transport.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma_Transport.ViewModel.Workspaces.Invoices
{
    internal class AllInvoicesViewModel : AllViewModel<InvoiceForView>
    {
        #region Contructor
        public AllInvoicesViewModel()
            : base("Wszystkie Faktury")
        { IdentificationString = "FakturyAdd"; }

        #endregion

        #region Helpers

        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Kontrahent", "Identyfikacja Kontrahenta", "Data Wystawienia", "Termin do Opłacenia",
                "Termin Opłacenia","Metoda Płatności"};
        }

        public override void sort()
        {
            if (SortField == "Kontrahent")
                List = new ObservableCollection<InvoiceForView>(List.OrderBy(item => item.ClientName));
            if (SortField == "Identyfikacja Kontrahenta")
                List = new ObservableCollection<InvoiceForView>(List.OrderBy(item => item.ClientNumber));
            if (SortField == "Data Wystawienia")
                List = new ObservableCollection<InvoiceForView>(List.OrderBy(item => item.InvoiceDate));
            if (SortField == "Termin do Opłacenia")
                List = new ObservableCollection<InvoiceForView>(List.OrderBy(item => item.DueDate));
            if (SortField == "Termin Opłacenia")
                List = new ObservableCollection<InvoiceForView>(List.OrderBy(item => item.PaidDate));
            if (SortField == "Metoda Płatności")
                List = new ObservableCollection<InvoiceForView>(List.OrderBy(item => item.PaymentMethod));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kontrahent", "Identyfikacja Kontrahenta", "Data Wystawienia", "Termin do Opłacenia",
                "Termin Opłacenia","Metoda Płatności"};
        }
        public override void find()
        {
            if (FindField == "Imię")
                List = new ObservableCollection<InvoiceForView>(List.Where(item => item.ClientName
           != null && item.ClientName.Contains(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<InvoiceForView>(List.Where(item => item.ClientNumber
           != null && item.ClientNumber.Contains(FindTextBox)));
            if (FindField == "Nr Telefonu")
                List = new ObservableCollection<InvoiceForView>(List.Where(item => item.InvoiceDate
           != null && item.InvoiceDate.ToLongDateString().Contains(FindTextBox)));
            if (FindField == "Tytuł")
                List = new ObservableCollection<InvoiceForView>(List.Where(item => item.DueDate
           != null && item.DueDate.ToLongDateString().Contains(FindTextBox)));
            if (FindField == "Forma Zatrudnienia")
                List = new ObservableCollection<InvoiceForView>(List.Where(item => item.PaidDate
           != null && item.PaidDate.ToString().Contains(FindTextBox)));
            if (FindField == "Adres Zamieszkania")
                List = new ObservableCollection<InvoiceForView>(List.Where(item => item.PaymentMethod
           != null && item.PaymentMethod.Contains(FindTextBox)));
        }

        public override void load()
        {
            List = new ObservableCollection<InvoiceForView>
                (
                    from invoice in firmaTransportDBEntities.Invoices
                    select new InvoiceForView
                    {
                        InvoiceID= invoice.InvoiceId,
                        ClientName= invoice.ClientNavigation.Name+" "+invoice.ClientNavigation.Surname,
                        ClientNumber = invoice.ClientNavigation.Nip+invoice.ClientNavigation.Pesel,
                        InvoiceDate= invoice.InvoiceDate,
                        DueDate= invoice.DueDate,
                        PaidDate= invoice.PaidDate,
                        PaymentMethod= invoice.PaymentMethodNavigation.Name,
                    }
                );
        }
        public override void remove()
        {
            firmaTransportDBEntities.Invoices.Remove((from i in firmaTransportDBEntities.Invoices
                                                       where i.InvoiceId == RemoveId
                                                       select i).FirstOrDefault());
            firmaTransportDBEntities.SaveChanges();
        }

        #endregion
    }
}
