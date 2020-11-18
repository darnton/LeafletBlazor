using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// The LeafletMap Razor component used to render a <see cref="Map"/> and <see cref="TileLayer"/>.
    /// </summary>
    public class LeafletMapBase : ComponentBase, IAsyncDisposable
    {
        /// <summary>
        /// The JavaScript runtime instance used to create the <see cref="Map"/>.
        /// </summary>
        [Inject] public IJSRuntime JSRuntime { get; set; }
        private Task<IJSObjectReference> _leafletMapModule;
        private Task<IJSObjectReference> LeafletMapModule =>
            _leafletMapModule ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Darnton.Blazor.Leaflet/js/leaflet-map.js").AsTask();
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
                var mapModule = await LeafletMapModule;
                await Map.BindJsObjectReference(JSRuntime, mapModule);
                await TileLayer.BindJsObjectReference(JSRuntime, mapModule);
                await TileLayer.AddTo(Map);
            }
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (_leafletMapModule != null)
            {
                var mapModule = await _leafletMapModule;
                await mapModule.DisposeAsync();
            }
        }
    }
}
