
using Newtonsoft.Json;

namespace PackNGo;

public partial class ScegliTipologia : ContentPage
{
	public ScegliTipologia(string nomeVacanza, int numeroNotti, string stagione)
	{
		InitializeComponent();

        // Popolo FlexLayout
        Task popolaTipologie = leggiTipologieAsync();

        
    }

    private async Task leggiTipologieAsync()
    {
        // Controllo se è connesso a internet
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.Internet)
        {
            // Leggo da Github il file tipologie.json
            string urlJsonFile = "https://raw.githubusercontent.com/Mattiadv03/PackNGo_2.0/master/PackNGo/Resources/Json/listaTipologie.json";

            // Creo un'istanza di HttpClient
            HttpClient client = new HttpClient();

            // Scarico il file JSON dal'url
            HttpResponseMessage response = await client.GetAsync(urlJsonFile);

            if (response.IsSuccessStatusCode)
            {
                // Ottiengo il corpo della risposta
                string data = await response.Content.ReadAsStringAsync();

                if(data is not null)
                {
                    List<string> listaTipologie = JsonConvert.DeserializeObject<List<string>>(data)!;

                    foreach (var tipologia in listaTipologie)
                    {
                        // Creo lo stackLayout che conterrà imageButton e label
                        StackLayout layout = new StackLayout
                        {
                            HorizontalOptions = LayoutOptions.Center
                        };

                        // Creo un imageButton per ogni tipologia
                        ImageButton imageButton = new ImageButton
                        {
                            Source = tipologia.Replace(" ", "") + ".png",
                            MaximumWidthRequest = 130,
                            MaximumHeightRequest = 150,
                            Aspect = Aspect.AspectFit,
                            BackgroundColor = Color.FromArgb("#1f1f1f"),
                            Margin = new Thickness(10, 0)
                        };
                    
                        // Creo la label associata
                        Label label = new Label
                        {
                            Text = tipologia,
                            HorizontalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0, 5)
                        };

                        // Aggiungo allo StackLayout
                        layout.Children.Add(imageButton);
                        layout.Children.Add(label);

                        // Aggiungo al FlexLayout
                        flexLayoutTipologie_ScegliTipologia.Children.Add(layout);
                    }
                }
                else
                {
                    await DisplayAlert("Errore", "Errore durante la lettura del file", "OK");
                }
            }
            else
            {
                await DisplayAlert("Errore", "File non trovato, controlla il repository su Github", "OK");
            }
        }
        else
        {
            await DisplayAlert("Errore", "Connettiti a internet per utilizzare l'applicazione", "OK");
        }
    }

    private void ButtonTornaIndietro_CreaVacanza_Clicked(object? sender, EventArgs e)
    {
        // Torno alla MainPage
        Navigation.PushAsync(new CreaVacanza());
    }
}