function generateReport() {
    const selectedThElements = document.querySelectorAll('table thead th input[type="checkbox"]:checked');
    const selectedThElementsNames = Array.from(selectedThElements).map(input => input.getAttribute('name'));
    
    const tableRows = document.querySelectorAll('table tbody tr');

    const reportData = [];

    Array.from(tableRows).forEach(row => {
        const rowData = {};

        const tdElements = row.querySelectorAll('td');

        for(let i = 0; i < tdElements.length; i++){
            const columnName = selectedThElementsNames[i];

            if(columnName){
                rowData[columnName] = tdElements[i].textContent;
            }
        }

        reportData.push(rowData);
    });

    const outputArea = document.getElementById('output');

    outputArea.value = JSON.stringify(reportData, null, 2)
}