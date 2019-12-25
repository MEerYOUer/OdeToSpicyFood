$(document).ready(function () {
    var myMap;
    var marker;
    var id = $('#restaurantId').val();

    $('#mapBtn').click(function () {
        $('#mapBtn').hide();
        getRestaurant();
    });

    function getRestaurant() {
        $.ajax("/api/restaurants/" + id, {
            method: "get",
            success: function (response, status, xhr) {
                let address = response.street + "+" + response.city + "+" + response.state + "+" + response.zip;
                let urlAddress = address.replace(/\s/g, "+");

                getCoordinates(urlAddress);
            },
            error: function (xhr, status, error) {
                console.log("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            }
        });
    }

    function getCoordinates(address) {
        $.ajax({
            type: "get",
            url: "https://geocoder.ls.hereapi.com/6.2/geocode.json?apiKey=vwlMPFVBhdVCkonC_oL4dcR1EKqqOnuP13wfsyH3v2E&searchtext=" + address,
            dataType: "json",
            success: function (response, status, xhr) {
                console.log(response); // testing
                let lat = response.Response.View[0].Result[0].Location.DisplayPosition.Latitude;
                let long = response.Response.View[0].Result[0].Location.DisplayPosition.Longitude;
                console.log(lat + ", " + long); // testing

                getMap(lat, long);
            },
            error: function (xhr, status, error) {
                console.log("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText);
            }
        });
    }

    function getMap(lat, long) {
        myMap = L.map('mapid').setView([lat, long], 15);
        marker = L.marker([lat, long]).addTo(myMap);
        L.tileLayer('https://api.mapbox.com/styles/v1/{id}/tiles/{z}/{x}/{y}?access_token=pk.eyJ1IjoibWVlcnlvdWVyIiwiYSI6ImNrNGVrdDlxdTA2NXkzZmxvZHc5MGdmeW0ifQ.R1ld4VEoVEEBEZu6WZO1lw', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox/streets-v11',
            accessToken: 'your.mapbox.access.token'
        }).addTo(myMap);
    }

    
});