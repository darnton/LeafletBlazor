using Darnton.Blazor.Leaflet.LeafletMap;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LeafletBlazorTestRig.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }

        protected Map PositionMap;
        protected TileLayer OpenStreetMapsTileLayer;

        public IndexBase() : base()
        {
            PositionMap = new Map("testMap", new MapOptions //Centred on New Zealand
            {
                Center = new LatLng(-42, 175),
                Zoom = 4
            });
            OpenStreetMapsTileLayer = new TileLayer(
                "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                new TileLayerOptions
                {
                    Attribution = @"Map data &copy; <a href=""https://www.openstreetmap.org/"">OpenStreetMap</a> contributors, " +
                        @"<a href=""https://creativecommons.org/licenses/by-sa/2.0/"">CC-BY-SA</a>"
                }
            );
        }
    }
}
