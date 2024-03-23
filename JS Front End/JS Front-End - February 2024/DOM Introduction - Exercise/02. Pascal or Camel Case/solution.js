function solve() {
  const textElement = document.getElementById('text');
  const namingConventionElement = document.getElementById('naming-convention');

  const resultElement = document.getElementById('result');

  const text = textElement.value;
  const namingConverntion = namingConventionElement.value;

  const pascalCaseConverter = (text) =>
    text
      .split(' ')
      .map(word => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
      .join('');
  
  const camelCaseConverter = (text) =>
    text
      .split(' ')
      .map((word, index) => index === 0 ? word.toLowerCase() : word.charAt(0).toUpperCase() + word.slice(1).toLowerCase())
      .join('');

  const converter = {
    'Pascal Case': pascalCaseConverter,
    'Camel Case': camelCaseConverter,
  }

  if(!converter[namingConverntion]){
    resultElement.textContent = 'Error!';
    return;
  }

  resultElement.textContent = converter[namingConverntion](text);
}