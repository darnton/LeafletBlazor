using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet
{
    /// <summary>
    /// A reference to a JavaScript object, used to invoke functions
    /// via JavaScript interop on previously created objects.
    /// </summary>
    public class JsRuntimeObjectRef : IAsyncDisposable
    {
        internal IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// JavaScript object reference id, used as key to a collection of JavaScript objects.
        /// </summary>
        [JsonPropertyName("__jsObjRefId")]
        public int JsObjectRefId { get; set; }

        /// <summary>
        /// Disposes the reference to the object. Removes the reference from the JavaScript collection
        /// </summary>
        /// <returns>A ValueTask representing the async JavaScript invocation to remove the reference.</returns>
        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("deviceInterop.removeObjectRef", JsObjectRefId);
        }
    }
}
