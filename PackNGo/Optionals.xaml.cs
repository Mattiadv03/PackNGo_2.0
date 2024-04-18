
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using Newtonsoft.Json;

namespace PackNGo;

public partial class Optionals : ContentPage
{
    string nomeVacanza;
    int numeroNotti;
    string stagione;
    string tipologiaVacanza;


    public Optionals(string nomeVacanza, int numeroNotti, string stagione, string tipologiaVacanza)
	{
        InitializeComponent();

        // Salvo i valori dal ScegliTipologia
        this.nomeVacanza = nomeVacanza;
        this.numeroNotti = numeroNotti;
        this.stagione = stagione;
        this.tipologiaVacanza = tipologiaVacanza;

        buttonTornaIndietro_Optionals.Clicked += ButtonTornaIndietro_Optionals_Clicked;

        // Popolo il FlexLayout
        Task popolaTipologie = popolaOptionalsAsync();
    }

    private async Task popolaOptionalsAsync()
    {
        // Controllo se è connesso a internet
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.Internet)
        {
            // Leggo da Github il file tipologie.json
            string urlJsonFile = "https://raw.githubusercontent.com/Mattiadv03/PackNGo_2.0/master/PackNGo/Resources/Json/optionals.json";

            // Creo un'istanza di HttpClient
            HttpClient client = new HttpClient();

            // Scarico il file JSON dal'url
            HttpResponseMessage response = await client.GetAsync(urlJsonFile);

            if (response.IsSuccessStatusCode)
            {
                // Ottengo il corpo della risposta
                string data = await response.Content.ReadAsStringAsync();

                if (data is not null)
                {
                    Optionals listaOptionals = JsonConvert.DeserializeObject<Optionals>(data);

                    foreach(var optional in listaOptionals.GetType().GetProperties())
                    {
                        // Creo un HorizontalStackLayout per allineare checkbox e label
                        HorizontalStackLayout horizontalLayout = new HorizontalStackLayout
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            
                        };

                        // Creo una checkbox
                        CheckBox checkboxOptional = new CheckBox
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            Color = Color.FromArgb("#ac99ea")
                        };

                        // Aggiungo all'HorizontalLayout
                        horizontalLayout.Children.Add(checkboxOptional);

                        // Prendo il nome dell'optional
                        string nomeOptional = optional.Name;

                        // Creo la label associata
                        Label labelOptional = new Label
                        {
                            Text = nomeOptional.Replace("_", " "),
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            GestureRecognizers =
                            {
                                new TapGestureRecognizer
                                {
                                    Command = new Command(() =>
                                    {
                                        checkboxOptional.IsChecked = !checkboxOptional.IsChecked;
                                    })
                                }
                            }
                        };

                        // Aggiungo all'HorizontalLayout
                        horizontalLayout.Children.Add(labelOptional);

                        // Aggiungo l'HorizontalLayout al FlexLayout
                        flexLayoutTipologie_Optionals.Children.Add(horizontalLayout);
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

    private void ButtonTornaIndietro_Optionals_Clicked(object? sender, EventArgs e)
    {
        // Torno alla pagina ScegliTipologia
        Navigation.PushAsync(new ScegliTipologia(nomeVacanza, numeroNotti, stagione));
    }
}