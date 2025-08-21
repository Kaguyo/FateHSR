class GenerateStats {
    static generateStats(name, level) {
        const baseStats = Character.getBaseStats(name);
        return GenerateStats.#adjustStatsByLevel(name, level, baseStats);
    }

    static #adjustStatsByLevel(name, level, baseStats) {
        const multipliers = {
            "Blade":      { health: 1.028, attack: 1.022,  defense: 1.023 },
            "Saber":      { health: 1.024, attack: 1.0278, defense: 1.024 },
            "The Herta":  { health: 1.024, attack: 1.029,  defense: 1.02 },
            "Welt":       { health: 1.024, attack: 1.025, defense: 1.02 }
        };

        const m = multipliers[name];
        if (!m) return baseStats;

        const adjustedStats = {
            health: Math.ceil(baseStats.health * Math.pow(m.health, level - 1)),
            attack: Math.ceil(baseStats.attack * Math.pow(m.attack, level - 1)),
            defense: Math.ceil(baseStats.defense * Math.pow(m.defense, level - 1))
        };

        return adjustedStats;
    }
}