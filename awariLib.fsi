module Awari

type pit = int //An integer representing the amount of beans in a pit.
type board = pit list //A list of pits, representing the board, where index 6 and 13 are Player1's and player2's home pits respectivly
type player = Player1 | Player2 //A type for defining and switching between player1 and player2

/// <summary>
/// Print the board
/// </summary>
/// <param name="b"> A board to be printed </param>
/// <returns>() - it just prints a beautiful visual board</returns>
val printBoard : b:board -> unit

/// <summary>
/// Print the board
/// </summary>
/// <param name="b"> A board to be printed </param>
/// <param name="p1"> A winner, loser or tie text </param>
/// <param name="p2"> A winner, loser or tie text </param>
/// <param name="i1"> Beans for Player1 </param>
/// <param name="i2"> Beans for Player2 </param>
/// <returns>() - it just prints a beautiful end screen</returns>
val printGameOver : b:board -> p1:string -> p2:string -> i1:int -> i2:int -> unit

/// <summary>
/// Check whether the pit is the current players home pit
/// </summary>
/// <param name="p">The player, whos home to check</param>
/// <param name="i">The pit where the last bean was placed</param>
/// <returns>True if the last bean was placed in the current players home pit</returns>
val isHome : p:player -> i:pit -> bool

/// <summary>
/// Check whether the game is over
/// </summary>
/// <param name="b"> A board to check</param>
/// <returns>True if either side has no beans</returns>
val isGameOver : b:board -> bool

/// <summary>
/// Get the pit of next move from the user
/// </summary>
/// <param name="b">The board the player is choosing from</param>
/// <param name="p">The player, whose turn it is to choose</param>
/// <param name="q">The string to ask the player</param>
/// <returns>The pit the player has chosen</returns>
val getMove : b:board -> p:player -> q:string -> pit

/// <summary>
/// Distributing beans counter clockwise, capturing when relevant
/// </summary>
/// <param name="b">The present status of the board</param>
/// <param name="p">The player, whos beans to distribute</param>
/// <param name="i">The regular pit to distribute</param>
/// <returns>A new board after the beans of pit i has been distributed,
/// and which pit the last bean landed in</returns>
val distribute : b:board -> p:player -> i:pit -> board * pit

/// <summary>
/// Interact with the user through getMove to perform a possibly repeated turn of a player
/// </summary>
/// <param name="b">The present state of the board</param>
/// <param name="p">The player, whose turn it is</param>
/// <returns>A new board after the player's turn</returns>
val turn : b:board -> p:player -> board

/// <summary>
/// Play game until one side is empty
/// </summary>
/// <param name="b">The initial board</param>
/// <param name="p">The player who starts</param>
/// <returns>A new board after one player has won</returns>
val play : b:board -> p:player -> board
