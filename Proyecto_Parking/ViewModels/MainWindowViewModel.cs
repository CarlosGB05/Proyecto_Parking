using System;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using InformeEventos.Services;
using Proyecto_Parking.Views.Dialogs;

namespace Proyecto_Parking.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService = new();
    [ObservableProperty] private string url = string.Empty;
    
    [ObservableProperty] private bool seMuestraPDF;
    [ObservableProperty] private AvaloniaList<string>? marcaVehiculos = new();
    [ObservableProperty] private AvaloniaList<string>? listaParking = new();
    [ObservableProperty] private DateTime fechaInicio;
    [ObservableProperty] private DateTime fechaFin;
    
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
    public async Task InformesGenerales4(string marca)
    {
        Url = "http://localhost:10000/parking/informacionEstacionamiento/"
              +Uri.EscapeDataString(marca) +"/"+Uri.EscapeDataString(fechaInicio.ToString("yyyy/MM/dd"))
              +"/"+Uri.EscapeDataString(fechaFin.ToString("yyyy/MM/dd"));
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
    
    
    
    
    
    
    
    
    

    // Ejemplo 2
    [RelayCommand]
    public async Task EntradaPorID(string id)
    {
        Url = "http://localhost:10000/reports/getEntrada/"+id;
        Console.WriteLine(Url);
        SeMuestraPDF = true;
    }

    // Ejemplo 3
    [RelayCommand]
    public async Task FestivalesFiltos()
    {
        
    }

    //EJEMPLO 4 INFORMES
    [RelayCommand]
    public async Task GruposPorFestival(string grupo)
    {
        Url = "http://localhost:10000/reports/getNombreGrupo/"+Uri.EscapeDataString(grupo);
        Console.WriteLine(Url);
        SeMuestraPDF = true;
    }

    // EJEMPLO 5 INFORMES
    [RelayCommand]
    public async Task EntradasPorFestival()
    {
      
    }

    /**
     * EJEMPLOS GRÁFICOS DE BARRAS
     *
     */
    // Ejemplo 1
    [RelayCommand]
    public async Task GraficoIngresosPorFestival()
    {
        Url = "http://localhost:10000/reports/ingresosFestivales";
        Console.WriteLine(Url);
        SeMuestraPDF = true;
    }

    // Ejemplo 2
    [RelayCommand]
    public async Task GraficoEntradasPorTipo(string tipo)
    {
        Url = "http://localhost:10000/reports/getFestivalTipo/"+Uri.EscapeDataString(tipo);
        Console.WriteLine(Url);
        SeMuestraPDF = true;
    }

    // Ejemplo 3
    [RelayCommand]
    public async Task GraficoIngresosPorFestivalFechas()
    {
        
    }

    // Ejemplo 4 -
    [RelayCommand]
    public async Task GraficoIngresosPorTipoGlobal()
    {
        
    }

    // Ejemplo 5 -
    [RelayCommand]
    public async Task GraficoIngresosPorTipoFestival()
    {
      
    }
    
    /**
     * EJEMPLOS GRÁFICOS DE QUESITOS
     *
     */
    // Ejemplo 2
    [RelayCommand]
    public async Task GraficoGenerosMusicales(string pais)
    {
        Url = "http://localhost:10000/reports/getGeneroMusical/"+Uri.EscapeDataString(pais);
        Console.WriteLine(Url);
        SeMuestraPDF = true;
    }

    
}