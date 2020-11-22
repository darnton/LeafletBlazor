using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A raster <see cref="Layer"/> used to display tiled images.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#tilelayer"/>
    /// </summary>
    public class TileLayer : Layer
    {
        /// <summary>
        /// A URL template string with formatting options for subdomain, zoom level, coordinates, and resolution.
        /// </summary>
        /// <example>
        /// <code>
        /// http://{s}.somedomain.com/blabla/{z}/{x}/{y}{r}.png
        /// </code>
        /// </example>
        [JsonIgnore] public string UrlTemplate { get; }
        /// <summary>
        /// The <see cref="TileLayerOptions"/> used to create the TileLayer.
        /// </summary>
        [JsonIgnore] public TileLayerOptions Options { get; }

        /// <summary>
        /// Constructs a TileLayer
        /// </summary>
        /// <param name="urlTemplate">A URL template string with formatting options for subdomain, zoom level, coordinates, and resolution.</param>
        /// <param name="options">The <see cref="TileLayerOptions"/> used to create the TileLayer.</param>
        public TileLayer(string urlTemplate, TileLayerOptions options)
        {
            UrlTemplate = urlTemplate;
            Options = options;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.tileLayer", UrlTemplate, Options);
        }
    }
}
