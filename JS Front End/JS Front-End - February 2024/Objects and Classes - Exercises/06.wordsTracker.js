function solve(input){
    const wordsTracer = {};

    // const [wordOneToSearch, wordTwoToSearch] = input.shift().split(' ')
    const wordsToSearch = input.shift().split(' ');

    for(const wordToSearch of wordsToSearch){
        wordsTracer[wordToSearch] = 0;
    }

    // wordsTracer[wordOneToSearch] = 0;
    // wordsTracer[wordTwoToSearch]= 0;

    for(const word of input){
        if(wordsTracer.hasOwnProperty(word)){
            wordsTracer[word]+=1;
        }
    }

    const sortedWordTracker = Object.entries(wordsTracer).sort((a, b) => b[1] - a[1]);

    for (const [word, occurrences] of sortedWordTracker) {
        console.log(`${word} - ${occurrences}`)
    }
}

solve([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
    ]    
    )