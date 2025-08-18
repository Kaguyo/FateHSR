const userDisplayImg = new Image();
userDisplayImg.src = "../assets/hud/userDisplay1.png";
createUserDisplay(userDisplayImg);


const charactersBoard = document.createElement('div');
charactersBoard.id = 'charactersBoard';
document.getElementById("gameDisplay").appendChild(charactersBoard);

createRow(2);
createRow(15);
createRow(28);

const blade = Character.createCharacter("Blade", 90);
const saber = Character.createCharacter("Saber", 90);
