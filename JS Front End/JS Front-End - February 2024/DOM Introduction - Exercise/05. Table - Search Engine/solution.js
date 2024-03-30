function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const inputElement = document.getElementById('searchField');

      const trElements = document.querySelectorAll('table tbody tr');

      Array.from(trElements)
         .filter(trElement => {
            const tdElements = Array.from(trElement.children);
            const matches = tdElements.some(td => td.textContent.toLowerCase().includes(inputElement.value.toLowerCase()));

            if(matches){
               trElement.classList.add('select')
            } else{
               trElement.classList.remove('select')
            }
         });  

      inputElement.value = '';
   }
}