function loadCommits() {
    const usernameInputElement = document.getElementById('username');
    const reposInputElement = document.getElementById('repo');
    const listElement = document.getElementById('commits');

    const username = usernameInputElement.value;
    const repositorieName = reposInputElement.value;

    const baseURL = "https://api.github.com/repos";

    fetch(`${baseURL}/${username}/${repositorieName}/commits`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`${response.status} (Not found)`);
            }

            return response.json();
        })
        .then(commits => {
            for(const commit of commits){
                const authorName = commit.commit.author.name
                const commitMessage = commit.commit.message;
                
                const liElement = document.createElement('li');
                liElement.textContent = `${authorName}: ${commitMessage}`;

                // listElement.innerHTML = '';
                listElement.appendChild(liElement);
            }
        })
        .catch(error => {
            const liElement = document.createElement('li')
            liElement.textContent = error;
            // listElement.innerHTML = '';
            listElement.appendChild(liElement);
        })
}