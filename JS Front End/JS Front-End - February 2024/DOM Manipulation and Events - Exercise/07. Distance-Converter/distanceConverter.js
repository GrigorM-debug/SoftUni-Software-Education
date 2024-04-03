function attachEventsListeners() {
    const inputDistanceElement = document.getElementById('inputDistance');
    const outputElement = document.getElementById('outputDistance');

    const selectedMenuFromElement = document.getElementById('inputUnits');
    const fromValue = selectedMenuFromElement.options[selectedMenuFromElement.selectedIndex].value;
    
    const selectedMenuToElement = document.getElementById('outputUnits');
    const toValue = selectedMenuToElement.options[selectedMenuToElement.selectedIndex].value;

    const buttonConvertElement = document.getElementById('convert');

    buttonConvertElement.addEventListener('click', () =>{
        const conversionKeyFormat = `${fromValue}-${toValue}`;

        const result = converter[conversionKeyFormat](inputDistanceElement.value);
        
        outputElement.disabled = true;
        outputElement.value = result;

        console.log(result)
    })

    const converter = {
        'km-m': kilometersToMeters,
        'km-cm': kilometersToCentimeters,
        'km-mm': kilometersToMillimeters,
        'km-mi': kilometersToMiles,
        'km-yrd': kilometersToYards,
        'km-ft': kilometersToFeet,
        'km-in': kilometersToInches,
    
        'm-km': metersToKilometers,
        'm-cm': metersToCentimeters,
        'm-mm': metersToMillimeters,
        'm-mi': metersToMiles,
        'm-yrd': metersToYards,
        'm-ft': metersToFeet,
        'm-in': metersToInches,
    
        'cm-km': centimetersToKilometers,
        'cm-m': centimetersToMeters,
        'cm-mm': centimetersToMillimeters,
        'cm-mi': centimetersToMiles,
        'cm-yrd': centimetersToYards,
        'cm-ft': centimetersToFeet,
        'cm-in': centimetersToInches,
    
        'mm-km': millimetersToKilometers,
        'mm-m': millimetersToMeters,
        'mm-cm': millimetersToCentimeters,
        'mm-mi': millimetersToMiles,
        'mm-yrd': millimetersToYards,
        'mm-ft': millimetersToFeet,
        'mm-in': millimetersToInches,
    
        'mi-km': milesToKilometers,
        'mi-m': milesToMeters,
        'mi-cm': milesToCentimeters,
        'mi-mm': milesToMillimeters,
        'mi-yrd': milesToYards,
        'mi-ft': milesToFeet,
        'mi-in': milesToInches,
    
        'yrd-km': yardsToKilometers,
        'yrd-m': yardsToMeters,
        'yrd-cm': yardsToCentimeters,
        'yrd-mm': yardsToMillimeters,
        'yrd-mi': yardsToMiles,
        'yrd-ft': yardsToFeet,
        'yrd-in': yardsToInches,
    
        'ft-km': feetToKilometers,
        'ft-m': feetToMeters,
        'ft-cm': feetToCentimeters,
        'ft-mm': feetToMillimeters,
        'ft-mi': feetToMiles,
        'ft-yrd': feetToYards,
        'ft-in': feetToInches,
    
        'in-km': inchesToKilometers,
        'in-m': inchesToMeters,
        'in-cm': inchesToCentimeters,
        'in-mm': inchesToMillimeters,
        'in-mi': inchesToMiles,
        'in-yrd': inchesToYards,
        'in-ft': inchesToFeet
    };
    

    
    // Miles Conversions
    function milesToKilometers(miles) {
        return miles * 1.60934;
    }

    function milesToMeters(miles) {
        return miles * 1609.344;
    }

    function milesToCentimeters(miles) {
        return miles * 160,934.4;
    }

    function milesToMillimeters(miles) {
        return miles * 1.609e6;
    }

    function milesToYards(miles) {
        return miles * 1760;
    }

    function milesToFeet(miles) {
        return miles * 5280;
    }

    function milesToInches(miles) {
        return miles * 63360;
    }

    // Yards Conversions
    function yardsToKilometers(yards) {
        return yards / 1094;
    }

    function yardsToMeters(yards) {
        return yards / 1.094;
    }

    function yardsToCentimeters(yards) {
        return yards * 91.44;
    }

    function yardsToMillimeters(yards) {
        return yards * 914.4;
    }

    function yardsToMiles(yards) {
        return yards / 1760;
    }

    function yardsToFeet(yards) {
        return yards * 3;
    }

    function yardsToInches(yards) {
        return yards * 36;
    }

    // Feet Conversions
    function feetToKilometers(feet) {
        return feet / 3281;
    }

    function feetToMeters(feet) {
        return feet / 3.281;
    }

    function feetToCentimeters(feet) {
        return feet * 30.48;
    }

    function feetToMillimeters(feet) {
        return feet * 304.8;
    }

    function feetToMiles(feet) {
        return feet / 5280;
    }

    function feetToYards(feet) {
        return feet / 3;
    }

    function feetToInches(feet) {
        return feet * 12;
    }


    // Kilometers Conversions
    function kilometersToMeters(kilometers) {
        return kilometers * 1000;
    }

    function kilometersToCentimeters(kilometers) {
        return kilometers * 100000;
    }

    function kilometersToMillimeters(kilometers) {
        return kilometers * 1000000;
    }

    function kilometersToMiles(kilometers) {
        return kilometers / 1.60934;
    }

    function kilometersToYards(kilometers) {
        return kilometers * 1093.61;
    }

    function kilometersToFeet(kilometers) {
        return kilometers * 3280.84;
    }

    function kilometersToInches(kilometers) {
        return kilometers * 39370.1;
    }

    // Meters Conversions
    function metersToKilometers(meters) {
        return meters / 1000;
    }

    function metersToCentimeters(meters) {
        return meters * 100;
    }

    function metersToMillimeters(meters) {
        return meters * 1000;
    }

    function metersToMiles(meters) {
        return meters / 1609.344;
    }

    function metersToYards(meters) {
        return meters * 1.09361;
    }

    function metersToFeet(meters) {
        return meters * 3.28084;
    }

    function metersToInches(meters) {
        return meters * 39.3701;
    }

    // Centimeters Conversions
    function centimetersToKilometers(centimeters) {
        return centimeters / 100000;
    }

    function centimetersToMeters(centimeters) {
        return centimeters / 100;
    }

    function centimetersToMillimeters(centimeters) {
        return centimeters * 10;
    }

    function centimetersToMiles(centimeters) {
        return centimeters / 160934;
    }

    function centimetersToYards(centimeters) {
        return centimeters / 91.44;
    }

    function centimetersToFeet(centimeters) {
        return centimeters / 30.48;
    }

    function centimetersToInches(centimeters) {
        return centimeters / 2.54;
    }

    // Millimeters Conversions
    function millimetersToKilometers(millimeters) {
        return millimeters / 1e6;
    }

    function millimetersToMeters(millimeters) {
        return millimeters / 1000;
    }

    function millimetersToCentimeters(millimeters) {
        return millimeters / 10;
    }

    function millimetersToMiles(millimeters) {
        return millimeters / 1.609e6;
    }

    function millimetersToYards(millimeters) {
        return millimeters / 914.4;
    }

    function millimetersToFeet(millimeters) {
        return millimeters / 304.8;
    }

    function millimetersToInches(millimeters) {
        return millimeters / 25.4;
    }

    // Inches Conversions
    function inchesToKilometers(inches) {
        return inches / 39370;
    }

    function inchesToMeters(inches) {
        return inches / 39.37;
    }

    function inchesToCentimeters(inches) {
        return inches * 2.54;
    }

    function inchesToMillimeters(inches) {
        return inches * 25.4;
    }

    function inchesToMiles(inches) {
        return inches * 0.0000157828;
    }

    function inchesToYards(inches) {
        return inches * 0.0277778;
    }

    function inchesToFeet(inches) {
        return inches * 0.0833333;
    }
}



