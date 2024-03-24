function extract(contentId) {
    const contentElement = document.getElementById(contentId);

    const content = contentElement.textContent;

    const matches = content.match(/(\([(A-Za-z ]+)\)/g);

    const result = matches.map(match => match.slice(1, match.length-1)).join('; ');
    // let result= [];

    // for(let match of matches){
    //     match = match.replace('(', '');
    //     match = match.replace(')', '');
    //     result.push(match);
    // }
    return result;
}