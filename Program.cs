﻿using System.Security;

namespace Aale_und_Rolltreppen;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Eels and Escalators");
        System.Console.WriteLine("How big should the GameField be?");
        int size = Convert.ToInt16(Console.ReadLine());
        System.Console.Write("Player 1 name: ");
        System.Console.Write("Player 2 name:");
        string player1Name = "Patrik";
        string player2Name = "Spongebob";
        GameField gamefield = new GameField(size, player1Name, player2Name);
        gamefield.EelOrEscalate(size);
        bool gameEnd = false;
        int missingEyes;
        GamePlay gamePlay = new GamePlay(gamefield);
        Render map = new Render(gamefield);
        Console.WriteLine();
        map.PrintTheField(gamefield, gamefield.Player1, gamefield.Player2);

        while (gameEnd == false)
        {
            GameField.Player currentPlayer;
            if (gamePlay.Round % 2 == 0)
            {
                currentPlayer = gamefield.Player1;
            }
            else
            {
                currentPlayer = gamefield.Player2;
            }
            int dice = gamePlay.DiceThrow(currentPlayer);
            missingEyes = gamePlay.MissingEyes(currentPlayer, gamefield);
            if (missingEyes < 6)    // if you're in reach of the last node
            {
                if (dice > missingEyes) // eyes bigger than distance to last node
                {
                    System.Console.WriteLine("Not moving forward, eyes do not match the distance to winning-field");
                    System.Console.WriteLine("Missing eyes: " + missingEyes);
                }
                else    // eyes smaller than distance to last node
                {
                    gamePlay.MoveForward(currentPlayer, dice, gamefield);
                    gamePlay.Eal_orLadder(currentPlayer, gamefield);
                    gamePlay.EalAndEscelateMover(currentPlayer, gamefield);
                    gameEnd = gamePlay.You_Win_Questionmark(currentPlayer);
                }
            }
            else // if not in reach of the last node 
            {
                gamePlay.MoveForward(currentPlayer, dice, gamefield);
                gamePlay.Eal_orLadder(currentPlayer, gamefield);
                gamePlay.EalAndEscelateMover(currentPlayer, gamefield);
                gameEnd = gamePlay.You_Win_Questionmark(currentPlayer); // case wormhole or ladder teleports to the last field
            }
            gamePlay.Round++;
            map.PrintTheField(gamefield, gamefield.Player1, gamefield.Player2);


        }

        System.Console.WriteLine("\n--- Statistics ---");
        System.Console.WriteLine($"Overall thrown dice: {gamefield.Player1.Throws + gamefield.Player2.Throws}");
        System.Console.WriteLine($"{player1Name} - thrown dice: {gamefield.Player1.Throws}");
        System.Console.WriteLine($"{player2Name} - thrown dice: {gamefield.Player2.Throws}");
    
        
    }
}