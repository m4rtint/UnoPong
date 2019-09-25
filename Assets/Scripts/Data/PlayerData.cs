namespace MPHT
{
    public class PlayerManager
    {
        private const float _platformConstantPosition = 4;
        private static int activePlayers = 0;

        public float PlatformConstantPosition
        {
            get
            {
                return _platformConstantPosition;
            }
        }

        public Player CreatePlayer()
        {
            activePlayers++;
            Player player = new Player(activePlayers);
            return player;
        }
    }

    public class Player {
        private readonly PlayerNumber number;
        private PlayerPosition position;

        public Player(int i)
        {
            switch(i)
            {
                case 1:
                    number = PlayerNumber.ONE;
                    position = PlayerPosition.DOWN;
                    break;
                case 2:
                    number = PlayerNumber.TWO;
                    position = PlayerPosition.UP;
                    break;
                case 3:
                    number = PlayerNumber.THREE;
                    position = PlayerPosition.LEFT;
                    break;
                case 4:
                    number = PlayerNumber.FOUR;
                    position = PlayerPosition.RIGHT;
                    break;
                default:
                    throw new System.Exception("Incorrect player number given");
            }
        }
    }

    public enum PlayerNumber
    {
        ONE,
        TWO,
        THREE,
        FOUR
    }

    public enum PlayerPosition
    {
        DOWN,
        UP,
        LEFT,
        RIGHT
    }
}
        