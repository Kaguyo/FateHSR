function createRow(right) {
    const characterElement = document.createElement('div');
    characterElement.className = 'rows';
    characterElement.style.right = `${right}px`;
    charactersBoard.appendChild(characterElement);
}

function createUserDisplay(img) {
    const userDisplay = document.createElement('div');
    userDisplay.id = 'userDisplay';
    userDisplay.appendChild(img);
    document.getElementById("gameDisplay").appendChild(userDisplay);
} 