namespace MPHT
{
    using UnityEngine;

    public static class Utilities
    {
        private const int _availablePlayers = 4;
        public static int AvailablePlayers => _availablePlayers;

        public static Vector3 IndexToVector(int i, int widthAndHeight)
        {
            Vector3 position = Vector3.zero;

            if (i < 0) return position;

            if (i < widthAndHeight * widthAndHeight)
            {
                position.x = ((i % widthAndHeight) * 0.5f) - 3f;
                position.y = (Mathf.Floor(i / widthAndHeight) * -0.5f) + 3f;
            }

            return position;

        }

        public static Player RandomPlayer(int amountOfPlayers)
        {
            if (amountOfPlayers > AvailablePlayers)
            {
                throw new System.Exception("Don't try to randomly generating more players than needed");
            }

            return (Player) Random.Range(0, amountOfPlayers);
        }
    }
}
