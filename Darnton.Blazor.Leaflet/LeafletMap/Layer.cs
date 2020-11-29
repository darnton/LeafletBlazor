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
            if (JSBinder is null)
            {
                await BindJsObjectReference(map.JSBinder);
            }
            GuardAgainstNullBinding("Cannot add layer to map. No JavaScript binding has been set up.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Layer.addTo", this.JSObjectReference, map.JSObjectReference);
            return this;
        }

        /// <summary>
        /// Removes the Layer from the <see cref="Map"/> it's currently active on.
        /// </summary>
        /// <returns>The Layer.</returns>
        public async Task<Layer> Remove()
        {
            GuardAgainstNullBinding("Cannot remove layer from map. No JavaScript binding has been set up.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Layer.remove", this.JSObjectReference);
            return this;
        }
    }
}
