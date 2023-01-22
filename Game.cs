using System.Runtime.CompilerServices;

namespace Bowling
{
    public class Game
    {
        List<Frame> frames = new List<Frame>();
        static int NUM_OF_FRAMES = 10;


        public void Play()
        {
            var random = new Random();
            for(int index = 0; index < NUM_OF_FRAMES; index++) 
            {
                var maximumRolls = 2;
                var frame = new Frame();
                var previewsPinsDown = 0;
                while(frame.GetNumberOfRolls() < maximumRolls)
                {
                    var pinsDown = GetRandomRollValue(index, frame.IsStrike, previewsPinsDown);
                    Console.WriteLine($"{index} - {pinsDown}");
                    previewsPinsDown = pinsDown;
                    frame.Roll(pinsDown);
                    AddBonuses(index, frame);
                    if(frame.IsStrike && index != 9)
                    {
                        break;
                    }
                    if(maximumRolls == 2 && frame.IsStrike && index.Equals(9))
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
                    if (frames[i].IsStrike && frames[i].BonusesNumber < 2)
                    {
                        frames[i].AddBonus(lastFrame.GetLastRoll());
                    }
                    else if (frames[i].IsSpare && frames[i].BonusesNumber < 1)
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

        public int GetRandomRollValue(int frameIndex, bool isStrike, int previewsPinsDown)
        {
            var random = new Random();
            if(isStrike && frameIndex == NUM_OF_FRAMES - 1 && previewsPinsDown == 10)
            {
                return random.Next(11);
            }
            else
            {
                //if(frameIndex == 9 && isStrike == false)
                //{
                //    return 10;
                //}
                return random.Next(11 - previewsPinsDown);

            }
        }

        

        //interfata in doua parti(daca sunt prea multe if-uri)
        //runda obisnuita si ultima runda
        //list cu iframe in joc si interfata cu doua metode prima care face handleFrame(int nr) si a doua care este isFrameOver()




    }
}
