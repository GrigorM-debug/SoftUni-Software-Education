window.addEventListener("load", solve);

function solve() {
    const nameInputElement = document.getElementById('name');
    const phoneInputElement = document.getElementById('phone');
    const categoryElement = document.getElementById('category');

    const addButton = document.getElementById('add-btn');
    const checkListElement = document.getElementById('check-list');
    const contactListElement = document.getElementById('contact-list');

    // const selectedCategory = categoryElement.options[categoryElement.selectedIndex].value;
    // const selectedCategory = categoryElement.options[categoryElement.selectedIndex]
    // let selectedCategory = categoryElement.value
    // console.log(selectedCategory)
    addButton.addEventListener('click', addElement);

    function addElement(){
      // const selectedCategory = categoryElement.options[categoryElement.selectedIndex].value;

      if(nameInputElement.value == "" || phoneInputElement.value == "" || categoryElement.value == ""){
        return;
      }

      const name = nameInputElement.value;
      const phone = phoneInputElement.value;
      const category = categoryElement.value;

      const liElement = document.createElement('li');

      const articleElement = document.createElement('article');
      
      const nameParagraph = document.createElement('p');
      nameParagraph.textContent = `name:${name}`;

      const phoneParagraph = document.createElement('p');
      phoneParagraph.textContent = `phone:${phone}`;

      const categoryParagraph = document.createElement('p');
      categoryParagraph.textContent = `category:${category}`;
    
      articleElement.appendChild(nameParagraph);
      articleElement.appendChild(phoneParagraph);
      articleElement.appendChild(categoryParagraph);

      const divButtons = document.createElement('div');
      divButtons.classList.add('buttons');

      const editButton = document.createElement('button');
      editButton.classList.add('edit-btn');

      const saveButton = document.createElement('button');
      saveButton.classList.add('save-btn');

      divButtons.appendChild(editButton);
      divButtons.appendChild(saveButton);

      
      liElement.appendChild(articleElement);
      liElement.appendChild(divButtons);
      checkListElement.appendChild(liElement);
      
      nameInputElement.value = '';
      phoneInputElement.value = '';
      categoryElement.selectedIndex = 0;
      categoryElement.value = ''
      //Need some fix

      editButton.addEventListener('click', edit);

      function edit(){
        nameInputElement.value = name;
        phoneInputElement.value = phone;
        categoryElement.value = category

        checkListElement.removeChild(liElement);
      }

      saveButton.addEventListener('click', save);

      function save(){
        const deleteButton = document.createElement('button')
        deleteButton.classList.add('del-btn')

        checkListElement.removeChild(liElement);

        liElement.removeChild(divButtons);

        liElement.appendChild(deleteButton);

        contactListElement.appendChild(liElement);

        deleteButton.addEventListener('click', () =>{
          contactListElement.removeChild(liElement);
        });
      }
    }
} 
  