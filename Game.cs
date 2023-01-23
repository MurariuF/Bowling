using System.Runtime.CompilerServices;

namespace Bowling
{
    public class Game
    {
        List<Frame> frames = new List<Frame>();
        static int NUM_OF_FRAMES = 10;
        static int STRIKE_MAXIM_ALLOWED_BONUSES = 2;
        static int SPARE_MAXIM_ALLOWED_BONUSES = 1;
        static int FRAME_DEFAULT_ROLL_NUMBER = 2;

        public void Play()
        {
            var random = new Random();
            for(int index = 0; index < NUM_OF_FRAMES; index++) 
            {
                var maximumRolls = FRAME_DEFAULT_ROLL_NUMBER;
                var frame = new Frame();
                var previewsPinsDown = 0;
                while(frame.GetNumberOfRolls() < maximumRolls)
                {
                    var pinsDown = GameUtils.GetRandomRollValue(index, frame.IsStrike, previewsPinsDown, NUM_OF_FRAMES);
                    previewsPinsDown = pinsDown;
                    frame.Roll(pinsDown);
                    AddBonuses(index, frame);
                    if(frame.IsStrike && index != NUM_OF_FRAMES - 1)
                    {
                        break;
                    }
                    if(maximumRolls == FRAME_DEFAULT_ROLL_NUMBER && frame.IsStrike && index.Equals(NUM_OF_FRAMES - 1))
                    {
                        maximumRolls++;
                    }
                }
                frames.Add(frame);
            }
        }

        public void AddBonuses(int lastIndex, Frame lastFrame)
        {
            for(int i = lastIndex - 2; i < lastIndex; i++)
            {
                if(i >= 0)
                {
                    if (frames[i].IsStrike && frames[i].BonusesNumber < STRIKE_MAXIM_ALLOWED_BONUSES)
                    {
                        frames[i].AddBonus(lastFrame.GetLastRoll());
                    }
                    else if (frames[i].IsSpare && frames[i].BonusesNumber < SPARE_MAXIM_ALLOWED_BONUSES)
                    {
                        frames[i].AddBonus(lastFrame.GetLastRoll());
                    }
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Runda    Strike     Spare    Score    Lovituri    Prima     A doua");
        }
        public void ShowScore()
        {
            this.ShowInfo();
            for(int index = 0; index < frames.Count; index++)
            {
                Console.WriteLine($"{index + 1} - {frames[index].IsStrike} - {frames[index].IsSpare} - {frames[index].TotalScore} - " +
                    $"{frames[index].GetNumberOfRolls()} - {frames[index].GetAllRolls()}");
            }
        }



        //interfata in doua parti(daca sunt prea multe if-uri)
        //runda obisnuita si ultima runda
        //list cu iframe in joc si interfata cu doua metode prima care face handleFrame(int nr) si a doua care este isFrameOver()




    }
}
