async function loadRepos() {
   const divElement = document.getElementById('res');

   //With Asynchronous functions
   const response = await fetch("https://api.github.com/users/testnakov/repos");
   const repositories = await response.text();

   divElement.textContent = repositories;

   //With Fetch API
   const baseURL = "https://api.github.com/users/testnakov/repos";

   fetch(baseURL)
      .then(response => response.text())
      .then(data => {
         divElement.textContent = data;
      })
}