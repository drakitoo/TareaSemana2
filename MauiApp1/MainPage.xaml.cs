using System.Globalization;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalculateClicked(object? sender, EventArgs e)
        {
            var nameEntry = this.FindByName<Entry>("NameEntry");
            var lastNameEntry = this.FindByName<Entry>("LastNameEntry");
            var ageEntry = this.FindByName<Entry>("AgeEntry");
            var salaryEntry = this.FindByName<Entry>("SalaryEntry");

            if (string.IsNullOrWhiteSpace(nameEntry.Text) ||
                string.IsNullOrWhiteSpace(lastNameEntry.Text) ||
                string.IsNullOrWhiteSpace(ageEntry.Text) ||
                string.IsNullOrWhiteSpace(salaryEntry.Text))
            {
                await DisplayAlertAsync("Datos incompletos", "Todos los campos deben estar completos.", "Aceptar");
                return;
            }

            if (!int.TryParse(ageEntry.Text, NumberStyles.None, CultureInfo.InvariantCulture, out var age))
            {
                await DisplayAlertAsync("Dato inválido", "La edad debe contener solo números.", "Aceptar");
                return;
            }

            if (!decimal.TryParse(salaryEntry.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out var salary) &&
                !decimal.TryParse(salaryEntry.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out salary))
            {
                await DisplayAlertAsync("Dato inválido", "El salario debe contener solo números.", "Aceptar");
                return;
            }

            var contribution = salary * 0.0945m;
            var result = contribution.ToString("N2", CultureInfo.CurrentCulture);
            var message = $"Bienvenido {nameEntry.Text.Trim()} {lastNameEntry.Text.Trim()}\n" +
                          $"Tienes {age} años\n" +
                          $"Tu aporte mensual es {result}";

            await DisplayAlertAsync("Resultado", message, "Aceptar");
        }
    }
}
