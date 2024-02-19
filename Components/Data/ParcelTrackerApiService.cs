using parcelfy_blazor.Components.Models;

namespace parcelfy_blazor.Components.Data;

public class ParcelTrackerApiService(HttpClient client) : IParcelTrackerApiService
{
    private readonly HttpClient _client = client;

    public async Task<ParcelTracker?> GetParcelTrackingDetails(string parcelId)
    {
        // Ask for the parcel 
        ParcelTracker? result = await _client.GetFromJsonAsync<ParcelTracker>($"parcel-tracker/{parcelId}");

        //string stringResponse = await parcelClientResponse.Content.ReadAsStringAsync();
        //result = JsonSerializer.Deserialize<ParcelTracker>(
        //    stringResponse,
        //    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });



        return result;
    }
}
