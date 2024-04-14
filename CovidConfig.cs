using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302220011
{
    // Kelas untuk menyimpan konfigurasi COVID-19
    public class CovidConfig
    {
        public string UnitSuhu { get; set; }
        public int MaksHariDemam { get; set; }
        public string PesanTolak { get; set; }
        public string PesanTerima { get; set; }

        public void UbahSatuan()
        {
            if (UnitSuhu == "Celcius")
                UnitSuhu = "Fahrenheit";
            else
                UnitSuhu = "Celcius";
        }
    }

    // Kelas untuk mengelola konfigurasi COVID-19
    public class PengelolaCovidConfig
    {
        private string lokasiFile = "config.json";
        private CovidConfig konfigurasi;

        public PengelolaCovidConfig()
        {
            MuatKonfigurasi();
        }

        private void MuatKonfigurasi()
        {
            try
            {
                string data = File.ReadAllText(lokasiFile);
                konfigurasi = JsonSerializer.Deserialize<CovidConfig>(data);
            }
            catch
            {
                konfigurasi = new CovidConfig
                {
                    UnitSuhu = "Celcius",
                    MaksHariDemam = 14,
                    PesanTolak = "Maaf, Anda tidak diizinkan masuk ke gedung ini.",
                    PesanTerima = "Silakan masuk ke gedung ini."
                };
                SimpanKonfigurasi();
            }
        }

        private void SimpanKonfigurasi()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string data = JsonSerializer.Serialize(konfigurasi, options);
            File.WriteAllText(lokasiFile, data);
        }

        public void UbahUnitSuhu()
        {
            konfigurasi.UbahSatuan();
            SimpanKonfigurasi();
        }

        public CovidConfig AmbilKonfigurasi()
        {
            return konfigurasi;
        }
    }
}

