using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet
{
    /// <summary>
    /// Abstract base class for types that represent JavaScript objects.
    /// </summary>
    public abstract class InteropObject
    {
        /// <summary>
        /// The JavaScript runtime object reference.
        /// </summary>
        protected JsRuntimeObjectRef _jsObjRef;

        /// <summary>
        /// The ID of the JavaScript runtime object reference, used as key to a collection of JavaScript objects.
        /// </summary>
        [JsonPropertyName("__jsObjRefId")]
        public int JsObjectRefId { get { return _jsObjRef.JsObjectRefId; } }

        /// <summary>
        /// Creates the JavaScript object, stores a reference to it and the
        /// JavaScript runtime object used to create it.
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime instance used to create the object</param>
        /// <returns>A task that represents the async create opertion</returns>
        public async Task BindToJsRuntime(IJSRuntime jsRuntime)
        {
            _jsObjRef = await CreateJsObjectRef(jsRuntime);
            _jsObjRef.JSRuntime = jsRuntime;
        }

        /// <summary>
        /// Creates the JavaScript object
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime instance used to create the object.</param>
        /// <returns>The reference to the new JavaScript object.</returns>
        protected abstract Task<JsRuntimeObjectRef> CreateJsObjectRef(IJSRuntime jsRuntime);
    }
}
