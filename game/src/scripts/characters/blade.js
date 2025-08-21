class Blade extends Character {
    constructor(level = 1) {
        super("Blade", level);
        this.element = "Wind";
        this.rarity = 5;
        this.path = "Destruction";
        this.icon = new Image();
        // this.icon.src = "assets/images/characters/blade.png";
        this.description = "A fierce warrior who wields a blade with unmatched skill.";
        this.skills = [
            {
                name: "Blade Slash",
                type: "Attack",
                multiplier: 100,
                description: "Deals damage to a single enemy.",
                level: 1
            },
            {
                name: "Wind Strike",
                type: "Skill",
                multiplier: 30,
                description: "Deals wind damage to all enemies.",
                level: 1
            },
            {
                name: "Ultimate Blade",
                type: "Ultimate",
                multiplier: 150,
                description: "Deals massive wind damage to the selected enemy and fixes Blade's HP at 50%. " + 
                "The nearest 2 Enemies will also receive damage equal to half of this Instance's Multiplier.",
                level: 1
            }
        ];

        const stats = GenerateStats.generateStats(this.name, this.level);
        const { health, attack, defense, spd, ultCost } = stats; 

        this.health = health;
        this.attack = attack;
        this.defense = defense;
        this.spd = spd;
        this.ultCost = ultCost;
    }   
}