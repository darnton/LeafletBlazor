using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// The LeafletMap Razor component used to render a <see cref="Map"/> and <see cref="TileLayer"/>.
    /// </summary>
    public class LeafletMapBase : ComponentBase
    {
        /// <summary>
        /// The JavaScript runtime instance used to create the <see cref="Map"/>.
        /// </summary>
        [Inject] public IJSRuntime JSRuntime { get; set; }
        /// <summary>
        /// The Leaflet <see cref="Map"/> to be rendered by the component.
        /// </summary>
        [Parameter] public Map Map { get; set; }
        /// <summary>
        /// The <see cref="TileLayer"/> to be added when the <see cref="Map"/> is rendered.
        /// </summary>
        [Parameter] public TileLayer TileLayer { get; set; }

        /// <inheritdoc/>
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Map.BindJsObjectReference(new LeafletMapJSBinder(JSRuntime));
                await TileLayer.AddTo(Map);
            }
        }
    }
}
