function roadRadar(currentSpeed, area){
    let motorwayLimit = 130;
    let interstateLimit = 90;
    let cityLimit = 50;
    let residentialLimit = 20;

    switch(area){
        case 'motorway':
            if(currentSpeed <= motorwayLimit){
                console.log(`Driving ${currentSpeed} km/h in a ${motorwayLimit} zone`);
            } else{
                if(currentSpeed <= (motorwayLimit + 20)){
                    let status = 'speeding';
                    console.log(`The speed is ${currentSpeed - motorwayLimit} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`);
                } else if(currentSpeed <= (motorwayLimit + 40)){
                    let status = 'excessive speeding';
                    console.log(`The speed is ${currentSpeed - motorwayLimit} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`);
                }
                else{
                    let status = 'reckless driving';
                    console.log(`The speed is ${currentSpeed - motorwayLimit} km/h faster than the allowed speed of ${motorwayLimit} - ${status}`);
                }
            }
            break;
        case 'interstate':
            if(currentSpeed <= interstateLimit){
                console.log(`Driving ${currentSpeed} km/h in a ${interstateLimit} zone`);
            } else{
                if(currentSpeed <= (interstateLimit + 20)){
                    let status = 'speeding';
                    console.log(`The speed is ${currentSpeed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
                } else if(currentSpeed <= (interstateLimit + 40)){
                    let status = 'excessive speeding';
                    console.log(`The speed is ${currentSpeed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
                }
                else{
                    let status = 'reckless driving';
                    console.log(`The speed is ${currentSpeed - interstateLimit} km/h faster than the allowed speed of ${interstateLimit} - ${status}`);
                }
            }
            break;
        case 'city':
            if(currentSpeed <= cityLimit){
                console.log(`Driving ${currentSpeed} km/h in a ${cityLimit} zone`);
            } else{
                if(currentSpeed <= (cityLimit + 20)){
                    let status = 'speeding';
                    console.log(`The speed is ${currentSpeed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
                } else if(currentSpeed <= (cityLimit + 40)){
                    let status = 'excessive speeding';
                    console.log(`The speed is ${currentSpeed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
                }
                else{
                    let status = 'reckless driving';
                    console.log(`The speed is ${currentSpeed - cityLimit} km/h faster than the allowed speed of ${cityLimit} - ${status}`);
                }
            }
            break;
        case 'residential':
            if(currentSpeed <= residentialLimit){
                console.log(`Driving ${currentSpeed} km/h in a ${residentialLimit} zone`);
            } else{
                if(currentSpeed <= (residentialLimit + 20)){
                    let status = 'speeding';
                    console.log(`The speed is ${currentSpeed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${status}`);
                } else if(currentSpeed <= (residentialLimit + 40)){
                    let status = 'excessive speeding';
                    console.log(`The speed is ${currentSpeed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${status}`);
                }
                else{
                    let status = 'reckless driving';
                    console.log(`The speed is ${currentSpeed - residentialLimit} km/h faster than the allowed speed of ${residentialLimit} - ${status}`);
                }
            }
            break;
    }
}

roadRadar(200, 'motorway');