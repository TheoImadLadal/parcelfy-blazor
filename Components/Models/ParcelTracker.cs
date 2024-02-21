namespace parcelfy_blazor.Components.Models;

public class ParcelTracker
{
	public int ReturnCode { get; set; }
	public string ReturnMessage { get; set; } = string.Empty;
	public string IdShip { get; set; } = string.Empty;
	public ShipmentDomain? Shipment { get; set; }

	public class ShipmentDomain
	{
		public string IdShip { get; set; } = string.Empty;
		public string Product { get; set; } = string.Empty;
		public bool IsFinal { get; set; }
		public List<Event> Event { get; set; } = [];
		public string Url { get; set; } = string.Empty;
	}

	public class Event
	{
		public string Code { get; set; } = string.Empty;
		public string Label { get; set; } = string.Empty;
		public DateTime Date { get; set; }
	}
}
