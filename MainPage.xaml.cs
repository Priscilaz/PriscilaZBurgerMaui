using Newtonsoft.Json;
using PriscilaZBurgerMaui.Models;

namespace PriscilaZBurgerMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        //code behind
        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7057/api/");
            var response = client.GetAsync("burger").Result;
            if (response.IsSuccessStatusCode)
            {
                var burgers = response.Content.ReadAsStringAsync().Result;
                var burgersList =
               JsonConvert.DeserializeObject<List<Burger>>(burgers);
                listView.ItemsSource = burgersList;
            }
        }
    }

}
