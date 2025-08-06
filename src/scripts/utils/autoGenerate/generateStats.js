class GenerateStats {
    static generateStats(name, level) {
        const baseStats = Character.getBaseStats(name);
        return GenerateStats.#adjustStatsByLevel(name, level, baseStats);
    }

    static #adjustStatsByLevel(name, level, baseStats) {
        const adjustedStats = baseStats;
        for (let i = 1; i < level; i++) {
            adjustedStats.health = Math.ceil(adjustedStats.health *= 1.035);
            adjustedStats.attack = Math.ceil(adjustedStats.attack *= 1.02);
            adjustedStats.defense = Math.ceil(adjustedStats.defense *= 1.01);
        }

        return adjustedStats;
    }
}