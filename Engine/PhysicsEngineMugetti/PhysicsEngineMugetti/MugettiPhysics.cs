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
            Gravity = gravity * -1.0f;
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
            FinalPos.X = initialPosition.X + (accelerations.X * TimeDifference * TimeDifference) / 2.0f + initialSpeeds.X * TimeDifference;
            FinalPos.Y = initialPosition.Y + (accelerations.Y * TimeDifference * TimeDifference) / 2.0f + initialSpeeds.Y * TimeDifference;
            return FinalPos;
        }

        public static MVec2 TiroOblicuo(float initialTime, float currentTime, MVec2 initialPosition, MVec2 Speeds)
        {
            MVec2 FinalPos;
            float TimeDifference = currentTime - initialTime;
            FinalPos.X = TimeDifference * Speeds.X + initialPosition.X;
            FinalPos.Y = initialPosition.Y + (Gravity * TimeDifference * TimeDifference) / 2.0f + Speeds.Y * TimeDifference;
            return FinalPos;
        }
        public static float AngularVelocity( float AngularDistance, float time) {
            return AngularDistance / time;
        }
        public static float AngularVelocity(float RevolutionsPerMinute) {
            return 2.0f * 3.14f * RevolutionsPerMinute / 60.0f;
        }
        public static float AngularToLinearVelocity(float AngularVel, float Radius) {
            return AngularVel * Radius;
        }

        public static bool CheckBoxCollision(MVec2 FirstPos, MVec2 FirstSize, MVec2 SecondPos, MVec2 SecondSize)
        {
            bool colX = false;
            if (FirstPos.X == SecondPos.X) { colX = true; }
            else if (FirstPos.X < SecondPos.X) {
                 if (FirstPos.X + FirstSize.X / 2.0f >= SecondPos.X - SecondSize.X / 2.0f) { colX = true; } 
            } else { 
                 if (SecondPos.X + SecondSize.X / 2.0f >= FirstPos.X - FirstSize.X /2.0f) { colX = true; } 
            }

            bool colY = false;
            if (FirstPos.Y == SecondPos.Y) { colY = true; }
            else if (FirstPos.Y < SecondPos.Y) {
                 if (FirstPos.Y + FirstSize.Y / 2.0f >= SecondPos.Y - SecondSize.Y / 2.0f) { colY = true; }
            } else {
                if (SecondPos.Y + SecondSize.Y / 2.0f >= FirstPos.Y - FirstSize.Y / 2.0f) { colY = true; }
            }

            return colX && colY;
        }

        public static bool CheckCircleCollision(MVec2 FirstPos, float FirstRadius, MVec2 SecondPos, float SecondRadius) {
            MVec2 difference;
            difference.X = FirstPos.X - SecondPos.X;
            difference.Y = FirstPos.Y - SecondPos.Y;
            float SqrMagnitude = difference.X * difference.X + difference.Y * difference.Y;
            float SqrSumRadius = (FirstRadius + SecondRadius) * (FirstRadius + SecondRadius);
            return SqrSumRadius >= SqrMagnitude;
        }

        public static bool CheckBoxCircleCollision(MVec2 BoxPos, MVec2 BoxSize, MVec2 CirclePos, float CircleRadius) {
            float auxX = CirclePos.X;
            float auxY = CirclePos.Y;
            if (CirclePos.X < BoxPos.X - BoxSize.X / 2.0f) { auxX = BoxPos.X - BoxSize.X / 2.0f; }
            else if (CirclePos.X > BoxPos.X + BoxSize.X/2.0f) { auxX = BoxPos.X + BoxSize.X / 2.0f; }
            if (CirclePos.Y < BoxPos.Y - BoxSize.Y / 2.0f) { auxY = BoxPos.Y - BoxSize.Y / 2.0f; }
            else if (CirclePos.Y > BoxPos.Y + BoxSize.Y / 2.0f) { auxY = BoxPos.Y + BoxSize.Y / 2.0f; }

            float distX = CirclePos.X - auxX;
            float distY = CirclePos.Y - auxY;
            float sqrDistance = distX * distX + distY * distY;

            return sqrDistance <= CircleRadius * CircleRadius;

        }
    };
}