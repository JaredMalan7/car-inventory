namespace CarInventory.Services.Models;
// Generic wrapper model for responses returned by the NHTSA vPIC API.
// This class is used to deserialize API responses that include a total count,
// a status message, and a list of result records (e.g., vehicle makes or models).
public class VpicResponse<T>
{
    public int Count { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<T> Results { get; set; } = new();
}