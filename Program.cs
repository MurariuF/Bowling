namespace Bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game bowlingGame = new Game();

            bowlingGame.Roll(1);
            bowlingGame.Roll(3);
            bowlingGame.Roll(2);
            bowlingGame.Roll(4);
            bowlingGame.Roll(3);
            bowlingGame.Roll(5);
            bowlingGame.Roll(4);
            bowlingGame.Roll(6);
            bowlingGame.Roll(5);
            bowlingGame.Roll(7);
            bowlingGame.Roll(8);
            bowlingGame.Roll(8);
            bowlingGame.Roll(9);
            bowlingGame.Roll(9);
            bowlingGame.Roll(9);
            bowlingGame.Roll(9);
            bowlingGame.Roll(9);
            bowlingGame.Roll(9);
            bowlingGame.Roll(10);
            bowlingGame.Roll(9);
            //bowlingGame.Roll(9);

            Console.Write(bowlingGame.Score().ToString());
        }
    }
}
