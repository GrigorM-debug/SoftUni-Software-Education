function solve(sentence, word){
    let symbol = '*';

    while(sentence.includes(word)){
        sentence = sentence.replace(word, symbol.repeat(word.length));
    }

    console.log(sentence);
}

solve('A small sentence with some words', 'small');