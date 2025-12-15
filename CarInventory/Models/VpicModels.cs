namespace CarInventory.Services.Models;

public class VpicResponse<T>
{
    public int Count { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<T> Results { get; set; } = new();
}