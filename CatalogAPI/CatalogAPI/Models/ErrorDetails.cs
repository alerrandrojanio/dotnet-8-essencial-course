using System.Text.Json;

namespace CatalogAPI.Models;

public class ErrorDatails {
    public int StatusCode { get; set; }

    public string? Message { get; set; }

    public string? Trace { get; set; }

    public string Serialize() 
    {
        return JsonSelizer.Serialize(this);
    } 
}