function areaOfFigures(input){
    let figure = input[0];

    switch(figure){
        case "square":
            let side = input[1];
            let area = side*side;
            console.log(area.toFixed(3));
            break;
        case "rectangle":
            let a = input[1];
            let b = input[2];
            let rectangleArea = a*b;
            console.log(rectangleArea.toFixed(3));
            break;
        case "circle":
            let radius = input[1];
            let circleArea = (radius * radius) * Math.PI;
            console.log(circleArea.toFixed(3));
            break;
        case "triangle":
            let traingleSide = input[1];
            let heigth = input[2];
            let triangleArea = (traingleSide * heigth) / 2;
            console.log(triangleArea.toFixed(3));
            break;
    }
}

areaOfFigures(["circle", "6"]);
