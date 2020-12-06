using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A leaflet Map object, used to create a Map on a page.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#map-methods-for-getting-map-state"/>
    /// and <see href="https://leafletjs.com/reference-1.7.1.html#map-methods-for-modifying-map-state"/>.
    /// </summary>
    public class Map : InteropObject
    {
        /// <summary>
        /// The ID of the HTML element the map will be rendered in.
        /// </summary>
        public string ElementId { get; }
        /// <summary>
        /// The <see cref="MapOptions"/> used to create the Map.
        /// </summary>
        public MapOptions Options { get; }

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
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.map", ElementId, Options);
        }

        #region Get map state
        /// <summary>
        /// Gets the point at the centre of the map view.
        /// </summary>
        /// <returns>A <see cref="LatLng"/> representing the geographical centre of the map.</returns>
        public async Task<LatLng> GetCenter()
        {
            return await JSObjectReference.InvokeAsync<LatLng>("getCenter");
        }

        /// <summary>
        /// Gets the geographical bounds of the map view.
        /// </summary>
        /// <returns>A <see cref="LatLngBounds"/> object representing the geographical bounds of the map.</returns>
        public async Task<LatLngBounds> GetBounds()
        {
            return await JSObjectReference.InvokeAsync<LatLngBounds>("getBounds");
        }

        /// <summary>
        /// Gets the zoom level of the map view.
        /// </summary>
        /// <returns>The zoom level.</returns>
        public async Task<int> GetZoom()
        {
            return await JSObjectReference.InvokeAsync<int>("getZoom");
        }

        /// <summary>
        /// Gets the minimum zoom level of the map view.
        /// </summary>
        /// <returns>The minimum zoom level.</returns>
        public async Task<int> GetMinZoom()
        {
            return await JSObjectReference.InvokeAsync<int>("getMinZoom");
        }

        /// <summary>
        /// Gets the maximum zoom level of the map view.
        /// </summary>
        /// <returns>The maximum zoom level.</returns>
        public async Task<int> GetMaxZoom()
        {
            return await JSObjectReference.InvokeAsync<int>("getMaxZoom");
        }

        /// <summary>
        /// Gets the maximum zoom level on which the bounds fit the map view.
        /// </summary>
        /// <param name="bounds">The <see cref="LatLngBounds"/> to fit to the map.</param>
        /// <param name="inside">A flag indicating the fit direction. If true, method returns minimum zoom level
        /// on which the map fits into the bounds.</param>
        /// <param name="padding">The padding in pixels.</param>
        /// <returns></returns>
        public async Task<int> GetBoundsZoom(LatLngBounds bounds, bool inside = false, Point padding = null)
        {
            if (bounds.JSBinder is null)
            {
                await bounds.BindJsObjectReference(this.JSBinder);
            }
            bounds.GuardAgainstNullBinding("Cannot get bounds zoom. No JavaScript binding has been set up for the bounds parameter.");
            if (padding is not null)
            {
                if (padding.JSBinder is null)
                {
                    await padding.BindJsObjectReference(this.JSBinder);
                }
                padding.GuardAgainstNullBinding("Cannot get bounds zoom. No JavaScript binding has been set up for the padding parameter.");
            }
            return await JSObjectReference.InvokeAsync<int>("getBoundsZoom", bounds.JSObjectReference, inside, padding?.JSObjectReference);
        }

        /// <summary>
        /// Gets the size of the map container in pixels.
        /// </summary>
        /// <returns>A <see cref="Point"/> representing the size of the map container in pixels.</returns>
        public async Task<Point> GetSize()
        {
            return await JSObjectReference.InvokeAsync<Point>("getSize");
        }

        /// <summary>
        /// Gets the bounds of the map view in projected pixel coordinates.
        /// </summary>
        /// <returns>A <see cref="Bounds"/> representing the size of the map container in pixels.</returns>
        public async Task<Bounds> GetPixelBounds()
        {
            return await JSObjectReference.InvokeAsync<Bounds>("getPixelBounds");
        }

        /// <summary>
        /// Gets the projected pixel coordinates of the top left point of the map layer.
        /// </summary>
        /// <returns>A <see cref="Point"/> representing top left point of the map in pixels.</returns>
        public async Task<Point> GetPixelOrigin()
        {
            return await JSObjectReference.InvokeAsync<Point>("getPixelOrigin");
        }

        /// <summary>
        /// Gets the world's bounds in pixel coordinates.
        /// </summary>
        /// <param name="zoom">The zoom level used to calculate the bounds. Current map zoom level is used if null or omitted.</param>
        /// <returns>A <see cref="Bounds"/> representing the size of the map container in pixels.</returns>
        public async Task<Bounds> GetPixelWorldBounds(int? zoom = null)
        {
            return await JSObjectReference.InvokeAsync<Bounds>("getPixelWorldBounds", zoom);
        }
        #endregion

        #region Set map state
        /// <summary>
        /// Sets the view of the map with the given centre and zoom.
        /// </summary>
        /// <param name="center">A <see cref="LatLng"/> representing the geogrpahical centre of the map.</param>
        /// <param name="zoom">The zoom level of the map.</param>
        /// <returns>The Map.</returns>
        public async Task<Map> SetView(LatLng center, int zoom)
        {
            if (center.JSBinder is null)
            {
                await center.BindJsObjectReference(this.JSBinder);
            }
            center.GuardAgainstNullBinding("Cannot set map view. No JavaScript binding has been set up for the center argument.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Map.setView", this.JSObjectReference, center.JSObjectReference, zoom);
            return this;
        }

        #endregion
    }
}
