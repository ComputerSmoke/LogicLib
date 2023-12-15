using Stride.Engine;

namespace Logic
{
    class LogicApp
    {
        static void Main(string[] args)
        {
            using (var game = new Game())
            {
                game.Run();
            }
        }
    }
}
