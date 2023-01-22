namespace Bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game bowlingGame = new Game();

            bowlingGame.Play();
            bowlingGame.ShowScore();
        }
    }
}
