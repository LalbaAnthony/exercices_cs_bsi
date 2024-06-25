using System;

class TicTacToe
{
    static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int player = 1; // 1 pour le joueur 1 et 2 pour le joueur 2
    static int choice; // Le choix du joueur pour la position
    static int status = 0; // 1 si on a un gagnant, -1 si match nul, 0 si jeu en cours

    static void Main()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Joueur 1: X et Joueur 2: O");
            Console.WriteLine("\n");

            Console.WriteLine("Tour du joueur {0}:", player % 2 == 0 ? 2 : 1);

            Console.WriteLine("\n");
            Board(); // Affichage du plateau
            choice = int.Parse(Console.ReadLine()); // Lecture du choix du joueur

            // Vérification de la position et mise à jour du tableau
            if (board[choice] != 'X' && board[choice] != 'O')
            {
                if (player % 2 == 0)
                {
                    board[choice] = 'O';
                    player++;
                }
                else
                {
                    board[choice] = 'X';
                    player++;
                }
            }
            else
            {
                Console.WriteLine("La ligne {0} est déjà marquée avec un {1}.", choice, board[choice]);
                Console.WriteLine("Veuillez attendre quelques secondes...");
                System.Threading.Thread.Sleep(2000);
            }
            status = CheckWin(); // Vérification si quelqu'un a gagné
        }
        while (status != 1 && status != -1);

        Console.Clear();
        Board();
        if (status == 1)
        {
            Console.WriteLine("Le joueur {0} a gagné!", (player % 2) + 1);
        }
        else
        {
            Console.WriteLine("Match nul!");
        }
        Console.ReadLine();
    }

    private static void Board()
    {
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[1], board[2], board[3]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[4], board[5], board[6]);
        Console.WriteLine("_____|_____|_____ ");
        Console.WriteLine("     |     |      ");
        Console.WriteLine("  {0}  |  {1}  |  {2}", board[7], board[8], board[9]);
        Console.WriteLine("     |     |      ");
    }

    private static int CheckWin()
    {
        #region Horizontal Winning Condtion
        if (board[1] == board[2] && board[2] == board[3])
        {
            return 1;
        }
        else if (board[4] == board[5] && board[5] == board[6])
        {
            return 1;
        }
        else if (board[6] == board[7] && board[7] == board[8])
        {
            return 1;
        }
        #endregion

        #region Vertical Winning Condtion
        else if (board[1] == board[4] && board[4] == board[7])
        {
            return 1;
        }
        else if (board[2] == board[5] && board[5] == board[8])
        {
            return 1;
        }
        else if (board[3] == board[6] && board[6] == board[9])
        {
            return 1;
        }
        #endregion

        #region Diagonal Winning Condition
        else if (board[1] == board[5] && board[5] == board[9])
        {
            return 1;
        }
        else if (board[3] == board[5] && board[5] == board[7])
        {
            return 1;
        }
        #endregion

        #region Checking For Draw
        else if (board[1] != '1' && board[2] != '2' && board[3] != '3' && board[4] != '4' && board[5] != '5' && board[6] != '6' && board[7] != '7' && board[8] != '8' && board[9] != '9')
        {
            return -1;
        }
        #endregion

        else
        {
            return 0;
        }
    }
}
