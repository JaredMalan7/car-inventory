using System.Net.Http.Json;
using CarInventory.Services.Models;

namespace CarInventory.Services;

// Service responsible for retrieving vehicle make and model data
// from the NHTSA vPIC public API.
public class VehicleLookupService
{
    // HttpClient injected via dependency injection
    private readonly HttpClient _http;

    public VehicleLookupService(HttpClient http)
    {
        _http = http;
    }

    // Retrieves a list of passenger car makes from the vPIC API
    public async Task<List<string>> GetPassengerCarMakesAsync()
    {
        var url = "https://vpic.nhtsa.dot.gov/api/vehicles/GetMakesForVehicleType/passenger%20car?format=json";

        var response = await _http.GetFromJsonAsync<VpicResponse<VehicleTypeMakeResult>>(url);

        // Extract, deduplicate, and sort make names
        return response?.Results
            .Select(m => m.MakeName)
            .Distinct()
            .OrderBy(m => m)
            .ToList()
            ?? new List<string>();
    }

    // Retrieves a list of vehicle models for a given make and year
    public async Task<List<string>> GetModelsAsync(string make, int year)
    {
        var response = await _http.GetFromJsonAsync<VpicResponse<ModelResult>>(
            $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeYear/make/{make}/modelyear/{year}?format=json");

        // Extract, deduplicate, and sort model names
        return response?.Results
            .Select(m => m.Model_Name)
            .Distinct()
            .OrderBy(m => m)
            .ToList() ?? new();
    }
}

// Model representing a vehicle make returned by the vPIC API
public class VehicleTypeMakeResult
{
    public int MakeId { get; set; }
    public string MakeName { get; set; } = "";
}