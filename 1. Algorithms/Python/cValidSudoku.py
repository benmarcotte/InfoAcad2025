# 1. b) Given a partially-filled sudoku grid, determine if the current filled numbers are valid.
#       A sudoku grid is considered valid if no row, column or 3-by-3 sector contains repeating numbers, as pictured here: https://urbanrim.org.uk/images/sudoku-blankgrid.png
#       grid[x][y] is a 9-by-9 2D list of numbers 0-9, where 0 represents an empty square (and as such do not count as a number). 
#       x represents the rows and y represents the columns, and grid[0][0] is the top-right corner.
#       If your code returns a value without attempting to solve the question, you will get a score of 0.
#       You may freely modify everything except the name of the solution function and its parameters.

# 1. b) Déterminez si la grille de sudoku partièllement complétée est valide.
#       Une grille de sudoku est valide si aucune rangée, colonne ou secteur 3-par-3 ne contient des nombres qui se répètent, tel cette image: https://urbanrim.org.uk/images/sudoku-blankgrid.png
#       grid[x][y] est une list 2D 9-par-9 composée des nombres 0 à 9, où 0 est une case vide (et comme de soit n'est pas un nombre).
#       x représente les rangées et y représente les colonnes, et grid[0][0] est le coin en haut à gauche.
#       Si votre code ramène une valeure sans tenter de résoudre la question, vous auriez un score de 0.
#       Vous pouvez librement modifier la totalité du ficher mise à part le nom de la fonction solution donnée et ses paramètres.

def solution(grid):
    assert isinstance(grid, list)
    assert isinstance(grid[0], list)
    if grid[0][0] is not 0:
        return True
    else:
        return False