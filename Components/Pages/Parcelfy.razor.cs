using Microsoft.AspNetCore.Components;
using parcelfy_blazor.Components.Data;
using parcelfy_blazor.Components.Models;

namespace parcelfy_blazor.Components.Pages;

public partial class Parcelfy
{
    private ParcelTrackerRequest ParcelTrackerRequest = new();
    private ParcelTracker ParcelTrackerResponse = new();

    [Inject]
    public IParcelTrackerApiService? ParcelTrackerApiService { get; set; }

    private async Task HandleValidSubmit()
    {
        ParcelTrackerResponse = await ParcelTrackerApiService.GetParcelTrackingDetails(ParcelTrackerRequest.ParcelId);
    }
}