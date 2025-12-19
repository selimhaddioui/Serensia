# Test Cases Documentation

I organized tests into three categories to validate the algorithm and input constraints.

**Functional tests** cover the core algorithm: the provided example returns "gros" and "gras" as specified. Additional tests verify each sorting level independently (replacement count, length, alphabetical order) plus one combining all three. I also tested filtering of candidates shorter than the search term.

**Validation tests** ensure all input constraints work: uppercase letters, symbols, empty values, and null inputs throw appropriate exceptions for both term and choices. Invalid numberOfSuggestions (negative, zero, or exceeding available choices) throws ArgumentOutOfRangeException.

**Algorithm**: sliding window finds the best substring match in each candidate by testing all positions. Results sort by replacement count, then length, then alphabetically.

All tests pass.

# Documentation des Cas de Tests

J'ai organisé les tests en trois catégories pour valider l'algorithme et les contraintes d'entrée.

**Tests fonctionnels** : l'exemple fourni retourne bien "gros" et "gras". Des tests supplémentaires vérifient chaque niveau de tri indépendamment (nombre de remplacements, longueur, ordre alphabétique) plus un test combinant les trois. J'ai aussi testé le filtrage des candidats trop courts.

**Tests de validation** : toutes les contraintes d'entrée sont vérifiées. Majuscules, symboles, valeurs vides et null déclenchent les exceptions appropriées pour le terme et les choix. Un numberOfSuggestions invalide (négatif, zéro, ou supérieur aux choix disponibles) déclenche ArgumentOutOfRangeException.

**Algorithme** : fenêtre glissante qui trouve la meilleure correspondance en testant toutes les positions. Résultats triés par nombre de remplacements, puis longueur, puis ordre alphabétique.

Tous les tests passent.