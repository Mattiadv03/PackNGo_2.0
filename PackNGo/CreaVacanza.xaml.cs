using SQLite;
using PackNGo.Tabelle;

namespace PackNGo;

public partial class CreaVacanza : ContentPage
{
    private SQLiteAsyncConnection conn;

    public CreaVacanza()
	{
		InitializeComponent();

        // Inizializzo il database
        InitDB();

        buttonTornaIndietro_CreaVacanza.Clicked += ButtonTornaIndietro_CreaVacanza_Clicked;

        sliderNumeroNotti_CreaVacanza.ValueChanged += SliderNumeroNotti_CreaVacanza_ValueChanged;

        imageButtonPrimavera_CreaVacanza.Clicked += ImageButtonPrimavera_Clicked;

        imageButtonEstate_CreaVacanza.Clicked += ImageButtonEstate_Clicked;

        imageButtonAutunno_CreaVacanza.Clicked += ImageButtonAutunno_Clicked;

        imageButtonInverno_CreaVacanza.Clicked += ImageButtonInverno_Clicked;
	}

    private async Task InitDB()
    {
        // Controllo se esiste già la connessione al db
        if (conn != null)
            // Si, evito di ricrearla
            return;

        // No, mi connetto
        conn = new SQLiteAsyncConnection(_dbPath);

        // Creo le tabelle
        await conn.CreateTableAsync<CategorieOggetti>();
        await conn.CreateTableAsync<Oggetti>();
        await conn.CreateTableAsync<TipologieVacanza>();

        // Popolo gli elementi del database

    }

    // Creo la varibile del numero di notti
    private int numeroNotti = -1;

    private void ImageButtonInverno_Clicked(object? sender, EventArgs e)
    {
        passaAScegliTipologia("inverno");
    }

    private void ImageButtonAutunno_Clicked(object? sender, EventArgs e)
    {
        passaAScegliTipologia("autunno");
    }

    private void ImageButtonEstate_Clicked(object? sender, EventArgs e)
    {
        passaAScegliTipologia("estate");
    }

    private void ImageButtonPrimavera_Clicked(object? sender, EventArgs e)
    {
        passaAScegliTipologia("primavera");
    }

    private void passaAScegliTipologia(string stagione)
    {
        // Controllo che l'utente abbia inserito il nome della vacanza
        string nomeVacanza = entryNomeVacanza_CreaVacanza.Text;
        if (nomeVacanza is null || nomeVacanza == " ")
        {
            nomeVacanza = "Vacanza Test " + DateTime.Now.ToString();
        }

        // Controllo il numero di notti
        if(!(numeroNotti == -1))
        {
            Navigation.PushAsync(new ScegliTipologia(nomeVacanza!, numeroNotti, stagione));
        }
        else
        {
            // L'utente non ha scelto il numero di notti
            labelNumeroDiNotti.TextColor = Colors.Red;
        }
    }

    private void CheckboxGitaInGiornata_CheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        // Prendo lo stato corrente
        bool isCheckboxGitaInGiornataChecked = checkboxGitaInGiornata_CreaVacanza.IsChecked;

        if(isCheckboxGitaInGiornataChecked ) {
            // True, disabilito lo slider
            sliderNumeroNotti_CreaVacanza.IsEnabled = false;

            // Nascondo la label delle notti
            labelValoreSlider_CreaVacanza.IsVisible = false;

            // Imposto a 0 il numero di notti
            numeroNotti = 0;
        } else {
            // Falso, abilito lo slider
            sliderNumeroNotti_CreaVacanza.IsEnabled = true;

            // Mostro la label delle notti
            labelValoreSlider_CreaVacanza.IsVisible = true;

            // Leggo il numero di notti
            numeroNotti = Convert.ToInt32(sliderNumeroNotti_CreaVacanza.Value);
        }
    }

    public void OnLabelTapped(object sender, TappedEventArgs args)
    {
        // Inverti lo stato della checkbox
        checkboxGitaInGiornata_CreaVacanza.IsChecked = !checkboxGitaInGiornata_CreaVacanza.IsChecked;
    }


    private void SliderNumeroNotti_CreaVacanza_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        numeroNotti = Convert.ToInt32(sliderNumeroNotti_CreaVacanza.Value);

        // Mostro il valore corrente
        labelValoreSlider_CreaVacanza.Text = "La vacanza durerà " + Convert.ToString(numeroNotti) + " notti";
    }

    private void ButtonTornaIndietro_CreaVacanza_Clicked(object? sender, EventArgs e)
    {
        // Torno alla MainPage
        Navigation.PushAsync(new MainPage());
    }
}