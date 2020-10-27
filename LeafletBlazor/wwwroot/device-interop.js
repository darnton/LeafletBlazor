var deviceInterop = deviceInterop || {};

deviceInterop.objRefs = {};
deviceInterop.objRefId = 0;
deviceInterop.objRefKey = '__jsObjRefId';
deviceInterop.storeObjRef = function (obj) {
    var id = deviceInterop.objRefId++;
    deviceInterop.objRefs[id] = obj;
    var objRef = {};
    objRef[deviceInterop.objRefKey] = id;
    return objRef;
}
deviceInterop.removeObjectRef = function (id) {
    delete deviceInterop.objRefs[id];
}

DotNet.attachReviver(function (key, value) {
    if (value &&
        typeof value === 'object' &&
        value.hasOwnProperty(deviceInterop.objRefKey) &&
        typeof value[deviceInterop.objRefKey] === 'number') {
        var id = value[deviceInterop.objRefKey];
        if (!(id in deviceInterop.objRefs)) {
            throw new Error("The JS object reference doesn't exist: " + id);
        }
        const instance = deviceInterop.objRefs[id];
        return instance;
    } else {
        return value;
    }
});