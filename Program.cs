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
        GamePlay gamePlay = new GamePlay(gamefield);

        while(gameEnd == false)
        {
            GameField.Player currentPlayer;
            if (gamePlay.Round % 2 == 0)
            {
                currentPlayer = gamefield.Player2;
            }
            else
            {
                currentPlayer = gamefield.Player1;
            }
            int dice = gamePlay.DiceThrow(currentPlayer);
            gamePlay.MoveForward(currentPlayer, dice, gamefield);
            gamePlay.Eal_orLadder(currentPlayer);
            gameEnd = gamePlay.You_Win_Questionmark(currentPlayer);
            gamePlay.Round++;
        }

        System.Console.WriteLine("\n--- Statistics ---");
        System.Console.WriteLine($"Overall thrown dice: {gamefield.Player1.Throws + gamefield.Player2.Throws}");
        System.Console.WriteLine($"{player1Name} - thrown dice: {gamefield.Player1.Throws}");
        System.Console.WriteLine($"{player2Name} - thrown dice: {gamefield.Player2.Throws}");
    }
}