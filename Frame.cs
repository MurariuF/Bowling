using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        //Incapsulare
        static int DEFAULT_NUM_PINS = 10;
        private List<int> rolls = new List<int>();
        public int BonusesNumber { get; set; } = 0;
        public int TotalScore { get; set; } = 0;
        public bool IsSpare { get; set; } = false;
        public bool IsStrike { get; set; } = false;

        public void Roll(int pins)
        {
            TotalScore+= pins;
            rolls.Add(pins);
            if(rolls.Count == 1)
            {
                IsStrike = CheckAllPinsDown(); 
            }
            else if(rolls.Count == 2 && !IsStrike)
            {
                IsSpare= CheckAllPinsDown();
            }
        }

        private bool CheckAllPinsDown()
        {
            return TotalScore == DEFAULT_NUM_PINS;
        }

        public void AddBonus(int bonus)
        {
            TotalScore+= bonus;
            BonusesNumber++;
        }

        public int GetNumberOfRolls()
        {
            return rolls.Count;
        }

        public int GetLastRoll()
        {
            return rolls.Last();
        }

        public int GetFirstRoll()
        {
            return rolls.First();
        }

        public string GetAllRolls()
        {
            var rollsString = "";
            foreach (var roll in rolls)
            {
                rollsString += roll.ToString() + " ";
            }
            return rollsString;
        }
        //private bool CheckIfStrike()
        //{
        //    if(rolls == 1 && TotalScore == DEFAULT_NUM_PINS)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private bool CheckIfSpare()
        //{
        //    if(rolls == 2 && TotalScore == DEFAULT_NUM_PINS)
        //    {
        //        return true;
        //    }    
        //    else
        //    {
        //        return false;
        //    }
        //}


    }
}
