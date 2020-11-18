using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet
{
    /// <summary>
    /// Abstract base class for types that represent JavaScript objects.
    /// </summary>
    public abstract class InteropObject : IAsyncDisposable
    {
        /// <summary>
        /// The runtime used to create the JavaScript object.
        /// </summary>
        protected IJSRuntime _jsRuntime;

        /// <summary>
        /// The JavaScript module reference used to invoke functions that wrap Leaflet behaviour.
        /// </summary>
        protected IJSObjectReference _leafletMapModule;

        /// <summary>
        /// The JavaScript runtime object reference.
        /// </summary>
        public IJSObjectReference JSObjectReference;

        /// <summary>
        /// Creates the JavaScript object, stores a reference to it and the
        /// JavaScript runtime object used to create it.
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime instance used to create the object</param>
        /// <param name="leafletMapModule">The module reference used to invoke this component's JavaScript function</param>
        /// <returns>A task that represents the async create operation.</returns>
        public async Task BindJsObjectReference(IJSRuntime jsRuntime, IJSObjectReference leafletMapModule)
        {
            _jsRuntime = jsRuntime;
            _leafletMapModule = leafletMapModule;
            JSObjectReference = await CreateJsObjectRef();
        }

        /// <summary>
        /// Creates the JavaScript object
        /// </summary>
        /// <returns>The reference to the new JavaScript object.</returns>
        protected abstract Task<IJSObjectReference> CreateJsObjectRef();

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await JSObjectReference.DisposeAsync();
        }
    }
}
