using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A vector line overlay <see cref="Layer"/>.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#polyline"/>
    /// </summary>
    public class Polyline : Path
    {
        /// <summary>
        /// An array of points defining the shape.
        /// </summary>
        [JsonIgnore] public IEnumerable<LatLng> LatLngs { get; }
        /// <summary>
        /// The <see cref="PolylineOptions"/> used to define the Polyline.
        /// </summary>
        [JsonIgnore] public PolylineOptions Options { get; }

        /// <summary>
        /// Constructs a Polyline.
        /// </summary>
        /// <param name="latLngs">An array of points defining the shape.</param>
        /// <param name="options">The <see cref="PolylineOptions"/> used to define the polyline.</param>
        public Polyline(IEnumerable<LatLng> latLngs, PolylineOptions options)
        {
            LatLngs = latLngs;
            Options = options;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.polyline", LatLngs.ToArray(), Options);
        }

        /// <summary>
        /// Adds a point to the Polyline
        /// </summary>
        /// <param name="latLng">The point to add to the Polyline.</param>
        /// <returns>The Polyline.</returns>
        public async Task<Polyline> AddLatLng(LatLng latLng)
        {
            GuardAgainstNullBinding("Cannot remove layer from map. No JavaScript binding has been set up.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Polyline.addLatLng", this.JSObjectReference, latLng);
            return this;
        }
    }
}
