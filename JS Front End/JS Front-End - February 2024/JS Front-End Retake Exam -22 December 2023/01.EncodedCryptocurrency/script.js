function decodeCryptocurrency(commands) {
    let message = commands.shift(); 

    function takeEvenChars(str) {
        let result = "";
        for (let i = 0; i < str.length; i += 2) {
            result += str[i];
        }
        return result;
    }

    function replaceAll(str, substr, replacement) {
        return str.split(substr).join(replacement);
    }

    function reverseSubstring(str, substring) {
        if (str.includes(substring)) {
            const reversed = substring.split("").reverse().join("");
            str = str.replace(substring, "") + reversed;
            return str;
        } else {
            return "error";
        }
    }

    while (commands.length > 0 && commands[0] !== 'Buy') {
        const [command, arg1, arg2] = commands.shift().split('?');
        if (command === 'TakeEven') {
            message = takeEvenChars(message);
            console.log(message);
        } else if (command === 'ChangeAll') {
            message = replaceAll(message, arg1, arg2);
            console.log(message);
        } else if (command === 'Reverse') {
            message = reverseSubstring(message, arg1);
            console.log(message);
        }
    }

    console.log(`The cryptocurrency is: ${message}`);
}

decodeCryptocurrency([
    "ztsnotBztcoznztsVe!nzahc",
    "TakeEven",
    "Reverse?!nzahc",
    "ChangeAll?m?g",
    "Reverse?adshk",
    "ChangeAll?z?i",
    "Buy"
]);
