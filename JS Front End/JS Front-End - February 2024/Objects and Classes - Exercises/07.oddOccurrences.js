function solve(input){
    const wordApperence = {};

    const words = input.split(' ');
    let count = 1;

    for(const word of words){
        if(Object.keys(wordApperence).some(key => key === word.toLowerCase())){
            // count++;
            wordApperence[word.toLowerCase()] += 1;
        }else{
            wordApperence[word.toLowerCase()] = count;
        }

        // if(!Object.keys(wordApperence).some(key => key === word.toLowerCase())){
        //     // count++;
        //     wordApperence[word.toLowerCase()] = 0;
        // }

        // wordApperence[word.toLowerCase()]++;
    }

    const wordAppearanceSorted = Object.entries(wordApperence);
    wordAppearanceSorted.sort((a, b) => b[1] - a[1]);

    const result = [];

    for (const [wordName, wordCount] of wordAppearanceSorted) {
        if(Number(wordCount) % 2 !== 0){
            result.push(wordName)
        }    
    }

    console.log(result.join(' '))
}

solve('Cake IS SWEET is Soft CAKE sweet Food')