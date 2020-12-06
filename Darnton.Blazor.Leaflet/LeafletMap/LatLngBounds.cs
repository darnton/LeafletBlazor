using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A rectangular geographical area on a map.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#latlngbounds"/>
    /// </summary>
    public class LatLngBounds : InteropObject
    {
        private LatLng _corner1;
        private LatLng _corner2;

        /// <summary>
        /// Constructs a LatLngBounds instance.
        /// </summary>
        /// <param name="corner1">The first corner defining the bounds.</param>
        /// <param name="corner2">The second corner defining the bounds, diagonally opposite the first.</param>
        public LatLngBounds(LatLng corner1, LatLng corner2)
        {
            _corner1 = corner1;
            _corner2 = corner2;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.latLngBounds", _corner1.JSObjectReference, _corner2.JSObjectReference);
        }
    }
}