class Character {
    constructor({ name, health, attack, defense, spd, element, rarity, skills, ultCost }) {
        this.name = name;
        this.level = 0;
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.spd = spd;
        this.element = element;
        this.rarity = rarity;
        this.skills = skills;
        this.ultCost = ultCost;
        this.energy = 0;
    }   

    takeDamage(damage) {
        const effectiveDamage = Math.max(0, damage - this.defense);
        this.health -= effectiveDamage;
        return effectiveDamage;
    }

    isAlive() {
        return this.health > 0;
    }
}

