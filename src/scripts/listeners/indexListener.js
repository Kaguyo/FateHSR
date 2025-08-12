const arcadeBtn = document.getElementById('arcadeBtn');
const coopBtn = document.getElementById('coopBtn');
const pvpBtn = document.getElementById('pvpBtn');
const settingsBtn = document.getElementById('settingsBtn');

arcadeBtn.onclick = (() => {
    window.location.href = "../views/pickCharacter.html";
    console.log("Arcade button clicked");
});
coopBtn.onclick = (() => {});
pvpBtn.onclick = (() => {});
settingsBtn.onclick = (() => {});