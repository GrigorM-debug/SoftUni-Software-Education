function create(words, event) {
   const contentElement = document.getElementById('content');

   const divElements = words
      .map(word => {
         const divElement = document.createElement('div');

         const paragraphElement = document.createElement('p')
         paragraphElement.textContent = word;
         paragraphElement.style.display = 'none';

         divElement.appendChild(paragraphElement);

         return divElement;
      }); 

   const fragment = document.createDocumentFragment();
   divElements.forEach(div => fragment.appendChild(div));
   contentElement.appendChild(fragment);

   contentElement.addEventListener('click', (event) =>{
      if(event.target.tagName === 'DIV'){
         const PElement = event.target.querySelector('p');
         PElement.style.display = 'block';
      }
   });
}