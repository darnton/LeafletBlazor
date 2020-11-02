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
        public IJSObjectReference JSObjectReference;

        /// <summary>
        /// Creates the JavaScript object, stores a reference to it and the
        /// JavaScript runtime object used to create it.
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime instance used to create the object</param>
        /// <returns>A task that represents the async create operation.</returns>
        public async Task BindJsObjectReference(IJSRuntime jsRuntime)
        {
            JSObjectReference = await CreateJsObjectRef(jsRuntime);
        }

        /// <summary>
        /// Creates the JavaScript object
        /// </summary>
        /// <param name="jsRuntime">The JavaScript runtime instance used to create the object.</param>
        /// <returns>The reference to the new JavaScript object.</returns>
        protected abstract Task<IJSObjectReference> CreateJsObjectRef(IJSRuntime jsRuntime);
    }
}
