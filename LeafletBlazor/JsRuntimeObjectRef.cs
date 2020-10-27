using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet
{
    /// <summary>
    /// A reference to a JavaScript object, used to invoke functions
    /// on previously created objects.
    /// </summary>
    public class JsRuntimeObjectRef : IAsyncDisposable
    {
        internal IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// JavaScript object reference id, used as key to a collection of JavaScript objects.
        /// </summary>
        [JsonPropertyName("__jsObjRefId")]
        public int JsObjectRefId { get; set; }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("deviceInterop.removeObjectRef", JsObjectRefId);
        }
    }
}
