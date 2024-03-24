function solve() {
  const textAreaElement = document.getElementById('input');
  const outputElement = document.getElementById('output');

  const text = textAreaElement.value;
  
  let sentences = text.split('.').filter(s => s.length !== 0);

  let result = [];

  for(let sentence of sentences){
    if(result.length === 3){
      createParagraghElement();
      result = [];
    }

    result.push(sentence);
  }
  
  createParagraghElement();

  function createParagraghElement(){
    const paragraghElement = document.createElement('p');
    paragraghElement.textContent = result.join('.') + '.';
    outputElement.appendChild(paragraghElement)
  }
}