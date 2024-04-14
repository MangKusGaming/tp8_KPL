using System.Text.Json;

public class CovidConfig
{
    private const string configFile = "Covid_Config.json";
    private JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    private ConfigData configData;

    public CovidConfig()
    {
        if (File.Exists(configFile))
        {
            string configText = File.ReadAllText(configFile);
            configData = JsonSerializer.Deserialize<ConfigData>(configText);
        }
        else
        {
            configData = new ConfigData();
            SimpanPerubahan();
        }
    }

    public string SatuanSuhu
    {
        get { return configData.SatuanSuhu; }
        set { configData.SatuanSuhu = value; }
    }

    public int BatasHariDemam
    {
        get { return configData.BatasHariDemam; }
        set { configData.BatasHariDemam = value; }
    }

    public string PesanDitolak
    {
        get { return configData.PesanDitolak; }
        set { configData.PesanDitolak = value; }
    }

    public string PesanDiterima
    {
        get { return configData.PesanDiterima; }
        set { configData.PesanDiterima = value; }
    }

    public void SimpanPerubahan()
    {
        string json = JsonSerializer.Serialize(configData, options);
        File.WriteAllText(configFile, json);
    }

    public void UbahSatuan()
    {
        SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
        SimpanPerubahan();
    }

    private class ConfigData
    {
        public ConfigData()
        {
            SatuanSuhu = "celcius";
            BatasHariDemam = 14;
            PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public string SatuanSuhu { get; set; }
        public int BatasHariDemam { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }
    }
}