namespace PackNGo;

public partial class ComponiValigia : ContentPage
{
    string nomeVacanza;
    int numeroNotti;
    string stagione;
    string tipologiaVacanza;
    List<String> listaOptionalsScelti;

    public ComponiValigia(string nomeVacanza, int numeroNotti, string stagione, string tipologiaVacanza, List<String> listaOptionalsScelti)
	{
		InitializeComponent();

        // Salvo i valori dal ScegliTipologia
        this.nomeVacanza = nomeVacanza;
        this.numeroNotti = numeroNotti;
        this.stagione = stagione;
        this.tipologiaVacanza = tipologiaVacanza;
        this.listaOptionalsScelti = listaOptionalsScelti;
        
        // Imposto il titolo in base al nomeVacanza
        setTitolo();
	}

    public void setTitolo()
    {
        labelTitolo.Text = nomeVacanza;
    }
}