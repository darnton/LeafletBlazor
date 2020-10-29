window.LeafletMap = {

    map: function (id, options) {
        return deviceInterop.storeObjRef(L.map(id, options));
    },

    marker: function (latlng, options) {
        return deviceInterop.storeObjRef(L.marker(latlng, options));
    },

    polyline: function (latlngs, options) {
        return deviceInterop.storeObjRef(L.polyline(latlngs, options));
    },

    tileLayer: function (urlTemplate, options) {
        return deviceInterop.storeObjRef(L.tileLayer(urlTemplate, options));
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