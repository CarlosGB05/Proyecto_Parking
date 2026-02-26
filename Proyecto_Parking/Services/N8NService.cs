using System;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Collections;
using Newtonsoft.Json;
using Proyecto_Parking.Models;

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
    
    public async Task<AvaloniaList<Parking>?> ObtenerListaParking()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "listaParking");
        
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<Parking>>(listaString);
    }
    
    public async Task<AvaloniaList<Cliente>?> ObtenerCantidadParking(string nomb)                      // el ? significa que sigue el metodo aunq reciba algun null
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "1864de8f-1421-4552-b777-31fa58c8d508/cantidadParking/"+nomb);
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<Cliente>>(listaString);
    }
    
    public async Task<AvaloniaList<Vehiculo>?> ObtenerListaVehiculos(string nomb)                      // el ? significa que sigue el metodo aunq reciba algun null
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "1864de8f-1421-4552-b777-31fa58c8d508/cantidadParking/"+nomb);
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<Vehiculo>>(listaString);
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
