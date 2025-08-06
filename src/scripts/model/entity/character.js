class Character {
    constructor(name, level = 1) {
        this.name = name;
        this.level = level;
        this.health = 0;
        this.attack = 0;
        this.defense = 0;
        this.spd = 0;
        this.element = "";
        this.rarity = 4;
        this.skills = [];
        this.ultCost = 0;
        this.energy = 0;
    }

    static getBaseStats(name){
        const baseStats = { health: 0, attack: 0, defense: 0, spd: 0, ultCost: 0 };

        if (name == "Blade") {
            baseStats.health = 69;
            baseStats.attack = 25;
            baseStats.defense = 24;
            baseStats.spd = 90;
            baseStats.ultCost = 140;

        } else if (name == "Saber") {
            baseStats.health = 45;
            baseStats.attack = 32;
            baseStats.defense = 24;
            baseStats.spd = 100;
            baseStats.ultCost = 300;
        }

        return baseStats;
    }
    
    static createCharacter(name, level = 1) {
        switch (name) {
            case "Blade":
                return new Blade(level);
            case "Saber":
                return new Saber(level);
            default:
                throw new Error(`Unknown character: ${name}`);
        }
    }
}

