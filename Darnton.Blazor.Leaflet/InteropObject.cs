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
        /// The JavaScript binder used to talk to the interop layer.
        /// </summary>
        internal LeafletMapJSBinder JSBinder;

        /// <summary>
        /// The JavaScript runtime object reference.
        /// </summary>
        internal IJSObjectReference JSObjectReference;

        /// <summary>
        /// Creates the JavaScript object, stores a reference to it and the
        /// JavaScript runtime object used to create it.
        /// </summary>
        /// <param name="jsBinder">The JavaScript binder used to talk to the interop layer.</param>
        /// <returns>A task that represents the async create operation.</returns>
        internal async Task BindJsObjectReference(LeafletMapJSBinder jsBinder)
        {
            JSBinder = jsBinder;
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
            if (JSObjectReference != null)
                await JSObjectReference.DisposeAsync();
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the JavaScript binding has not been
        /// set up for this object.
        /// </summary>
        /// <param name="nullBindingMessage">The error message to be used when an exception is thrown.</param>
        internal void GuardAgainstNullBinding(string nullBindingMessage)
        {
            if (JSBinder is null)
            {
                throw new InvalidOperationException(nullBindingMessage);
            }
        }
    }
}
