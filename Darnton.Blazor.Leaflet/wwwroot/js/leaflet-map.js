export let LeafletMap = {

    Layer: {

        addTo: function (layer, map) {
            layer.addTo(map);
        },

        remove: function (layer) {
            layer.remove();
        }

    },

    Polyline: {

        addLatLng: function (polyline, latlng, latlngs) {
            polyline.addLatLng(latlng, latlngs);
        }

    }

}