using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace account.Models
{
    internal class ScoreManager
    {
        private static ScoreManager _instance;
        public static ScoreManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScoreManager();
                }
                return _instance;
            }
        }

        public int Score { get; private set; }

        private ScoreManager()
        {
            Score = 0;
        }

        public void AddScore(int points)
        {
            Score += points;
        }
    }
}
