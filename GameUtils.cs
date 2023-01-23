namespace Bowling
{
    public class GameUtils
    {

        public static int GetRandomRollValue(int frameIndex, bool isStrike, int previewsPinsDown, int numOfFrames)
        {
            var random = new Random();
            if (isStrike && frameIndex == numOfFrames - 1 && previewsPinsDown == 10)
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
    }
}