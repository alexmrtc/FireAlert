using System.Diagnostics;
using System.Security.Policy;
using FireAlert.Data;
using Newtonsoft.Json;

namespace FireAlert.Services;

public class FireApi
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<FireApi> _logger;

    public FireApi(HttpClient httpClient, ApplicationDbContext context, ILogger<FireApi> logger)
    {
        _httpClient = httpClient;
        _context = context;
        _logger = logger;
    }

    public async Task ImportarDatosAsync()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://firms.modaps.eosdis.nasa.gov/api/country/csv/52fb6d23bcb9f0b582523e89ee6b45ec/VIIRS_NOAA20_NRT/ESP/1");
            // var fires = JsonSerializer.Deserialize<List<FireAlert>>(response);
            Debug.Write(response);
            
            // foreach (var fire in fires)
            // {
            //     if (string.IsNullOrEmpty(fire.Estacio))
            //     {
            //         _logger.LogWarning("Datos inválidos encontrados: {embalse}", fire);
            //         continue;
            //     }
            //
            //     // _context.Embalses.Add(fire);
            // }

            // await _context.SaveChangesAsync();
            _logger.LogInformation("Datos guardados correctamente en la base de datos.", response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al importar datos.");
            throw;
        }
    }
}