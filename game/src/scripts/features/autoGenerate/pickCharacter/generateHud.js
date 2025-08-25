function createRow(right, id) {
    const rowElement = document.createElement('div');
    rowElement.className = 'rows';
    rowElement.id = `${id}`;
    rowElement.style.right = `${right}px`;
    if (id === 1) {
        rowElement.style.paddingLeft = '14px';
    } else if (id === 2) {
        rowElement.style.paddingLeft = '14px';
    } else if (id === 3) {
        rowElement.style.paddingLeft = '14px';
    }
   
    rowElement.style.display = 'flex';
    rowElement.style.gap = '2px';

    charactersBoard.appendChild(rowElement);
}

function createUserDisplay(img) {
    const userDisplay = document.createElement('div');
    userDisplay.id = 'userDisplay';
    userDisplay.appendChild(img);
    document.getElementById("gameDisplay").appendChild(userDisplay);
} 