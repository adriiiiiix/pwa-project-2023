window.initMap = function (instance) {
    var map = new L.Map("map").setView([44.4268, 26.1025], 13);
    var marker;

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

    var markersLayer = L.layerGroup().addTo(map);

    async function updateMapAddress() {
        var latlng = marker.getLatLng();
        var lat = latlng.lat;
        var lng = latlng.lng;

        // Call the OpenCage Geocoder API to convert the coordinates to an address
        const API_KEY = 'e1486109fa6d49c694b1ec19bd46e2f6'; // FREE TRAL - https://opencagedata.com/pricing - 2,500 REQ/DAY
        var url = `https://api.opencagedata.com/geocode/v1/json?q=${lat}+${lng}&key=${API_KEY}`;

        var address = '';
        var response = await fetch(url)
            .then(response => response.json())
            .then(data => {
                address = data.results[0];
            });

        // Update the input with the address
        instance.invokeMethodAsync("UpdateInput", JSON.stringify(address));
    }

    map.on('click', async (e) => {
        if (marker) {
            markersLayer.clearLayers();
        }
        marker = new L.marker(e.latlng).addTo(markersLayer);

        updateMapAddress();

        // Create an event handler for when the user moves the marker
        marker.on("dragend", updateMapAddress);

        // Make the marker draggable
        marker.dragging.enable();
    });


}