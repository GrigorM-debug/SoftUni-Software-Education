function search() {
   const townsElements = document.getElementById('towns').children;
   const searchTextElement = document.getElementById('searchText');

   const resultElement = document.getElementById('result');
   let mathes = 0;

   const searchText = searchTextElement.value;

   const towns = Array.from(townsElements);

   for (const town of towns) {
      if(town.textContent.toLowerCase().includes(searchText.toLowerCase())){
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
         mathes += 1;
      }
   }

   resultElement.textContent = `${mathes} matches found`;
}
