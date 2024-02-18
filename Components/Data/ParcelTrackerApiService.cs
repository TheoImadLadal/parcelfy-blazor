using parcelfy_blazor.Components.Models;
using System.Text.Json;

namespace parcelfy_blazor.Components.Data;

public class ParcelTrackerApiService(IHttpClientFactory clientFactory) : IParcelTrackerApiService
{
    private readonly IHttpClientFactory _clientFactory = clientFactory;

    public async Task<ParcelTracker?> GetParcelTrackingDetails(string parcelId)
    {
        ParcelTracker result = new();

        // Ask for the parcel 
        var parcelUrl = string.Format("https://parcelfy.azurewebsites.net/parcel-tracker/{0}", parcelId);
        var parcelRequest = new HttpRequestMessage(HttpMethod.Get, parcelUrl);
        parcelRequest.Headers.Add("Accept", "application/json");
        var parcelClient = _clientFactory.CreateClient();

        var parcelClientResponse = await parcelClient.SendAsync(parcelRequest);
        if (parcelClientResponse.IsSuccessStatusCode)
        {
            string stringResponse = await parcelClientResponse.Content.ReadAsStringAsync();
            result = JsonSerializer.Deserialize<ParcelTracker>(
                stringResponse,
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

        }

        return result;
    }
}
