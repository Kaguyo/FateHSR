class TheHerta extends Character {
    constructor() {
        super();
        this.name = "The Herta";
        this.element = "Ice";
        this.rarity = 5;
        this.path = "Erudition";
        this.icon = new Image();
        this.icon.src = "assets/images/characters/the_herta.png";
        this.description = "A brilliant scientist and the head of the Genius Society, known for her sharp intellect and icy demeanor.";
        this.skills = [
            {
                name: "What Are You Looking At?",
                type: "Attack",
                multiplier: 50,
                description: "Deals Ice DMG equal to 50% of The Herta's ATK to a single enemy.",
                level: 1
            },
            {
                name: "One-Time Offer",
                type: "Skill",
                multiplier: 50,
                description: "Deals Ice DMG based on The Herta's ATK to all enemies." +
                " If the enemy's HP percentage is 50% or higher, DMG dealt to this target increases by 20%.",
                level: 1
            },
            {
                name: "It's Magic, I Added Some Magic",
                type: "Ultimate",
                multiplier: 120,
                description: "Deals Ice DMG based on The Herta's ATK to all enemies.",
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
