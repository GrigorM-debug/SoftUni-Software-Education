function lockedProfile() {
    const profilesElements = document.querySelectorAll('.profile');

    for (const profileElement of profilesElements) {
        const showMoreButton = profileElement.querySelector('button');

        const lockRadioButton = profileElement.querySelector('input[value="lock"]');

        const userHiddedFields = showMoreButton.previousElementSibling;
    
        console.log(userHiddedFields)
        showMoreButton.addEventListener('click', () =>{
            if(lockRadioButton.checked){
                return;
            } else{
                if(showMoreButton.textContent === 'Show more'){
                    showMoreButton.textContent = 'Hide it';
                    userHiddedFields.style.display = 'block';
                } else{
                    showMoreButton.textContent = 'Show more';
                    userHiddedFields.style.display = 'none';
                }
            }
        });
    }
}