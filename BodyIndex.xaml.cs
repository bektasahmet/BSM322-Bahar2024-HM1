
namespace GorselOdev1;

public partial class BodyIndex : ContentPage
{
	public BodyIndex()
	{
		InitializeComponent();
	}

    private void HesaplaBMI_Clicked(object sender, EventArgs e)
    {
        double boy = Convert.ToDouble(BoyEntry.Text);
        double kilo = Convert.ToDouble(KiloEntry.Text);

        boy = boy / 100.0;

        double bmi = kilo / (boy * boy);

        string category = Category(bmi);

        txtBmi.Text = $"BMI: {bmi:F2}";
        txtDegree.Text = $"{category}" ;
    }

    private string Category(double bmi)
    {
        if (bmi < 16)
            return "İleri Düzeyde Zayıf";
        else if (bmi >= 16 && bmi < 16.99)
            return "Orta Düzeyde Zayıf";
        else if (bmi >= 17 && bmi < 18.49)
            return "Hafif Düzeyde Zayıf";
        else if (bmi >= 18.50 && bmi < 24.9)
            return "Normal Kilolu";
        else if (bmi >= 25 && bmi < 29.99)
            return "Hafif Şişman";
        else if (bmi >= 39 && bmi < 34.99)
            return "1.Derecede Obez";
        else if (bmi >= 35 && bmi < 39.99)
            return "2.Derecede Obez";
        else
            return "3.Derecede Obez";
    }
}