using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security;

namespace Aale_und_Rolltreppen;

class Render
{
    GameField _gameField;
    public Render(GameField gameField)
    {
        _gameField = gameField;
    }
    public void Checkfornode(GameField.FieldNode currentnode, GameField.Player player1, GameField.Player player2)
    {
        switch (currentnode.Type)
        {
            case Type.Eel:
                if (currentnode == player2.Position && currentnode == player1.Position) 
                {
                    Console.Write("[S P1  P2]");
                }
                else if (currentnode == player1.Position)
                {
                    Console.Write("[S P1 ]");
                }
                else if (currentnode == player2.Position)
                {
                    Console.Write("[S P2 ]");
                }
                else
                {
                    Console.Write("[S    ]");
                }
                break;
            case Type.Escalator:
                if (currentnode == player2.Position && currentnode == player1.Position)
                {
                    Console.Write("[H P1 P2]");
                }
                else if (currentnode == player1.Position)
                {
                    Console.Write("[H P1 ]");
                }
                else if (currentnode == player2.Position)
                {
                    Console.Write("[H P2 ]");
                }
                else
                {
                    Console.Write("[H    ]");
                }
                break;
            case Type.Field:
                if (currentnode == player2.Position && currentnode == player1.Position) // rare case if both players are moved by the same eel or escalator
                {
                    Console.Write("[P1 P2]");
                }
                else if (currentnode == player1.Position)
                {
                    Console.Write("[  P1 ]");
                }
                else if (currentnode == player2.Position)
                {
                    Console.Write("[  P2 ]");
                }
                else
                {
                    Console.Write("[     ]");
                }
                break;
            case Type.Wormhole:
                if (currentnode == player2.Position && currentnode == player1.Position)
                {
                    Console.Write("[S P1 P2]");
                }
                else if (currentnode == player1.Position)
                {
                    Console.Write("[W P1 ]");
                }
                else if (currentnode == player2.Position)
                {
                    Console.Write("[W P2 ]");
                }

                else
                {
                    Console.Write("[W    ]");
                }
                break;
        }
    }

    public void PrintTheField(GameField gamefield, GameField.Player player1, GameField.Player player2)
    {
        int size = gamefield.GetEntireLength(gamefield);
        GameField.FieldNode curNod = gamefield.First;

        for (int i = 1; i < size+1; i++)
        {
            if (i == 1)
            {
                Console.Write("[Start]");
            }
            else if (i == size)
            {
                Console.Write("[ End ]");
            }
            else
            {
                Checkfornode(curNod, player1, player2);
                if (i % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
            curNod = curNod.Next;
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}