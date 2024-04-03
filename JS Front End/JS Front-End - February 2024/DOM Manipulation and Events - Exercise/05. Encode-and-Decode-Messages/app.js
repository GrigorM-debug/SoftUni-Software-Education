function encodeAndDecodeMessages() {
    const mainElement = document.getElementById('main');

    const sendMessageDivElement = mainElement.children[0];
    const receivedMessageDivElemenr = mainElement.children[1];

    const sendMessageTextAreaElement = sendMessageDivElement.querySelector('textarea');
    const receivedMessageTextAreaElement = receivedMessageDivElemenr.querySelector('textarea');

    const encodeAndSendButtonElement = sendMessageDivElement.querySelector('button');
    const decodeAndReadButtonElement = receivedMessageDivElemenr.querySelector('button');

    //Adding Event Listener using Event Delegation
    mainElement.addEventListener('click', (event) => {
        if(event.target.tagName === 'BUTTON'){
            if(event.target.parentElement === sendMessageDivElement){
                const sendedMessage = sendMessageTextAreaElement.value;
                let encodedMessage = '';

                for(let i = 0; i < sendedMessage.length; i++){
                    const char = sendedMessage.charAt(i);
                    const ascii = sendedMessage.charCodeAt(i);

                    if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122) || ascii === 32) {
                        const encodedAscii = ascii + 1;
                        const encodedChar = String.fromCharCode(encodedAscii);
                        encodedMessage += encodedChar;
                    } else {
                        encodedMessage += char;
                    }
                }
                receivedMessageTextAreaElement.value = encodedMessage;
                sendMessageTextAreaElement.value = '';
            } else if (event.target.parentElement === receivedMessageDivElemenr) {
                const receivedMessage = receivedMessageTextAreaElement.value;

                let decodedMessage = '';

                for(let i = 0; i < receivedMessage.length; i++){
                    const char = receivedMessage.charAt(i);
                    const ascii = receivedMessage.charCodeAt(i);

                    if ((ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122)) {
                        const decodedAscii = ascii - 1;

                        const decodedChar = String.fromCharCode(decodedAscii);
                        decodedMessage += decodedChar;
                    } else {
                        decodedMessage += char;
                    }
                }

                // decodedMessage = decodedMessage.replaceAll('!', ' ');

                //Because of the Judge System i must use this.
                decodedMessage = decodedMessage.split('!').join(' ');
                receivedMessageTextAreaElement.value = decodedMessage;
            }   
        }
    });
}