using Newtonsoft.Json;

namespace Proyecto_Parking.Models;

public class Parking
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Id {get; set;}
    
    [JsonProperty("nombre")]
    private string Nombre {get; set;}
    
    public override string ToString()
    {
        return Nombre;
    }
}