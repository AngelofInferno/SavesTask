namespace DefaultNamespace
{
    public class GameModel
    {
        public int CurrentGameLevel { get; set; }

        public GameModel(int currentGameLevel)
        {
            CurrentGameLevel = currentGameLevel;
        }
    }
}