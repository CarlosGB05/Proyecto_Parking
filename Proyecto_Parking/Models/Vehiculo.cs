using Newtonsoft.Json;

namespace Proyecto_Parking.Models;

public class Vehiculo
{
    [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Id {get; set;}
    
    [JsonProperty("marca")]
    private string Marca {get; set;}
    
    [JsonProperty("modelo")]
    private string Modelo {get; set;}

    public override string ToString()
    {
        return Marca+" "+Modelo;
    }
}