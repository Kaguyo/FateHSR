class Saber extends Character {
    constructor() {
        super();
        this.name = "Saber";
        this.element = "Light";
        this.rarity = 5;
        this.path = "Saber";
        this.icon = new Image();
        this.icon.src = "assets/images/characters/saber.png";
        this.description = "A valorous Sword Knight of unyielding honor and skill.";
            this.skills = [
            {
                name: "Divine Swordsmanship",
                type: "Skill",
                multiplier: 80,
                description: "Powerful single-target sword strike.",
                level: 1
            },
            {
                name: "Mana Burst (Sword)",
                type: "Skill",
                multiplier: 0,
                description: "Increases own attack and damage for 3 turns.",
                level: 1
            },
            {
                name: "Noble Phantasm: Excalibur",
                type: "Ultimate",
                multiplier: 200,
                description: "Unleashes Excalibur in a massive AoE damage attack to all enemies.",
                level: 1
            }
        ];
        const { health, attack, defense, spd, ultCost } = GenerateStats.generateStats(this.name, this.level);
        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.spd = spd;
        this.ultCost = ultCost;
    }
}
