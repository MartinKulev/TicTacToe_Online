# App
This console application was created in June 2023. It resembles the famous tic-tac-toe game and can be played from two different computers anywhere in the world. For creating the game, I chose the unusual approach of using a database to establish the connection between the two players.

# How to Play
Start the game on a computer, and "waiting for player 2..." should appear shortly after. The first player always uses the 'X' symbol and goes first. The second player always uses the 'O' symbol and goes second. You choose a box to place your symbol in by typing in the number of the box (1-9). The game continues until a player has won.

# Bug
The game has a serious bug that players must avoid triggering. The game must be completed until a player has won. If the game is stopped prematurely, the data for the players is not deleted from the database, which causes a bug on the next startup. To fix the bug, simply truncate the "Players" table in the database.