function attachEventsListeners() {
    let measuresToMetersObj = {
        km: (unit) => unit * 1000,
        m: (unit) => unit * 1,
        cm: (unit) => unit * 0.01,
        mm: (unit) => unit * 0.001,
        mi: (unit) => unit * 1609.34,
        yrd: (unit) => unit * 0.9144,
        ft: (unit) => unit * 0.3048,
        in: (unit) => unit * 0.0254
    }
    
    let metersToMeasuresObj = {
        km: (unit) => unit / 1000,
        m: (unit) => unit / 1,
        cm: (unit) => unit / 0.01,
        mm: (unit) => unit / 0.001,
        mi: (unit) => unit / 1609.34,
        yrd: (unit) => unit / 0.9144,
        ft: (unit) => unit / 0.3048,
        in: (unit) => unit / 0.0254
    }

    let quantity = Number(document.getElementById('inputDistance').value)
    let measure = document.getElementById('inputUnits').value
    
    let buttonElement = document.getElementById('convert');

    buttonElement.addEventListener('click', () =>{
        let quantityInMeters = measuresToMeaters[measure](quantity)
    
        let finalMeasure = document.getElementById('outputUnits').value
        let finalQuantity = metersToMeasure[finalMeasure](quantityInMeters)
        
        let finalResultElement = document.getElementById('outputDistance')
        finalResultElement.value = finalQuantity;
    })
}




