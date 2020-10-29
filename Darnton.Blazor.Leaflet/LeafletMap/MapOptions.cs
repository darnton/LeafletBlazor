namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// The options used when creating a <see cref="Map"/>.
    /// </summary>
    public class MapOptions
    {
        /// <summary>
        /// The initial centre point of the <see cref="Map"/>.
        /// </summary>
        public LatLng Center { get; set; }
        /// <summary>
        /// The initial zoom level of the <see cref="Map"/>.
        /// </summary>
        public int Zoom { get; set; }
    }
}
