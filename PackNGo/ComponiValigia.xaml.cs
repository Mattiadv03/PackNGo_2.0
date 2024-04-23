namespace PackNGo;

public partial class ComponiValigia : ContentPage
{
    string nomeVacanza;
    int numeroNotti;
    string stagione;
    string tipologiaVacanza;
    List<String> listaOptionalsScelti;

    Dictionary<Label, CheckBox> listaElementi;

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

        // Seleziona/Deseleziona tutto
        buttonSelezioneDeseleziona_ComponiValigia.Clicked += ButtonSelezioneDeseleziona_ComponiValigia_Clicked;

        // Torna indietro
        buttonTornaIndietro_ComponiValigia.Clicked += ButtonTornaIndietro_ComponiValigia_Clicked;
    }

    private void ButtonSelezioneDeseleziona_ComponiValigia_Clicked(object? sender, EventArgs e)
    {
        if(buttonSelezioneDeseleziona_ComponiValigia.Text == "Seleziona tutto")
        {
            // Rendo IsChecked a true per ogni elemento
            foreach (var elemento in listaOptionalsScelti)
            {
                if (!listaOptionalsScelti[elemento.Key].IsChecked)
                {
                    listaOptionalsScelti[elemento.Key].IsChecked = true;
                }
            }

            // Cambio la scritta del bottone
            buttonSelezioneDeseleziona_ComponiValigia.Text = "Deseleziona tutto";
        }
        else
        {
            // Rendo IsChecked a true per ogni elemento
            foreach (var elemento in listaOptionalsScelti)
            {
                if (listaOptionalsScelti[elemento.Key].IsChecked)
                {
                    listaOptionalsScelti[elemento.Key].IsChecked = false;
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