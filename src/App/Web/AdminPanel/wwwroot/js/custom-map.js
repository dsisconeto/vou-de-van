const map = {
    marker: null,
    latitude: null,
    longitude: null,
    map: null,

    initCoordinates: function () {
        this.latitude = $('#Latitude');
        this.longitude = $('#Longitude');
    },

    initMap: function () {
        let self = this;
        this.initCoordinates();
        this.map = new GMaps({
            el: '#map',
            lat: (!self.latitude.val()) ? self.latitude.val() : -10.181472,
            lng: (!self.longitude.val()) ? self.longitude.val() : -48.337768,
            click: function (e) {
                console.log(self.marker);
                if (self.marker) {
                    return;
                }
                self.latitude.val(e.latLng.lat());
                self.longitude.val(e.latLng.lng());
                self.addMarker(e.latLng.lat(), e.latLng.lng());
            },
        });

        //if (this.latitude.val() !== '' || this.longitude.val() !== '') {
        //    this.addMarker(this.latitude.val(), this.longitude.val());
        //}
    },

    addMarker: function (lat, long) {
        let self = this;
        let name = $('#Name').val();
        this.marker = this.map.addMarker({
            lat: lat,
            lng: long,
            title: "Ponto de Parada",
            infoWindow: {
                content: '<p>' + name + '</p>'
            },
            dblclick: function (m) {
                self.map.removeMarker(self.marker);
                // caso remova o marcador, limpar os valores das coordenadas
                self.latitude.val('');
                self.longitude.val('');
                self.marker = null;
            },
            draggable: true,
            dragend: function (m) {
                // Atualiza os valores das coordenadas caso o marcador seja arrastado no mapa
                self.latitude.val(m.latLng.lat());
                self.longitude.val(m.latLng.lng());
            }
        });
    }
}

$(function () {
    map.initMap();
});