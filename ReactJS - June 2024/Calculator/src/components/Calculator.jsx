import { useState } from "react";

function Calculator() {
    const [displayValue, setDiplayValue] = useState(() => '');

    const handleButtonClick = (value) => {
        setDiplayValue(displayValue + value);
    };

    const handleClearButtonClick = () => {
        setDiplayValue(() => '');
    }

    const handleEqualButtonClick = () => {
        /* This eval() function is very interesting. So it takes as argument the string value from the display input. 
        Example: "2+2". It takes it and calculates the result, which in this example is 4;
        */
        const result = eval(displayValue);
        setDiplayValue(String(result));
    }

    return (
            <div className="calculator-container">
            <form className="calculator">
                {/* Input */}
                <input type="text" className="display" name="display" readOnly value={displayValue}/>

                {/* Buttons */}
                <div className="buttons">
                    <input onClick={() => handleButtonClick('7')} id="button" type="button" className="diggits" value={7}/>
                    <input onClick={() => handleButtonClick('8')} id="button" type="button" className="diggits" value={8}/>
                    <input onClick={() => handleButtonClick('9')} id="button" type="button" className="diggits" value={9}/>
                    <input onClick={() => handleButtonClick(' + ')} id="button" type="button" className="math-buttons" value={'+'}/>
                    
                    <input onClick={() => handleButtonClick('4')} id="button" type="button" className="diggits" value={4}/>
                    <input onClick={() => handleButtonClick('5')} id="button" type="button" className="diggits" value={5}/>
                    <input onClick={() => handleButtonClick('6')} id="button" type="button" className="diggits" value={6}/>
                    <input onClick={() => handleButtonClick(' - ')} id="button" type="button" className="math-buttons" value={'-'}/>
                    
                    <input onClick={() => handleButtonClick('1')} id="button" type="button" className="diggits" value={1}/>
                    <input onClick={() => handleButtonClick('2')} id="button" type="button" className="diggits" value={2}/>
                    <input onClick={() => handleButtonClick('3')} id="button" type="button" className="diggits" value={3}/>
                    <input onClick={() => handleButtonClick(' * ')} id="button" type="button" className="math-buttons" value={'x'}/>

                    <input onClick={handleClearButtonClick} id="button" type="button" className="clear-button" value={'C'}/>
                    <input onClick={() => handleButtonClick('0')} id="button" type="button" className="diggits" value={0}/>
                    <input onClick={handleEqualButtonClick} id="button" type="button" className="math-buttons" value={'='}/>
                    <input onClick={() => handleButtonClick(' / ')} id="button" type="button" className="math-buttons" value={'/'}/>
                </div>
            </form>
        </div>
    );
}

export default Calculator;