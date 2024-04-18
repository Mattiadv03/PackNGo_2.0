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
        
        buttonTornaIndietro_CreaVacanza.Clicked += ButtonTornaIndietro_CreaVacanza_Clicked;
    }

    private void ButtonTornaIndietro_CreaVacanza_Clicked(object? sender, EventArgs e)
    {
        // Torno alla pagina ComponiValigia
        Navigation.PushAsync(new ComponiValigia(nomeVacanza, numeroNotti, stagione, tipologiaVacanza));
    }
}