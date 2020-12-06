using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Darnton.Blazor.Leaflet.LeafletMap
{
    /// <summary>
    /// A point with x and y coordinates in pixels.
    /// </summary>
    public class Point : InteropObject
    {
        /// <summary>
        /// The x coordinate in pixels.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// The y corrdinate in pixels.
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Flag indicating whether coordinate values should be rounded.
        /// </summary>
        public bool Round { get; set; }

        /// <summary>
        /// Constructs a point
        /// </summary>
        /// <param name="x">The x coordinate in pixels.</param>
        /// <param name="y">The y corrdinate in pixels.</param>
        /// <param name="round">Flag indicating whether coordinate values should be rounded.</param>
        public Point(double x, double y, bool round = false)
        {
            X = x;
            Y = y;
            Round = round;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.point", X, Y, Round);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}