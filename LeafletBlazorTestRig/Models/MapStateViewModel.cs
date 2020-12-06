using Darnton.Blazor.Leaflet.LeafletMap;

namespace LeafletBlazorTestRig.Models
{
    public class MapStateViewModel
    {
        public double MapCentreLatitude { get; set; }
        public double MapCentreLongitude { get; set; }
        public int Zoom { get; set; }
        public Point MapContainerSize { get; set; }
        public Bounds MapViewPixelBounds { get; set; }
        public Point MapLayerPixelOrigin { get; set; }
    }
}
