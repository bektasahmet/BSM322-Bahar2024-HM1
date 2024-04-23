namespace GorselOdev1;

public partial class ColorPicker : ContentPage
{
	public ColorPicker()
	{
		InitializeComponent();
        UpdateColor();
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColor();
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        string colorCode = $"#{(int)RedSlider.Value:X2}{(int)GreenSlider.Value:X2}{(int)BlueSlider.Value:X2}";
        await Clipboard.Default.SetTextAsync(colorCode);
        DisplayAlert("Kopyalandı!", colorCode, "Ok");

    }

    private void Random_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();
        RedSlider.Value = random.Next(256);
        GreenSlider.Value = random.Next(256);
        BlueSlider.Value = random.Next(256);
        UpdateColor();
    }

    private void UpdateColor()
    {
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        clrBackground.BackgroundColor = Color.FromRgb(red, green, blue);

        string hexColor = $"{red:X2}{green:X2}{blue:X2}";
        txtHexCode.Text = $"#{hexColor}";
    }
}