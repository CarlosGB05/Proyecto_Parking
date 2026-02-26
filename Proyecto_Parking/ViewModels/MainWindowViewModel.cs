using System;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using InformeEventos.Services;
using Proyecto_Parking.Models;
using Proyecto_Parking.Views.Dialogs;

namespace Proyecto_Parking.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService = new();
    [ObservableProperty] private string url = string.Empty;
    
    [ObservableProperty] private bool seMuestraPDF;
    [ObservableProperty] private AvaloniaList<string>? marcaVehiculos = new();
    [ObservableProperty] private AvaloniaList<Parking>? listaParking = new();
    [ObservableProperty] private Parking parkingSeleccionado = new();
    [ObservableProperty] private DateTime fechaInicio;
    [ObservableProperty] private DateTime fechaFin;
    [ObservableProperty] private string texto = string.Empty;
    [ObservableProperty] private string textoV = string.Empty;
    [ObservableProperty] private Cliente clienteSeleccionado = new();
    [ObservableProperty] private AvaloniaList<Cliente> listaClientes = new();
    [ObservableProperty] private AvaloniaList<Vehiculo> listaVehiculos = new();
    [ObservableProperty] private Vehiculo vehiculoSeleccionado = new();
    
    [ObservableProperty] private AvaloniaList<string>? listaGrupos = new();
    [ObservableProperty] private AvaloniaList<string>? nombreFestivales = new();
    [ObservableProperty] private AvaloniaList<string>? generosMusicales = new();
    

    public MainWindowViewModel()
    {
        
    }

    [RelayCommand]
    public async Task CargarDesplegablesAsync()
    {
        MarcaVehiculos = await n8nService.ObtenerMarcasVehiculos();
        ListaParking = await n8nService.ObtenerListaParking();
        
        ListaGrupos = await n8nService.ObtenerGrupos();
        NombreFestivales = await n8nService.ObtenerNombreFestivales();
        GenerosMusicales = await n8nService.ObtenerGenerosMusicales();
    }
    
    [RelayCommand]
    public void OcultarPDF()
    {
        DialogHost.Close("pdf");
        Url = "";
    }
    
    [RelayCommand]
    public void AbrirWebView()
    {
        FicheroPDF pdf = new FicheroPDF();
        pdf.DataContext = new MainWindowViewModel();
        DialogHost.Show(pdf,"pdf");
    }

    // INFORMES GENERALES 1: CLIENTES
    [RelayCommand]
    public async Task InformesGenerales1()
    {
        Url = "http://localhost:10000/parking/informacionClientes";
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    
    // INFORMES GENERALES 2: INFO VEHICULOS POR MARCA
    [RelayCommand]
    public async Task InformesGenerales2(string marca)
    {
        Url = "http://localhost:10000/parking/informacionVehiculo/"+Uri.EscapeDataString(marca);
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES GENERALES 3: PARKINGS
    [RelayCommand]
    public async Task InformesGenerales3()
    {
        Url = "http://localhost:10000/parking/informacionParkings";
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES GENERALES 4: INFO ESTACIONAMIENTOS POR FECHAS Y PARKING
    [RelayCommand]
    public async Task InformesGenerales4()
    {
        Url = "http://localhost:10000/parking/informacionEstacionamiento/"+ParkingSeleccionado.Id;
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES BARRAS 1: TOP 10 COSTO TOTAL DE CLIENTES GASTADO EN PARKING
    [RelayCommand]
    public async Task InformeBarras1()
    {
        Url = "http://localhost:10000/parking/costoParking";
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES BARRAS 2: INGRESOS TOTALES DE VEHICULOS POR MARCA
    [RelayCommand]
    public async Task InformeBarras2()
    {
        Url = "http://localhost:10000/parking/ingresosVehiculos";
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES BARRAS 3: TOTAL CLIENTES POR PARKING
    [RelayCommand]
    public async Task InformeBarras3()
    {
        Url = "http://localhost:10000/parking/clientesParkings";
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES QUESITOS 1: CANTIDAD VECES QUE UN CLIENTE USA CADA PARKING
    [RelayCommand]
    public async Task InformeCircular1()
    {
        Url = "http://localhost:10000/parking/cantidadParking/"+ClienteSeleccionado.Id;
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    [RelayCommand]
    public async Task CargarCantidadParkingAsync()
    {
        if (!String.IsNullOrWhiteSpace(Texto))
        {
            ListaClientes = await n8nService.ObtenerCantidadParking(Texto);
        }
    }
    
    // INFORMES QUESITOS 2: PREFERENCIA VEHICULOS POR PARKING
    [RelayCommand]
    public async Task InformeCircular2()
    {
        Url = "http://localhost:10000/parking/preferenciaParking/"+ParkingSeleccionado.Id;
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES QUESITOS 3: CANTIDAD INGRESOS POR LOCALIDAD
    [RelayCommand]
    public async Task InformeCircular3()
    {
        Url = "http://localhost:10000/parking/ingresosParking";
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES LINEAS 1: GASTOS ACUMULADOS DEL CLIENTE POR USO DEL PARKING
    [RelayCommand]
    public async Task InformeLineal1()
    {
        Url = "http://localhost:10000/parking/gastoAcumulado/"+ClienteSeleccionado.Id;
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    // INFORMES LINEAS 2: TIEMPO ESTACIONADO DE UN VEHICULO
    [RelayCommand]
    public async Task InformeLineal2()
    {
        Url = "http://localhost:10000/parking/tiempoEstacionado/"+VehiculoSeleccionado.Id;
        Console.WriteLine(Url);
        AbrirWebView();
    }
    
    [RelayCommand]
    public async Task CargarListaVehiculosAsync()
    {
        if (!String.IsNullOrWhiteSpace(TextoV))
        {
            ListaVehiculos = await n8nService.ObtenerListaVehiculos(TextoV);
        }
    }
    
    // INFORMES LINEAS 3: TIEMPO ESTACIONADO DE UN VEHICULO
    [RelayCommand]
    public async Task InformeLineal3()
    {
        Url = "http://localhost:10000/parking/horaPunta/"+ParkingSeleccionado.Id;
        Console.WriteLine(Url);
        AbrirWebView();
    }
    

    
}