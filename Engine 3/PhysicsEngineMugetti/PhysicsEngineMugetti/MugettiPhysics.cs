namespace MPhysics
{
    public class MugettiPhysics
    {
        public struct MVec2
        {
            public float X;
            public float Y;
        };
        private static float Gravity;
        public static void StateGravity(float gravity)
        {
            Gravity = gravity;
        }

        public static MVec2 MRU(float initialTime, float currentTime, MVec2 initialPosition, MVec2 Speeds)
        {
            MVec2 FinalPos;
            float TimeDifference = currentTime - initialTime;
            FinalPos.X = (TimeDifference * Speeds.X) + initialPosition.X;
            FinalPos.Y = (TimeDifference * Speeds.Y) + initialPosition.Y;
            return FinalPos;
        }

        public static MVec2 MRUV(float initialTime, float currentTime, MVec2 initialPosition, MVec2 initialSpeeds, MVec2 accelerations)
        {
            MVec2 FinalPos;
            float TimeDifference = currentTime - initialTime;
            FinalPos.X = initialPosition.X + (accelerations.X * TimeDifference) / 2 + initialSpeeds.X * TimeDifference;
            FinalPos.Y = initialPosition.Y + (accelerations.Y * TimeDifference) / 2 + initialSpeeds.Y * TimeDifference;
            return FinalPos;
        }

        public static MVec2 TiroOblicuo(float initialTime, float currentTime, MVec2 initialPosition, MVec2 Speeds)
        {
            MVec2 FinalPos;
            float TimeDifference = currentTime - initialTime;
            FinalPos.X = ((currentTime - initialTime) * Speeds.X) + initialPosition.X;
            FinalPos.Y = initialPosition.Y + (((Gravity * -1 * TimeDifference) / 2) * ((Gravity * -1 * TimeDifference) / 2)) + Speeds.Y * TimeDifference;
            return FinalPos;
        }

        public static bool CheckCollision(MVec2 FirstPos, MVec2 FirstSize, MVec2 SecondPos, MVec2 SecondSize)
        {
            bool colX = false;
            if (FirstPos.X == SecondPos.X) { colX = true; }
            else
                if (FirstPos.X < SecondPos.X) { if (FirstPos.X + FirstSize.X >= SecondPos.X) { colX = true; } }
                else { if (SecondPos.X + SecondSize.X >= FirstPos.X) { colX = true; } }

            bool colY = false;
            if (FirstPos.Y == SecondPos.Y) { colY = true; }
            else
                if (FirstPos.Y < SecondPos.Y) { if (FirstPos.Y + FirstSize.Y >= SecondPos.Y) { colY = true; } }
                else { if (SecondPos.Y + SecondSize.Y >= FirstPos.Y) { colY = true; } }

            return colY && colX;
        }
    };
}