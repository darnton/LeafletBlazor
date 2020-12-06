export let LeafletMap = {

    Map: {

        setView: function (map, center, zoom) {
            map.setView(center, zoom);
        }

    },

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