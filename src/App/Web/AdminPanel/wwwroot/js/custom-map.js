const map = {
    marker: null,
    latitude: $('#Latitude'),
    longitude: $('#Longitude'),
    map: null,

    initMap: function () {
        this.map = new GMaps({
            el: '#map',
            lat: (!this.latitude.val()) ? this.latitude.val() : -10.181472,
            lng: (!this.longitude.val()) ? this.longitude.val() : -48.337768,
            click: function (e) {
                console.log(this.marker);
                if (this.marker) {
                    return;
                }
                this.latitude.val(e.latLng.lat());
                this.longitude.val(e.latLng.lng());
                this.addMarker(e.latLng.lat(), e.latLng.lng());
            },
        });

        if (this.latitude.val() !== '' || this.longitude.val() !== '') {
            this.addMarker(this.latitude.val(), this.longitude.val());
        }
    },

    addMarker: function () {
        this.marker = this.map.addMarker({
            lat: this.latitude,
            lng: this.longitude,
            title: "Ponto de Parada",
            infoWindow: {
                content: '<p>' + '' + '</p>'
            },
            dblclick: function (m) {
                this.map.removeMarker(this.marker);
                // caso remova o marcador, limpar os valores das coordenadas
                this.latitude.val('');
                this.longitude.val('');
                this.marker = null;
            },
            draggable: true,
            dragend: function (m) {
                // Atualiza os valores das coordenadas caso o marcador seja arrastado no mapa
                this.latitude.val(m.latLng.lat());
                this.longitude.val(m.latLng.lng());
            }
        });
    }
}