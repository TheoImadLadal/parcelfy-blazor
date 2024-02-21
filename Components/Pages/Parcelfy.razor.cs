using Microsoft.AspNetCore.Components;
using parcelfy_blazor.Components.Data;
using parcelfy_blazor.Components.Models;
using Radzen;

namespace parcelfy_blazor.Components.Pages;

public partial class Parcelfy
{
	Variant variant = Variant.Outlined;
	private readonly ParcelTrackerRequest ParcelTrackerRequest = new();
	private IEnumerable<ParcelTracker>? ParcelTrackerResponse;

	[Inject]
	public IParcelTrackerApiService? ParcelTrackerApiService { get; set; }

	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		ParcelTrackerResponse = Enumerable.Empty<ParcelTracker>();
	}

	private void OnParcelRender(DataGridRenderEventArgs<ParcelTracker> args)
	{
		if (args.FirstRender)
		{
			args.Grid.ExpandRow(args.Grid.View.FirstOrDefault());
			StateHasChanged();
		}
	}

	private async Task<IEnumerable<ParcelTracker?>> HandleValidSubmit()
	{
		List<ParcelTracker>? parcelTrackerResponseList = [await ParcelTrackerApiService!.GetParcelTrackingDetails(ParcelTrackerRequest.ParcelId)];
		ParcelTrackerResponse = parcelTrackerResponseList;
		return ParcelTrackerResponse;
	}
}