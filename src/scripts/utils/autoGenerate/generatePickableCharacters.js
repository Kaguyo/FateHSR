const charactersBoard = document.getElementById('charactersBoard');

function registerCharacter(character) {
    const characterElement = document.createElement('div');
    characterElement.className = 'character';
    characterElement.innerHTML = `
        <h3>${character.name}</h3>
    `;
    charactersBoard.appendChild(characterElement);
}