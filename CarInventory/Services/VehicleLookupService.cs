using System.Net.Http.Json;
using CarInventory.Services.Models;

namespace CarInventory.Services;

public class VehicleLookupService
{
    private readonly HttpClient _http;

    public VehicleLookupService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<string>> GetPassengerCarMakesAsync()
    {
        var url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetMakesForVehicleType/passenger%20car?format=json";

        var response = await _http.GetFromJsonAsync<VpicResponse<VehicleTypeMakeResult>>(url);

        return response?.Results
            .Select(m => m.MakeName)
            .Distinct()
            .OrderBy(m => m)
            .ToList()
            ?? new List<string>();
    }

    public async Task<List<string>> GetModelsAsync(string make, int year)
    {
        var response = await _http.GetFromJsonAsync<VpicResponse<ModelResult>>(
            $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeYear/make/{make}/modelyear/{year}?format=json");

        return response?.Results
            .Select(m => m.Model_Name)
            .Distinct()
            .OrderBy(m => m)
            .ToList() ?? new();
    }
}

public class VehicleTypeMakeResult
{
    public int MakeId { get; set; }
    public string MakeName { get; set; } = "";
}