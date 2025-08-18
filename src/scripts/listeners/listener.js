const attackBtn = document.getElementById('attackBtn');
const swapCharacterBtn = document.getElementById('swapCharacterBtn');
const moveset = document.createElement('div');
const swapset = document.createElement('div');
moveset.style.width = "100%";
moveset.style.minHeight = "180px";
moveset.style.backgroundColor = "red";
swapset.style.width = "100%";
swapset.style.minHeight = "300px";
swapset.style.backgroundColor = "white";

attackBtn.onclick = (() => {
    if (attackBtn.style.backgroundColor == "") {
        attackBtn.style.backgroundColor = "red";
        swapCharacterBtn.style.backgroundColor = "";
        document.getElementById('movesetContainer').
        appendChild(moveset);

        document.getElementById('swapsetContainer').
        removeChild(document.getElementById('swapsetContainer').lastElementChild);
    } else {
        attackBtn.style.backgroundColor = "";
        document.getElementById('movesetContainer').
        removeChild(document.getElementById('movesetContainer').lastElementChild);
    }
})

swapCharacterBtn.onclick = (() => {
    if (swapCharacterBtn.style.backgroundColor == "") {
        swapCharacterBtn.style.backgroundColor = "white";
        attackBtn.style.backgroundColor = "";
        document.getElementById('swapsetContainer').
        appendChild(swapset);

        document.getElementById('movesetContainer').
        removeChild(document.getElementById('movesetContainer').lastElementChild);
    } else {
        swapCharacterBtn.style.backgroundColor = "";
        document.getElementById('swapsetContainer').
        removeChild(document.getElementById('swapsetContainer').lastElementChild);

    }
})
