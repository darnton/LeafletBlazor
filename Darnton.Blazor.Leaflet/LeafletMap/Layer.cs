using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A layer that can be added to a <see cref="Map"/>.
    /// </summary>
    public abstract class Layer : InteropObject
    {
        /// <summary>
        /// Adds the layer to a <see cref="Map"/>.
        /// </summary>
        /// <param name="map">The <see cref="Map"/> to add the Layer to.</param>
        /// <returns>The Layer.</returns>
        public async Task<Layer> AddTo(Map map)
        {
            await _jsObjRef.JSRuntime.InvokeVoidAsync("LeafletMap.Layer.addTo", this, map);
            return this;
        }

        /// <summary>
        /// Removes the Layer from the <see cref="Map"/> it's currently active on.
        /// </summary>
        /// <returns>The Layer.</returns>
        public async Task<Layer> Remove()
        {
            await _jsObjRef.JSRuntime.InvokeVoidAsync("LeafletMap.Layer.remove", this);
            return this;
        }
    }
}
