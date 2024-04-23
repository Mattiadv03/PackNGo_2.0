
using Newtonsoft.Json;

namespace PackNGo;

public partial class ComponiValigia : ContentPage
{
    string nomeVacanza;
    int numeroNotti;
    string stagione;
    string tipologiaVacanza;
    Dictionary<Label, CheckBox> listaOptionalsScelti;
    Dictionary<Label, CheckBox> listaDefaultScelti;
    Dictionary<Label, CheckBox> listaElementi;

    public ComponiValigia(string nomeVacanza, int numeroNotti, string stagione, string tipologiaVacanza, Dictionary<Label, CheckBox> listaOptionalsScelti)
    {
        InitializeComponent();

        // Salvo i valori dal ScegliTipologia
        this.nomeVacanza = nomeVacanza;
        this.numeroNotti = numeroNotti;
        this.stagione = stagione;
        this.tipologiaVacanza = tipologiaVacanza;
        this.listaOptionalsScelti = listaOptionalsScelti;

        listaElementi = new Dictionary<Label, CheckBox>();

        // Imposto il titolo in base al nomeVacanza
        setTitolo();

        // Popolo con gli elementi di default
        popolaDefaultAsync();

        // Popolo con gli optionals
        popolaOptionals();

        // Seleziona/Deseleziona tutto
        buttonSelezioneDeseleziona_ComponiValigia.Clicked += ButtonSelezioneDeseleziona_ComponiValigia_Clicked;

        // Torna indietro
        buttonTornaIndietro_ComponiValigia.Clicked += ButtonTornaIndietro_ComponiValigia_Clicked;
    }

    private async Task popolaDefaultAsync()
    {
        // Controllo se è connesso a internet
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        if (accessType == NetworkAccess.Internet)
        {
            // Leggo da Github il file default.json
            string urlJsonFile = "https://raw.githubusercontent.com/Mattiadv03/PackNGo_2.0/master/PackNGo/Resources/Json/default.json";

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
                    Default listaDefault = JsonConvert.DeserializeObject<Default>(data);

                    foreach (var item in listaDefault.GetType().GetProperties())
                    {
                        // Creo un StackLayout per allineare checkbox e label
                        StackLayout stackLayoutDefault = new StackLayout
                        {
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Orientation = StackOrientation.Horizontal
                        };

                        // Creo una checkbox
                        CheckBox checkboxDefault = new CheckBox
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            Color = Color.FromArgb("#ac99ea")
                        };

                        // Aggiungo all'HorizontalLayout
                        stackLayoutDefault.Children.Add(checkboxDefault);

                        // Prendo il nome dell'optional
                        string nomeDefault = item.Name;

                        // Creo la label associata
                        Label labelOptional = new Label
                        {
                            Text = nomeDefault.Replace("_", " "),
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalOptions = LayoutOptions.Center,
                            GestureRecognizers =
                            {
                                new TapGestureRecognizer
                                {
                                    Command = new Command(() =>
                                    {
                                        checkboxDefault.IsChecked = !checkboxDefault.IsChecked;
                                    })
                                }
                            }
                        };

                        // Aggiungo al dictionary
                        listaElementi.Add(labelOptional, checkboxDefault);

                        // Aggiungo all'StackLayout
                        stackLayoutDefault.Children.Add(checkboxDefault);

                        // Aggiungo l'HorizontalLayout al FlexLayout
                        stackLayoutDefault.Children.Add(checkboxDefault);
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

    private void popolaOptionals()
    {

    }

    private void ButtonSelezioneDeseleziona_ComponiValigia_Clicked(object? sender, EventArgs e)
    { 
        if(buttonSelezioneDeseleziona_ComponiValigia.Text == "Seleziona tutto")
        {
            // Rendo IsChecked a true per ogni elemento
            foreach (var elemento in listaElementi)
            {
                if (!listaElementi[elemento.Key].IsChecked)
                {
                    listaElementi[elemento.Key].IsChecked = true;
                }
            }

            // Cambio la scritta del bottone
            buttonSelezioneDeseleziona_ComponiValigia.Text = "Deseleziona tutto";
        }
        else
        {
            // Rendo IsChecked a true per ogni elemento
            foreach (var elemento in listaElementi)
            {
                if (listaElementi[elemento.Key].IsChecked)
                {
                    listaElementi[elemento.Key].IsChecked = false;
                }
            }

            // Cambio la scritta del bottone
            buttonSelezioneDeseleziona_ComponiValigia.Text = "Seleziona tutto";
        }
    }

    private void ButtonTornaIndietro_ComponiValigia_Clicked(object? sender, EventArgs e)
    {
        // Torno alla pagina Optionals
        Navigation.PushAsync(new Optionals(nomeVacanza, numeroNotti, stagione, tipologiaVacanza));
    }

    public void setTitolo()
    {
        labelTitolo_ComponiValigia.Text = nomeVacanza;
    }
}