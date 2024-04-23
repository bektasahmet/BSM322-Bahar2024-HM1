using System.Globalization;

namespace GorselOdev1;

public partial class KrediHesaplama : ContentPage
{
	public KrediHesaplama()
	{
		InitializeComponent();
	}

    private void Hesapla_Clicked(object sender, EventArgs e)
    {
        string krediTuru = Picker.SelectedItem.ToString();

        
        double krediTutari = Convert.ToDouble(KrediTutarEntry.Text);
        double faizOrani = Convert.ToDouble(FaizOranEntry.Text);
        int vadeSuresi = Convert.ToInt32(VadeEntry.Text);

        double bsmvOrani = 0;
        double kkdfOrani = 0;

        if (krediTuru == "İhtiyaç Kredisi")
        {
            bsmvOrani = 0.10;
            kkdfOrani = 0.15;
        }
        else if (krediTuru == "Konut Kredisi")
        {
            bsmvOrani = 0.0;
            kkdfOrani = 0.0;
        }
        else if (krediTuru == "Taşıt Kredisi")
        {
            bsmvOrani = 0.05;
            kkdfOrani = 0.15;
        }
        else
        {
            bsmvOrani = 0.05;
            kkdfOrani = 0.0;
        }


        double brutFaiz = ((faizOrani + (faizOrani * bsmvOrani) + (faizOrani * kkdfOrani)) / 100);
        double taksit = ((Math.Pow(1 + brutFaiz, vadeSuresi) * brutFaiz) / (Math.Pow(1 + brutFaiz, vadeSuresi) - 1)) * krediTutari;
        double toplam = taksit * vadeSuresi;


        CultureInfo tr = new CultureInfo("tr-TR");

        TaksitSonucLabel.Text = $"{taksit}" + "\u20ba";
        ToplamOdemeSonucLabel.Text = $"{toplam}" + "\u20ba";
        ToplamFaizSonucLabel.Text = $"{toplam - krediTutari}" + "\u20ba";
    }
}