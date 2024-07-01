import { useState } from "react";

function Counter() {
    const [count, setCount] = useState(() => 0);

    let paragraphText = '';
    let textColor = '';


    if(count < 0) {
        paragraphText = `Negative: ${count}`;
        textColor = 'red';
    } else if(count > 0) {
        paragraphText = `Positive: ${count}`;
        textColor = 'green';
    } else{
        paragraphText = `${count}`;
    }

    return (
        <>
            <h2 style={{color: textColor}}>{paragraphText}</h2>
            <button style={{marginRight: '10px'}} onClick={() => setCount(oldState => oldState - 1)}>-</button>
            <button style={{marginRight: '10px'}} onClick={() => setCount(oldState => 0)}>0</button>
            <button onClick={() => setCount(oldState => oldState + 1)}>+</button>
        </>
    );
}

export default Counter;