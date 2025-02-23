using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        private string[,] game; // Array of strings that stores the game's squares
        public Player player1;
        public Player player2;
        
        // Sets the inicial values for the game squares as empty and the symbols for each player
        public Game()
        {
            game = new string[3,3] {{" "," "," "},{" "," "," "},{" "," "," "}};
            player1 = new Player("Player 1", "X");
            player2 = new Player("Player 2", "O");
        }
        
        // Prints the game on the console
        public void Show()
        {
            Console.WriteLine("    0   1   2 ");
            Console.WriteLine("   =========== ");
            for(int i = 0; i < 3; i++)
            {
                Console.Write(i + " |");
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(" " + game[i,j] + " |");
                }
                Console.WriteLine();
                Console.WriteLine("   =========== ");
            }
            Console.WriteLine();
        }
        
        // Sets a symbol in an specified square, afterwards prints the game on the console and checks if any win or draw scenarios has been met
        public void Play(Player player, int x, int y)
        {
            if(Legal(x, y)) { game[x,y] = player.GetSymbol(); }
            
            Show();
            
            if(Win(player.GetSymbol())) { Console.WriteLine( player.GetName() + " Wins\n"); }
            else if(Draw()) { Console.WriteLine("Its a draw\n"); }
        }
        
        // Checks if the player's move is legal
        public bool Legal(int x, int y) { return game[x,y] == " "; }
        
        // Checks if a player has met any of the possible win scenarios
        public bool Win(string symbol)
        {
            // Checks if a diagonal line has been formed by a player
            bool DiagonalLine1 = game[0,0] == symbol && game[1,1] == symbol && game[2,2] == symbol; 
            bool DiagonalLine2 = game[0,2] == symbol && game[1,1] == symbol && game[2,0] == symbol;
            
            if(DiagonalLine1) { return true; }
   
            if(DiagonalLine2) { return true; }
                
            for(int i = 0; i < 3; i++)
            {
                // Checks if a horizontal or vertical line has been formed by a player 
                bool HorizontalLine = game[i,0] == symbol && game[i,1] == symbol && game[i,2] == symbol;
                bool VerticalLine = game[0,i] == symbol && game[1,i] == symbol && game[2,i] == symbol;
                
                if(HorizontalLine) { return true; };
                
                if(VerticalLine) { return true; };
            }
            return false;
        }
        
        // Checks if a draw scenario has been met
        public bool Draw()
        {
            int fullSquares = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (game[i,j] != " ") { fullSquares++; }
                }
            }
            
            if(fullSquares == 9) { return true; }
            else { return false; }
        }
    }
}