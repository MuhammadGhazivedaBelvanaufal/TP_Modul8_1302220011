using tpmodul8_1302220011;
internal class Program
{
    private static void Main(string[] args)
    {
        PengelolaCovidConfig pengelola = new PengelolaCovidConfig();
        CovidConfig konfigurasi = pengelola.AmbilKonfigurasi();

        Console.WriteLine($"Satuan suhu saat ini adalah {konfigurasi.UnitSuhu}");
        Console.Write("Apakah ingin mengganti satuan suhu? (y/n): ");
        string jawabanGantiSatuan = Console.ReadLine().ToLower();

        if (jawabanGantiSatuan == "y")
        {
            pengelola.UbahUnitSuhu();
            konfigurasi = pengelola.AmbilKonfigurasi();
        }

        Console.Write($"Berapa suhu badan Anda saat ini? Dalam nilai {konfigurasi.UnitSuhu} : ");
        double suhuBadan = Convert.ToDouble(Console.ReadLine());

        Console.Write($"Berapa hari yang lalu (perkiraan) Anda terakhir memiliki gejala demam? : ");
        int hariTerakhirDemam = int.Parse(Console.ReadLine());

        bool batasDemamTerima = hariTerakhirDemam < konfigurasi.MaksHariDemam;
        bool suhuCelciusTerima = (konfigurasi.UnitSuhu == "Celcius") && (suhuBadan >= 36.5 && suhuBadan <= 37.5);
        bool suhuFahrenheitTerima = (konfigurasi.UnitSuhu == "Fahrenheit") && (suhuBadan >= 97.7 && suhuBadan <= 99.5);

        if (!batasDemamTerima || (!suhuCelciusTerima && !suhuFahrenheitTerima))
        {
            Console.WriteLine(konfigurasi.PesanTolak);
        }
        else
        {
            Console.WriteLine(konfigurasi.PesanTerima);
        }
    }
}