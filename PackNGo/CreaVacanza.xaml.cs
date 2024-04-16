namespace PackNGo;

public partial class CreaVacanza : ContentPage
{
	public CreaVacanza()
	{
		InitializeComponent();

        buttonTornaIndietro_CreaVacanza.Clicked += ButtonTornaIndietro_CreaVacanza_Clicked;

        sliderNumeroNotti_CreaVacanza.ValueChanged += SliderNumeroNotti_CreaVacanza_ValueChanged;


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
        } else {
            // Falso, abilito lo slider
            sliderNumeroNotti_CreaVacanza.IsEnabled = true;

            // Mostro la label delle notti
            labelValoreSlider_CreaVacanza.IsVisible = true;
        }
    }

    public void OnLabelTapped(object sender, TappedEventArgs args)
    {
        // Inverti lo stato della checkbox
        checkboxGitaInGiornata_CreaVacanza.IsChecked = !checkboxGitaInGiornata_CreaVacanza.IsChecked;
    }


    private void SliderNumeroNotti_CreaVacanza_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        // Mostro il valore corrente
        labelValoreSlider_CreaVacanza.Text = "La vacanza durerà " + Convert.ToString(Convert.ToInt32(sliderNumeroNotti_CreaVacanza.Value)) + " notti";
    }

    private void ButtonTornaIndietro_CreaVacanza_Clicked(object? sender, EventArgs e)
    {
        // Torno alla MainPage
        Navigation.PushAsync(new MainPage());
    }
}