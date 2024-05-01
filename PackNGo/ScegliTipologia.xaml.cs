using Newtonsoft.Json;
using static CoreFoundation.DispatchSource;

namespace PackNGo;

public partial class ScegliTipologia : ContentPage
{
    string nomeVacanza;
    int numeroNotti;
    string stagione;

    public ScegliTipologia(string nomeVacanza, int numeroNotti, string stagione)
	{
		InitializeComponent();

        // Salvo i valori dal CreaVacanza
        this.nomeVacanza = nomeVacanza;
        this.numeroNotti = numeroNotti;
        this.stagione = stagione;

        // Popolo il FlexLayout
        Task popolaTipologie = popolaTipologieAsync();

        buttonTornaIndietro_ScegliTipologia.Clicked += ButtonTornaIndietro_ScegliTipologia_Clicked;
    }

    private async Task popolaTipologieAsync()
    {
        // Leggo la tabella delle Tipologie


        if (data is not null)
        {
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

                // Associo l'evento di click
                imageButton.Clicked += ImageButton_Clicked;

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

    private void ImageButton_Clicked(object? sender, EventArgs e)
    {
        // Prendo la tipologia scelta
        ImageButton? imageButtonTipologiaVacanza = sender as ImageButton;

        // Prendo il nome del file
        string? nomeFileImageButton = imageButtonTipologiaVacanza!.Source.ToString();

        // Tolgo l'estensione del file
        string tipologiaVacanza = nomeFileImageButton!.Replace(".png", "");

        // Tolgo l'intestazione "File: "
        tipologiaVacanza = tipologiaVacanza.Replace("File: ", "");

        Navigation.PushAsync(new Optionals(nomeVacanza, numeroNotti, stagione, tipologiaVacanza));
    }

    private void ButtonTornaIndietro_ScegliTipologia_Clicked(object? sender, EventArgs e)
    {
        // Torno alla pagina CreaVacanze
        Navigation.PushAsync(new CreaVacanza());
    }
}