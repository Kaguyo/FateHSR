class Welt extends Character {
    constructor() {
        super();
        this.name = "Welt";
        this.element = "Imaginary";
        this.rarity = 5;
        this.path = "Nihility";
        this.icon = new Image();
        this.icon.src = "assets/images/characters/welt.png";
        this.description = "Welt from Star Rail.";
        this.skills = [
            {
                name: "Shadow Slash",
                type: "Attack",
                multiplier: 50,
                description: "Deals dark damage to a single enemy.",
                level: 1
            },
            {
                name: "Time Dilation",
                type: "Skill",
                multiplier: 20,
                description: "Deals damage to the selected enemy and randomly attacks 3 more times.",
                level: 1
            },
            {
                name: "Eclipse",
                type: "Ultimate",
                multiplier: 80,
                description: "Deals dark AOE damage and inflicts Speed slow down.",
                level: 1
            }
        ];
        const { health, attack, defense, spd, ultCost } = GenerateStats.GenerateStats(this.name);
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.spd = spd;
        this.ultCost = ultCost;
    }
}
