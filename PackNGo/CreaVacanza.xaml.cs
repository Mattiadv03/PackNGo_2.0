namespace PackNGo;

public partial class CreaVacanza : ContentPage
{
	public CreaVacanza()
	{
		InitializeComponent();

        buttonTornaIndietro_CreaVacanza.Clicked += ButtonTornaIndietro_CreaVacanza_Clicked;
	}

    private void ButtonTornaIndietro_CreaVacanza_Clicked(object? sender, EventArgs e)
    {
        // Torno alla MainPage
        Navigation.PushAsync(new MainPage());
    }
}