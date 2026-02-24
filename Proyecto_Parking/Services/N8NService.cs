using System;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Collections;
using Newtonsoft.Json;

namespace InformeEventos.Services;

public class N8NService
{
    private HttpClient client;

    public N8NService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5678/webhook/");
    }
    
    public async Task<AvaloniaList<string>?> ObtenerMarcasVehiculos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "marcaVehiculos");
        
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<string>?> ObtenerListaParking()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "listaParking");
        
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    
    
    
    
    public async Task<AvaloniaList<string>?> ObtenerGrupos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "ListaGrupos");
        
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<string>?> ObtenerNombreFestivales()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "TotalEntradas");
        
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<string>?> ObtenerGenerosMusicales()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "GeneroMusical");
        
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
}
