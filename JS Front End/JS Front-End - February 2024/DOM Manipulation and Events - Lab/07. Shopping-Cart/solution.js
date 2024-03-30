function solve() {
   const addButtonsElements = document.getElementsByClassName('add-product');
   const textAreaElement = document.querySelector('textarea');
   const checkoutButtonElement = document.querySelector('.checkout');

   let boughtProducts = new Set();
   let totalPrice = 0;

   Array.from(addButtonsElements).forEach(addButtonElement =>{
      addButtonElement.addEventListener('click', () => {
         const parentElement = addButtonElement.parentElement.parentElement;
         const productName = parentElement.querySelector('.product-title').textContent;
         const productPrice = Number(parentElement.querySelector('.product-line-price').textContent);

         textAreaElement.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
         boughtProducts.add(productName);
         totalPrice += productPrice;
      });
   });

   checkoutButtonElement.addEventListener('click', () => {
      textAreaElement.textContent += `You bought ${Array.from(boughtProducts).join(', ')} for ${totalPrice.toFixed(2)}.`;

      Array.from(addButtonsElements).forEach(button => button.disabled = 'disabled');
      checkoutButtonElement.disabled = 'disabled'
   });
}