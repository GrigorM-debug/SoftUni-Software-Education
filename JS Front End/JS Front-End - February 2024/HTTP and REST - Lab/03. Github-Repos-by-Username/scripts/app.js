function loadRepos() {
	const inputElement = document.getElementById('username')
	const listElement = document.getElementById('repos');

	const baseURL = "https://api.github.com/users";

	const username = inputElement.value;

	fetch(`${baseURL}/${username}/repos`)
		.then(res => res.json())
		.then(repositories => {
			const fragment = document.createDocumentFragment();

			for(const repositorie of repositories){
				const fullName = repositorie.full_name;
				const htmlURL = repositorie.html_url;

				const liElement = document.createElement('li');
				const anchorTagElement = document.createElement('a')
				anchorTagElement.href = htmlURL;
				anchorTagElement.textContent = fullName;

				liElement.appendChild(anchorTagElement);
				fragment.appendChild(liElement);
			}

			listElement.innerHTML = '';
			listElement.appendChild(fragment)
		})
		.catch(error => {
			const liElement = document.createElement('li');
			liElement.textContent = inputElement.value;
			listElement.innerHTML = '';
			listElement.appendChild(liElement);
		})
}