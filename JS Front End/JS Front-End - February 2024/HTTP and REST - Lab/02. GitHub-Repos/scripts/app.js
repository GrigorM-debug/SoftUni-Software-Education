async function loadRepos() {
   const divElement = document.getElementById('res');

   const response = await fetch("https://api.github.com/users/testnakov/repos");
   const repositories = await response.text();

   divElement.textContent = repositories;
}