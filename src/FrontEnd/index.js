// Alocagem de atributos dos personagens
let atk;
let hpMax;
let hp;
let def;
let critDmg;
let critRate;
let ultCost;
let energy;
let speed;

let atkEnemy;
let hpMaxEnemy;
let hpEnemy;
let defEnemy;
let critDmgEnemy;
let critRateEnemy;
let ultCostEnemy;
let energyEnemy;
let speedEnemy;
// Fim alocagem de atributos de personagens
let collapseAttackList = 1;
let collapseEnemyInfo = 1;
let userJson = null;
let enemyJson = null;
let chamarApi = 0;
const button1Atk = document.getElementById("button1Atk");
const button2Atk = document.getElementById("button2Atk");
const button3Atk = document.getElementById("button3Atk");
const attackListContainer = document.getElementById("attackListContainer");
const healthBar = document.getElementById("healthBar");
const healthBarEnemy = document.getElementById("healthBarEnemy");
const bleedingHealthBarEnemy = document.getElementById("bleedingHealthBarEnemy");
const bleedingHealthBar = document.getElementById("bleedingHealthBar")
const character1 = document.getElementById("character1");
const character2 = document.getElementById("character2");
const character3 = document.getElementById("character3");
const character4 = document.getElementById("character4");
const pickCharacter = document.getElementById("pickCharacter");
const mySubmit = document.getElementById("mySubmit");
const selectedCharacter = document.getElementById("p1Message");
const showStatus = document.getElementById("showStatus");
const returnBtn = document.getElementById("returnBtn");
const radios = document.querySelectorAll('input[name="characterList"]'); // Seleciona todos os radios
let character = null;
let enemy = null;
let clickPhase = 1;
// Funcoes para hovering e style CSS ￬￬
const characterAttacks = document.getElementById("characterAttacks");
const upSideArrow = document.getElementById("upSideArrow");
const upSideDownArrow = document.getElementById("upSideDownArrow");
const upSideArrowEffect = document.getElementById("upSideArrowEffect");
const upSideArrowEffect1 = document.getElementById("upSideArrowEffect1");
const upSideDownArrowEffect = document.getElementById("upSideDownArrowEffect");
const upSideDownArrowEffect1 = document.getElementById("upSideDownArrowEffect1");
const enemyContainer = document.getElementById("enemyContainer");
const upSideArrowEnemy = document.getElementById("upSideArrowEnemy");
const upSideDownArrowEnemy = document.getElementById("upSideDownArrowEnemy");
const upSideArrowEffectEnemy = document.getElementById("upSideArrowEffectEnemy");
const upSideArrowEffect1Enemy = document.getElementById("upSideArrowEffect1Enemy");
const upSideDownArrowEffectEnemy = document.getElementById("upSideDownArrowEffectEnemy");
const upSideDownArrowEffect1Enemy = document.getElementById("upSideDownArrowEffect1Enemy");
const spdDataEnemy = document.getElementById("spdDataEnemy");
const atkDataEnemy = document.getElementById("atkDataEnemy");
const defDataEnemy = document.getElementById("defDataEnemy");
const enemyInfo = document.getElementById("enemyInfo");

const addHoverClasses = () => {
    characterAttacks.classList.add("active");
    if (collapseAttackList == 1) { // Aponta pra baixo
        upSideArrow.classList.add("hidden");
        upSideDownArrow.classList.add("active");
        upSideDownArrowEffect.classList.add("active");
        upSideDownArrowEffect1.classList.add("active");
    } else { // Aponta pra cima
        upSideArrow.classList.remove("hidden");
        upSideDownArrow.classList.remove("active");
        upSideArrowEffect.classList.add("active");
        upSideArrowEffect1.classList.add("active");
    }
};
const removeHoverClasses = () => {
    characterAttacks.classList.remove("active");
    if (collapseAttackList == 1) {
        upSideArrow.classList.remove("hidden");
        upSideDownArrow.classList.remove("active");
        upSideDownArrowEffect.classList.remove("active");
        upSideDownArrowEffect1.classList.remove("active");
    } else {
        upSideArrow.classList.add("hidden");
        upSideDownArrow.classList.add("active");
        upSideArrowEffect.classList.remove("active");
        upSideArrowEffect1.classList.remove("active");
    }
};
const addHoverClassesEnemy = () => {
    enemyContainer.classList.add("active");
    if (collapseEnemyInfo == 1) { // Aponta pra baixo
        upSideArrowEnemy.classList.remove("active");
        upSideDownArrowEnemy.classList.add("active");
        upSideDownArrowEffectEnemy.classList.add("active");
        upSideDownArrowEffect1Enemy.classList.add("active");
    } else { // Aponta pra cima
        upSideArrowEnemy.classList.add("active");
        upSideDownArrowEnemy.classList.remove("active");
        upSideArrowEffectEnemy.classList.add("active");
        upSideArrowEffect1Enemy.classList.add("active");
    }
};
const removeHoverClassesEnemy = () => {
    enemyContainer.classList.remove("active");
    if (collapseEnemyInfo == 1) {
        upSideArrowEnemy.classList.add("active");
        upSideDownArrowEnemy.classList.remove("active");
        upSideDownArrowEffectEnemy.classList.remove("active");
        upSideDownArrowEffect1Enemy.classList.remove("active");
    } else {
        upSideArrowEnemy.classList.remove("active");
        upSideDownArrowEnemy.classList.add("active");
        upSideArrowEffectEnemy.classList.remove("active");
        upSideArrowEffect1Enemy.classList.remove("active");
    }
};
characterAttacks.addEventListener('mouseenter', addHoverClasses);
characterAttacks.addEventListener('mouseleave', removeHoverClasses);
// EnemyListeners
enemyContainer.addEventListener('mouseenter', addHoverClassesEnemy);
enemyContainer.addEventListener('mouseleave', removeHoverClassesEnemy);

// Adiciona evento de mudança a todos os radios ￬￬
radios.forEach((radio) => {
    radio.addEventListener("change", checkSelection);
});

// Mudar cor do BACK com base nos inputs radio ￬￬
function checkSelection () {
    let isChecked = false;
    radios.forEach((radio) => {
        if (radio.checked) isChecked = true;
    });
    if (isChecked) {
        returnBtn.classList.add('hover-active');
    }
    else{
        returnBtn.classList.remove('hover-active');
    }
}
//  =========================================================
function TrackHealth(hpParameter, hpMaxParameter) {
    let fraction = (hpParameter / hpMaxParameter) * 100;
    if (hpMaxParameter == 0) { fraction = 0 };
    healthBar.style.width = `${fraction}%`;

    let speed = 120;
    
    let healthWidth = parseFloat(window.getComputedStyle(healthBar).width);
    let bleedingWidth = parseFloat(window.getComputedStyle(bleedingHealthBar).width);
    let deltaBleeding = Math.abs(healthWidth - bleedingWidth);
    let transitionDuration = deltaBleeding / speed; 

    bleedingHealthBar.style.transition = `width ${transitionDuration}s`;

    bleedingHealthBar.style.width = `${fraction}%`;
}
//  =========================================================
function TrackHealthEnemy(hpEnemyParameter, hpMaxEnemyParameter) {
    let fractionEnemy = (hpEnemyParameter / hpMaxEnemyParameter) * 100;
    if (hpMaxEnemyParameter == 0) { fractionEnemy = 0 };
    healthBarEnemy.style.width = `${fractionEnemy}%`;
    let speed = 120;

    let healthWidthEnemy = parseFloat(window.getComputedStyle(healthBarEnemy).width);
    let bleedingWidthEnemy = parseFloat(window.getComputedStyle(bleedingHealthBarEnemy).width);
    let deltaBleedingEnemy = Math.abs(healthWidthEnemy - bleedingWidthEnemy); 
    let transitionDurationEnemy = deltaBleedingEnemy / speed;

    bleedingHealthBarEnemy.style.transition = `width ${transitionDurationEnemy}s`;

    bleedingHealthBarEnemy.style.width = `${fractionEnemy}%`;
}

// onclick functions
const ClickAtk = characterAttacks.onclick = function () {
    if (collapseAttackList == 1) {
        removeHoverClasses();
        collapseAttackList = 2;
        addHoverClasses();
        attackListContainer.classList.add("active");
        button1Atk.classList.add("active");
        button2Atk.classList.add("active");
        button3Atk.classList.add("active");
        if (document.getElementById("button4Atk")) {
            button4Atk.classList.add("active");
            attackListContainer.classList.add("fourAttacksActive");
        }
    } else { 
        removeHoverClasses();
        collapseAttackList = 1;
        addHoverClasses();
        attackListContainer.classList.remove("active");
        button1Atk.classList.remove("active");
        button2Atk.classList.remove("active");
        button3Atk.classList.remove("active");
        if (document.getElementById("button4Atk")) {
            button4Atk.classList.remove("active");
            attackListContainer.classList.remove("fourAttacksActive");
        }
    }
}
enemyContainer.onclick = function () {
    if (collapseEnemyInfo == 1) {
        removeHoverClassesEnemy();
        collapseEnemyInfo = 2;
        addHoverClassesEnemy();
        atkDataEnemy.classList.add("active");
        defDataEnemy.classList.add("active");
        spdDataEnemy.classList.add("active");
        enemyInfo.classList.add("active");
    } else { 
        removeHoverClassesEnemy();
        collapseEnemyInfo = 1;
        addHoverClassesEnemy();
        atkDataEnemy.classList.remove("active");
        defDataEnemy.classList.remove("active");
        spdDataEnemy.classList.remove("active");
        enemyInfo.classList.remove("active");
    }
}    
returnBtn.onclick = function () {
    if (character1.checked || character2.checked || character3.checked || character4.checked) {
        radios.forEach((radio) => {radio.checked = false});
    }
    else if (clickPhase == 2) {
        if (collapseAttackList != 1) {
            ClickAtk();
            removeHoverClasses();
        }
        if (document.getElementById("button4Atk")) {
            attackListContainer.classList.remove("fourAttacks");
            attackListContainer.classList.remove("fourAttacksActive");
            button4Atk.remove();
        }
        C1img.classList.remove("active");
        C2img.classList.remove("active");
        C3img.classList.remove("active");
        /*C4img.classList.remove("active");*/
        clickPhase = 1;
        character = null;

        document.querySelector('p[id="showPlayerStatus"]').textContent = null;
        document.querySelector('label[for="character1"]').textContent = "Artoria";
        document.querySelector('label[for="character2"]').textContent = "Baobhan";
        document.querySelector('label[for="character3"]').textContent = "Kafka";
        document.querySelector('label[for="character4"]').textContent = "Seele";
        
        showStatus.classList.remove("active");

        healthBar.classList.remove("active");
        backgroundHealth.classList.remove("active");
        energyBar.classList.remove("active");
        backgroundEnergy.classList.remove("active");
        
        //  Start Esvaziando JSON personagem
        userJson = {
            "name": ""
        }
        //  End Esvaziando JSON personagem
        fetch("http://localhost:5119/api/Personagem",{
            method: "POST",
            headers: {
                "Content-Type":"application/json"
            },
            body: JSON.stringify(userJson)
        }).then(response => {
            if (!response.ok){
                throw new Error("Erro na requisicao")
            }
            return response.json()
        }).then(data => {
            console.log("Dados recebidos da API Personagem:", data);
            atk = data.atk;
            hpMax = data.hpMax;
            hp = data.hp;
            def = data.def;
            critDmg = data.critDmg;
            critRate = data.critRate;
            ultCost = data.ultCost;
            energy = data.energy;
            speed = data.speed; 
            TrackHealth(hp, hpMax);
        });

        selectedCharacter.textContent = "Select a character.";
    }
    else if (clickPhase == 3) {
        C11img.classList.remove("active");
        C21img.classList.remove("active");
        /*C31img.classList.remove("active");
        C41img.classList.remove("active");*/
        chamarApi = 2;
        healthBarContainer.classList.add("singlePlayer");
        showStatus.classList.add("singlePlayer");
        selectedCharacter.style.visibility = "visible";
        bleedingHealthBarEnemy.classList.remove("active");
        document.querySelector('label[for="character1"]').textContent = "Gepard";
        document.querySelector('label[for="character2"]').textContent = "Bronya";
        document.querySelector('label[for="character3"]').textContent = "Blade";
        document.querySelector('label[for="character4"]').textContent = "Archer";
        pickCharacter.classList.remove("shrink");
        healthBarEnemy.classList.remove("active");
        backgroundHealthEnemy.classList.remove("active");
        energyBarEnemy.classList.remove("active");
        backgroundEnergyEnemy.classList.remove("active");
        enemyContainer.classList.remove("selected");
        upSideArrowEnemy.classList.remove("active");
        upSideDownArrowEnemy.classList.remove("active");
        collapseEnemyInfo = 1;
        enemyInfo.classList.remove("active");
        spdDataEnemy.classList.remove("active");
        atkDataEnemy.classList.remove("active");
        defDataEnemy.classList.remove("active");
        
        radios.forEach(radio => {
            radio.classList.remove("hidden")
        });
        clickPhase = 2;
        enemy = null;
        document.querySelector('p[id="showEnemyStatus"]').textContent = null;
        enemyJson = {
            "name": ""
        }
        fetch("http://localhost:5119/api/Inimigo",{
            method: "POST",
            headers: {
                "Content-Type":"application/json"
            },
            body: JSON.stringify(enemyJson)
        }).then(response => {
            if (!response.ok){
                throw new Error("Erro na requisicao")
            }
            return response.json()
        }).then(data => {
            console.log("Dados recebidos da API Inimigo:", data);
            atkEnemy = data.atk;
            hpMaxEnemy = data.hpMax;
            hpEnemy = data.hp;
            defEnemy = data.def;
            critDmgEnemy = data.critDmg;
            critRateEnemy = data.critRate;
            ultCostEnemy = data.ultCost;
            energyEnemy = data.energy;
            speedEnemy = data.speed;
            TrackHealthEnemy(hpEnemy, hpMaxEnemy); 
        });
        if (enemy == null) {
            document.getElementById("enemyContainer").classList.remove("Selected");
        }
        selectedCharacter.textContent = "Please select an enemy.";
    }
    if (clickPhase == 1){
        returnBtn.classList.remove('hover-active'); // classe hover-active
    }
}

mySubmit.onclick = function () {
    if (clickPhase < 2 && !(character1.checked || character2.checked || character3.checked || character4.checked)) {
        selectedCharacter.textContent = `Please select a character.`;
    }
    if (clickPhase > 1 && clickPhase < 3 && !(character1.checked || character2.checked || character3.checked || character4.checked)) {
        selectedCharacter.textContent = `Please select an enemy.`;
    }
    if (character1.checked) {
        if (clickPhase == 1) {
            selectedCharacter.textContent = `You have selected Artoria!`;
            character = "Artoria";
            chamarApi = 1; // Permite bater na API/Personagem
            clickPhase = 2;
            document.querySelector('p[id="showPlayerStatus"]').textContent = character;
            C1img.classList.add("active");
            document.getElementById("button1Atk").textContent = "Basic Attack";
            document.getElementById("button2Atk").textContent = "Ghost Excalibur";
            document.getElementById("button3Atk").textContent = "Excalibur";
        } else {
            selectedCharacter.textContent = `You have selected Gepard!`;
            enemy = "Gepard";
            clickPhase = 3;
            document.querySelector('p[id="showEnemyStatus"]').textContent = enemy;
            radios.forEach(radio => { radio.checked = false; });
            C11img.classList.add("active");
        }
    } else if (character2.checked) {
        if (clickPhase == 1) {
            selectedCharacter.textContent = `You have selected Baobhan!`;
            character = "Baobhan";
            chamarApi = 1; // Permite bater na API/Personagem
            clickPhase = 2;
            document.querySelector('p[id="showPlayerStatus"]').textContent = character;
            C2img.classList.add("active");
            document.getElementById("button1Atk").textContent = "Basic Attack";
            document.getElementById("button2Atk").textContent = "Mana Loading";
            document.getElementById("button3Atk").textContent = "Fetch Failnaught";
        } else {
            selectedCharacter.textContent = `You have selected Bronya!`;
            enemy = "Bronya";
            clickPhase = 3;
            document.querySelector('p[id="showEnemyStatus"]').textContent = enemy;
            radios.forEach(radio => { radio.checked = false; });
            C21img.classList.add("active");
        }
    } else if (character3.checked) {
        if (clickPhase == 1) {
            selectedCharacter.textContent = `You have selected Kafka!`;
            character = "Kafka";
            chamarApi = 1; // Permite bater na API/Personagem
            clickPhase = 2;
            document.querySelector('p[id="showPlayerStatus"]').textContent = character;
            C3img.classList.add("active");
            document.getElementById("button1Atk").textContent = "Basic Attack";
            document.getElementById("button2Atk").textContent = "Depriving Web";
            document.getElementById("button3Atk").textContent = "Mana Loading";
            const button4Atk = document.createElement("button");
            button4Atk.textContent = "Twilight Ray Fall";
            button4Atk.id = "button4Atk";
            attackListContainer.appendChild(button4Atk);
            attackListContainer.classList.add("fourAttacks");
        } else {
            selectedCharacter.textContent = `You have selected Blade!`;
            enemy = "Blade";
            clickPhase = 3;
            document.querySelector('p[id="showEnemyStatus"]').textContent = enemy;
            radios.forEach(radio => { radio.checked = false; });
            C31img.classList.add("active");
        }
    } else if (character4.checked) {
        if (clickPhase == 1) {
            selectedCharacter.textContent = `You have selected Seele!`;
            character = "Seele";
            chamarApi = 1; // Permite bater na API/Personagem
            clickPhase = 2;
            document.querySelector('p[id="showPlayerStatus"]').textContent = character;
            C4img.classList.add("active");
        } else {
            selectedCharacter.textContent = `You have selected Archer!`;
            enemy = "Archer";
            clickPhase = 3;
            document.querySelector('p[id="showEnemyStatus"]').textContent = enemy;
            radios.forEach(radio => { radio.checked = false; });
            C41img.classList.add("active");
        }
    }
    if (clickPhase == 2 && chamarApi == 1){
        healthBar.style.width = `${0}%`; // Concede largura de barra de vida em 0 para efeito visual
        chamarApi = 2;
        healthBarContainer.classList.add("singlePlayer");
        showStatus.classList.add("singlePlayer");
        healthBar.classList.add("active");
        backgroundHealth.classList.add("active");
        energyBar.classList.add("active");
        backgroundEnergy.classList.add("active");

        userJson = {
            "name": character
        }
        fetch("http://localhost:5119/api/Personagem",{
            method: "POST",
            headers: {
                "Content-Type":"application/json"
            },
            body: JSON.stringify(userJson)
        }).then(response => {
            if (!response.ok){
                throw new Error("Erro na requisicao")
            }
            return response.json()
        }).then(data => {
            console.log("Dados recebidos da API Personagem:", data);
            atk = data.atk;
            hpMax = data.hpMax;
            hp = data.hp;
            def = data.def;
            critDmg = data.critDmg;
            critRate = data.critRate;
            ultCost = data.ultCost;
            energy = data.energy;
            speed = data.speed; 
            TrackHealth(hp, hpMax);
        });
        
    } else if (clickPhase == 3 && chamarApi == 2){
        chamarApi = 3;
        healthBarContainer.classList.remove("singlePlayer");
        showStatus.classList.remove("singlePlayer");
        healthBarEnemy.style.width = `${0}%`; // Concede largura de barra de vida em 0 para efeito visual
        bleedingHealthBarEnemy.classList.add("active");
        healthBarEnemy.classList.add("active");
        backgroundHealthEnemy.classList.add("active");
        energyBarEnemy.classList.add("active");
        backgroundEnergyEnemy.classList.add("active");
        enemyJson = {
            "name": enemy
        }

        fetch("http://localhost:5119/api/Inimigo",{
            method: "POST",
            headers: {
                "Content-Type":"application/json"
            },
            body: JSON.stringify(enemyJson)
        }).then(response => {
            if (!response.ok) {
                throw new Error("Erro na requisicao")
            }
            return response.json()
        }).then(data => {
            console.log("Dados recebidos da API Inimigo:", data);
            atkEnemy = data.atk;
            hpMaxEnemy = data.hpMax;
            hpEnemy = data.hp;
            defEnemy = data.def;
            critDmgEnemy = data.critDmg;
            critRateEnemy = data.critRate;
            ultCostEnemy = data.ultCost;
            energyEnemy = data.energy;
            speedEnemy = data.speed;
            TrackHealthEnemy(hpEnemy, hpMaxEnemy);
        });
    }
    if (clickPhase == 2) {
        document.querySelector('label[for="character1"]').textContent = "Gepard";
        document.querySelector('label[for="character2"]').textContent = "Bronya";
        document.querySelector('label[for="character3"]').textContent = "Blade";
        document.querySelector('label[for="character4"]').textContent = "Archer";
        radios.forEach(radio => { radio.checked = false; });
        setTimeout(function () {
            if (selectedCharacter.textContent != "Please select an enemy." && selectedCharacter.textContent != "Select a character." && clickPhase != 3)
            selectedCharacter.textContent = "Now select an enemy.";
        }, 1500);
    } 
    else if (clickPhase == 3) {
        radios.forEach(radio => {
            radio.classList.add("hidden")
        });
        pickCharacter.classList.add("shrink");
        document.querySelector('label[for="character1"]').textContent = null;
        document.querySelector('label[for="character2"]').textContent = null;
        document.querySelector('label[for="character3"]').textContent = null;
        document.querySelector('label[for="character4"]').textContent = null;
        setTimeout(function () { 
            if (selectedCharacter.textContent != "Please select an enemy." && selectedCharacter.textContent != "Select a character.")
            selectedCharacter.style.visibility = "hidden";
        },1500);
        enemyContainer.classList.add("selected");
        upSideArrowEnemy.classList.add("active");
    }
    
    // Adicionar a classe 'active' para a div #showStatus com animação de slide down
    if (character != null && clickPhase == 2) {
        showStatus.classList.add("active"); // Adiciona a classe para mostrar a div com animação
    }
};