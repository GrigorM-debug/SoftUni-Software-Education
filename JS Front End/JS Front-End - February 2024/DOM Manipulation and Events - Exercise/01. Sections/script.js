function create(words) {
   const contentElement = document.getElementById('content');

   let divElements = [];
   for(const word of words){
      const divElement = document.createElement('div');

      const paragraphElement = document.createElement('p')
      paragraphElement.textContent = word;
      paragraphElement.style.display = 'none';

      divElement.appendChild(paragraphElement);
      
      divElement.addEventListener('click', () => {
         paragraphElement.style.display = 'block';
      });

      divElements.push(divElement);
   }

   // contentElement.appendChild(divElements)
   for(const div of divElements){
      contentElement.appendChild(div)
   }
}