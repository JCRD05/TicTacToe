using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        private string playerName;
        private string symbol;
        
        // Sets the player name and symbol
        public Player(string playerName, string symbol)
        {
            this.playerName = playerName;
            this.symbol = symbol;
        }
        
        public string GetSymbol() { return symbol; }
        
        public string GetName() { return playerName; }
    }
}