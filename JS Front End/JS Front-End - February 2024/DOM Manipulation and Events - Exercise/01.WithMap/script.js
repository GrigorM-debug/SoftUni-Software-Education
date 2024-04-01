function create(words) {
   const contentElement = document.getElementById('content');

   const divElements = words
      .map(word => {
         const divElement = document.createElement('div');

         const paragraphElement = document.createElement('p')
         paragraphElement.textContent = word;
         paragraphElement.style.display = 'none';

         divElement.appendChild(paragraphElement);
         
         divElement.addEventListener('click', () => {
            paragraphElement.style.display = 'block';
         });

         return divElement;
      })
   // contentElement.appendChild(divElements)
   for(const div of divElements){
      contentElement.appendChild(div)
   }
}