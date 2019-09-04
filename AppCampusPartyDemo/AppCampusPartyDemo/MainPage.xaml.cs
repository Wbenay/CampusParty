using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppCampusPartyDemo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            buttonAtualizar.Clicked += ButtonAtualizar_Clicked;
        }

        private async void ButtonAtualizar_Clicked(object sender, EventArgs e)
        {

            indicatorRun.IsRunning = true;

            var client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync("https://www.mercadobitcoin.net/api/BTC/day-summary/2019/9/02/");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Summary>(content);

                labelPrecoAbertura.Text = string.Format("{0:C}", result.opening);
                labelPrecoFechamento.Text = string.Format("{0:C}", result.closing);

                indicatorRun.IsRunning = false;
                return;
            }
            await DisplayAlert("Falha", "Não foi possível", "OK");
        }
    }
}
