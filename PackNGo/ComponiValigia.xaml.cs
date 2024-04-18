namespace PackNGo;

public partial class ComponiValigia : ContentPage
{
    string nomeVacanza;
    int numeroNotti;
    string stagione;
    string tipologiaVacanza;

    public ComponiValigia(string nomeVacanza, int numeroNotti, string stagione, string tipologiaVacanza)
	{
		InitializeComponent();

        // Salvo i valori dal ScegliTipologia
        this.nomeVacanza = nomeVacanza;
        this.numeroNotti = numeroNotti;
        this.stagione = stagione;
        this.tipologiaVacanza = tipologiaVacanza;

        t.Text = tipologiaVacanza;
	}
}