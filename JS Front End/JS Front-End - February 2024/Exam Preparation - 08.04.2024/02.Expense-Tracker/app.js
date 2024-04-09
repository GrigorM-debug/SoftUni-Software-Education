window.addEventListener("load", solve);

function solve(){
    const expenseTypeInputElement = document.getElementById('expense')
    const amountInputElement = document.getElementById('amount')
    const dateInputElement = document.getElementById('date')

    const addButtonElement = document.getElementById('add-btn');

    addButtonElement.addEventListener('click', pusblish) 

    function pusblish(){
        if(expenseTypeInputElement.value == "" || amountInputElement.value == "" || dateInputElement.value == ""){
            return;
        }

        
        const previewListElement = document.getElementById('preview-list');
        const expensesListElement = document.getElementById('expenses-list')
        const expenseType = expenseTypeInputElement.value;
        const amount = amountInputElement.value;
        const date = dateInputElement.value;
        const liElement = document.createElement('li');
        liElement.classList.add('expense-item');

        const articleElement = document.createElement('article');
        
        const typeParagraph = document.createElement('p');
        typeParagraph.textContent = `Type: ${expenseType}`;

        const amountParagraph = document.createElement('p');
        amountParagraph.textContent = `Amount: ${amount}$`;

        const dateParagraph = document.createElement('p');
        dateParagraph.textContent = `Date: ${date}`

        articleElement.appendChild(typeParagraph);
        articleElement.appendChild(amountParagraph);
        articleElement.appendChild(dateParagraph);

        const buttonsDivElement = document.createElement('div');
        buttonsDivElement.classList.add('buttons');

        const editButtonElement = document.createElement('button');
        editButtonElement.classList.add('btn', 'edit');
        editButtonElement.textContent = 'edit';

        buttonsDivElement.appendChild(editButtonElement)

        const okButtonElement = document.createElement('button');
        okButtonElement.classList.add('btn', 'ok');
        okButtonElement.textContent = 'ok';

        buttonsDivElement.appendChild(okButtonElement)

        liElement.appendChild(articleElement);
        liElement.appendChild(buttonsDivElement);

        previewListElement.appendChild(liElement);

        addButtonElement.disabled = true;

        expenseTypeInputElement.value = '';
        amountInputElement.value = '';
        dateInputElement.value ='';
        
        const editButton = document.querySelector('.btn.edit');

        editButton.addEventListener('click', () => {
            expenseTypeInputElement.value = expenseType;
            amountInputElement.value = amount;
            dateInputElement.value = date

            previewListElement.innerHTML = '';

            addButtonElement.disabled = false;
        })

        const okButton = document.querySelector('.btn.ok');

        okButton.addEventListener('click', () => {
            previewListElement.innerHTML = '';

            liElement.removeChild(buttonsDivElement)
            expensesListElement.appendChild(liElement);


            addButtonElement.disabled = false;
        })

        const deleteButtonElement = document.querySelector('.btn.delete');
        deleteButtonElement.addEventListener('click', () =>{
            window.location.reload();
        })
    }
}   

