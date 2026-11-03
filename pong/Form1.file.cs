using System.Text.Json;

namespace pong
{
  using System.Text.Json;

  public partial class Form1
  {
    string dossier, filePath;
    private void saveJson(Dictionary<string, object> data)
    {

      dossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "pong");
      Directory.CreateDirectory(dossier);
      filePath = Path.Combine(dossier, "setting.json");

      string text = JsonSerializer.Serialize(data);
      File.WriteAllText(filePath, text);

    }
    private Dictionary<string, JsonElement>? loadJson()
    {
      dossier = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "pong");
      Directory.CreateDirectory(dossier);
      filePath = Path.Combine(dossier, "setting.json");
      if (File.Exists(filePath))
      {
        string text = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(text);
        return data;
      }
      else
      {
        return null;
      }
    }
  }
}