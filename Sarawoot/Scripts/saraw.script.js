//<script>
    function googleMapHome() {
        // The location of Uluru
        var myLatlng = {lat: 13.631933, lng: 100.685704 };//no.118/84 the color leuisur
	    // The html element to show maps
		var mapCanvas = document.getElementById('map');
		// Create option
        var mapOptions = {
			zoom: 15,
			center: myLatlng,
			//mapTypeId: 'satellite'
            mapTypeId: 'terrain'
        };
		// The map, centered at Uluru
		var map = new google.maps.Map(mapCanvas, mapOptions);
		// The marker, positioned at Uluru
		var marker = new google.maps.Marker({position: myLatlng, map: map });
	}
//</script>