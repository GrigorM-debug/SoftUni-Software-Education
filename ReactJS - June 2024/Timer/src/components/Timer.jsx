import { useState } from "react";

function Timer() {

    const [time, setTime] = useState(() => 20);

    let textContent = time === 0 ? 'Time ended' : `Time: ${time}`;
    let color = time === 0 ? 'red' : 'white';
    let textTransform = time === 0 ? 'uppercase' : 'none';

    setTimeout(() => {
        if(time ===0) {
            return;
        }
        setTime(time - 1)
    }, 1000)

    return (
        <>
            <h2 style={{color, textTransform}}>{textContent}</h2>
        </>
    );
}

export default Timer;