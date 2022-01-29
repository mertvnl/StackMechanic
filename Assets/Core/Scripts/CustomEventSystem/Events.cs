using System;

namespace CustomEventSystem
{
    public static class Events
    {
        public static readonly Event<IStackable> OnObstacleCollision = new Event<IStackable>();
    }
}