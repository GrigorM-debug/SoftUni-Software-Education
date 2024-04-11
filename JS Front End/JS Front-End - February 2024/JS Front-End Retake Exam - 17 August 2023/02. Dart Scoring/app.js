window.addEventListener("load", solve);

function solve() {
    const playerNameInputElement = document.getElementById('player');
    const scoreInputElement = document.getElementById('score');
    const roundInputElement = document.getElementById('round');

    const addButton = document.getElementById('add-btn');

    const sureListElement = document.getElementById('sure-list');
    const scoredListElement = document.getElementById('scoreboard-list');

    const clearButton = document.querySelector('.btn.clear');

    addButton.addEventListener('click', add);

    function add(){
      if(playerNameInputElement.value == "" || scoreInputElement.value == "" || roundInputElement.value == ""){
        return;
      }

      const playerName = playerNameInputElement.value;
      const score = scoreInputElement.value;
      const round = roundInputElement.value;

      const liElement = document.createElement('li');
      liElement.classList.add('dart-item');

      const articleElement = document.createElement('article');

      const playerNameParagraph = document.createElement('p');
      playerNameParagraph.textContent = `${playerName}`;

      const scoreParagraph = document.createElement('p');
      scoreParagraph.textContent = `Score: ${score}`;

      const roundParagraph = document.createElement('p');
      roundParagraph.textContent = `Round: ${round}`;

      articleElement.appendChild(playerNameParagraph);
      articleElement.appendChild(scoreParagraph);
      articleElement.appendChild(roundParagraph);
      
      const editButton = document.createElement('button');
      editButton.textContent = 'edit';
      editButton.classList.add('btn', 'edit');

      const okButton = document.createElement('button');
      okButton.textContent = 'ok'
      okButton.classList.add('btn', 'ok');

      liElement.appendChild(articleElement);
      liElement.appendChild(editButton);
      liElement.appendChild(okButton);

      sureListElement.appendChild(liElement);

      addButton.disabled = true;

      playerNameInputElement.value = '';
      scoreInputElement.value = '';
      roundInputElement.value = '';

      editButton.addEventListener('click', edit)

      function edit(){
        playerNameInputElement.value = playerName;
        scoreInputElement.value = score;
        roundInputElement.value = round;

        sureListElement.removeChild(liElement);
        addButton.disabled = false;
      }

      okButton.addEventListener('click', ok)

      function ok(){
        sureListElement.removeChild(liElement);

        liElement.removeChild(editButton);
        liElement.removeChild(okButton);

        scoredListElement.appendChild(liElement);

        addButton.disabled = false;
      }

      clearButton.addEventListener('click', () =>{
        window.location.reload();
      });
    }
}
  