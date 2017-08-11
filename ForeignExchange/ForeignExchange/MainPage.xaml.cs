using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForeignExchange
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ConvertButton.Clicked += ConvertButton_Clicked;

        }

        private void ConvertButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(PesosEntry.Text))
            {
                DisplayAlert("Error", "You most enter a value in Pesos", "Accept");
                PesosEntry.Text = null;
                return;
            }

            decimal Pesos = 0;
            if(!decimal.TryParse(PesosEntry.Text, out Pesos))
            {
                DisplayAlert("Error", "You most enter a value numeric", "Accept");
                PesosEntry.Text = null;
            }

            var Dollar = Pesos / 3003.003M;             //{ }
            var Euros = Pesos / 3531.05105M;
            var Pounds = Pesos / 3907.23724M;

            DollarsEntry.Text = string.Format("${0:N2}", Dollar);//c2 number-n2 pesos
            EurosEntry.Text=string.Format("€{0:N2}", Euros);
            PoundsEntry.Text=string.Format("£{0:N2}", Pounds);

        }
    }
}
