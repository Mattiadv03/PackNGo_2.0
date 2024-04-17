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

        
    }
}