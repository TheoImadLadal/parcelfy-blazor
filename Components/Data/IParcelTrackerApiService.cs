using parcelfy_blazor.Components.Models;

namespace parcelfy_blazor.Components.Data;

public interface IParcelTrackerApiService
{
	Task<ParcelTracker?> GetParcelTrackingDetails(string parcelId);
}
