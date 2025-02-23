using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Menu
    {
        int option; // Stores any of the players' moves
        int playAgain; // Stores if the players wants to keep playimg
        Game game;
        
        // Shows the menu on the console
        public void Show() 
        {
            Console.WriteLine("Tic-Tac-Toe\n");
            
            Console.WriteLine("Press enter to start the game ");
            Console.ReadLine();
            
            GameLoop();
        }
        
        // Starts the game
        public void GameLoop()
        {
            game = new Game();
            game.Show();
            do
            {
                Moves(game.player1); // Player 1 turn
                if(option == 11 | playAgain == 2) { return; } 
                Moves(game.player2); // Player 2 turn
                if(option == 11 | playAgain == 2) { return; }
            }while(true);
        }
        
        // Shows the possible moves on the screen
        public void Moves(Player player)
        {
            Console.WriteLine("Draw a symbol at: ");
            Console.Write("1. (0,0)     ");
            Console.Write("2. (0,1)     ");
            Console.WriteLine("3. (0,2) ");
            Console.Write("4. (1,0)     ");
            Console.Write("5. (1,1)     ");
            Console.WriteLine("6. (1,2) ");
            Console.Write("7. (2,0)     ");
            Console.Write("8. (2,1)     ");
            Console.WriteLine("9. (2,2)");
            Console.WriteLine("10. Restart");
            Console.WriteLine("11. Exit");
            
            option = Convert.ToInt32(Console.ReadLine());
            
            Console.Clear();
            switch(option)
            {
                case 1:
                    if (IllegalMove(player,0,0)) { break; }
                    game.Play(player,0,0); break;
                case 2:
                    if (IllegalMove(player,0,1)) { break; }
                    game.Play(player,0,1); break;
                case 3:
                    if (IllegalMove(player,0,2)) { break; }
                    game.Play(player,0,2); break;
                case 4:
                    if (IllegalMove(player,1,0)) { break; }
                    game.Play(player,1,0); break;
                case 5:
                    if (IllegalMove(player,1,1)) { break; }
                    game.Play(player,1,1); break;
                case 6:
                    if (IllegalMove(player,1,2)) { break; }
                    game.Play(player,1,2); break;
                case 7:
                    if (IllegalMove(player,2,0)) { break; }
                    game.Play(player,2,0); break;
                case 8:
                    if (IllegalMove(player,2,1)) { break; }
                    game.Play(player,2,1); break;
                case 9:
                    if (IllegalMove(player,2,2)) { break; }
                    game.Play(player,2,2); break;
                case 10: GameLoop(); break;
                case 11: 
                    game.Show();
                    Console.WriteLine("Thanks for playing!!"); break;
                default: 
                    Console.WriteLine("Choose an option between 1 and 11"); 
                    game.Show(); 
                    Moves(player);
                    break;
            }
            
            // Checks if the players want to play again or exit the game
            if(game.Win(player.GetSymbol()) | game.Draw())
            {
                Console.WriteLine("1. Restart");
                Console.WriteLine("2. Exit");
                
                playAgain = Convert.ToInt32(Console.ReadLine());
                switch(playAgain)
                {
                    case 1: GameLoop(); break;
                    case 2: Console.WriteLine("Thanks for playing!!"); break;
                    default: Console.WriteLine("Choose an option between 1 and 2"); break;
                }
            }
        }
        
        // Checks if an illegal move has been requested by a player 
        public bool IllegalMove(Player player, int x, int y)
        {
            if (!game.Legal(x,y)) 
            {
                Console.WriteLine("\nIllegal move");
                Console.WriteLine("Try Again!\n");
                game.Show();
                
                // Make the player choose another move
                Moves(player);
                return true;
            }
            return false;
        }
    }
}