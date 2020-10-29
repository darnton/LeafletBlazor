using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A leaflet Map object, used to create a Map on a page.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#map-methods-for-modifying-map-state"/>.
    /// </summary>
    public class Map : InteropObject
    {
        /// <summary>
        /// The ID of the HTML element the map will be rendered in.
        /// </summary>
        [JsonIgnore] public string ElementId { get; }
        /// <summary>
        /// The <see cref="MapOptions"/> used to create the Map.
        /// </summary>
        [JsonIgnore] public MapOptions Options { get; }

        /// <summary>
        /// Constructs a Map.
        /// </summary>
        /// <param name="elementId">The ID of the HTML element the map will be rendered in.</param>
        /// <param name="options">The <see cref="MapOptions"/> used to create the Map.</param>
        public Map(string elementId, MapOptions options)
        {
            ElementId = elementId;
            Options = options;
        }

        /// <inheritdoc/>
        protected override async Task<JsRuntimeObjectRef> CreateJsObjectRef(IJSRuntime jsRuntime)
        {
            return await jsRuntime.InvokeAsync<JsRuntimeObjectRef>("LeafletMap.map", ElementId, Options);
        }
    }
}
