// See https://aka.ms/new-console-template for more information
using System;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine($"Selamat datang di Pemeriksa Suhu Badan COVID-19\n\nMohon masukkan suhu badan Anda (dalam {config.SatuanSuhu}): ");
        double suhu = double.Parse(Console.ReadLine());

        Console.WriteLine("\nBerapa hari yang lalu Anda terakhir mengalami demam?");
        int hariDeman = int.Parse(Console.ReadLine());

        Console.WriteLine("\nMengevaluasi hasil...");

        bool diterima = (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                        (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5) &&
                        hariDeman < config.BatasHariDemam;

        Console.WriteLine(diterima ? $"\n{config.PesanDiterima}" : $"\n{config.PesanDitolak}");

        config.UbahSatuan();
        Console.WriteLine($"\nKebijakan akan menggunakan satuan {config.SatuanSuhu} untuk pemeriksaan selanjutnya.");
    }
}

