namespace MPHT
{
    using UnityEngine;

    public static class Utilities
    {
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
    }
}