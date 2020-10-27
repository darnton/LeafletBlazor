namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// The options used when creating a <see cref="Layer"/>.
    /// </summary>
    public class LayerOptions
    {
        /// <summary>
        /// The string shown in the attribution control.
        /// May be required to show, e.g., tile provider's copyright message.
        /// </summary>
        public string Attribution { get; set; }
    }
}
