using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public static class EventsModel
    {
        public static UnityAction<GameObject> BALL_TOUCHED_GROUND;

        public static UnityAction BALL_LAUNCHED;

        public static UnityAction TIMER_ENDED;

        public static UnityAction<int> UPDATE_SCORE;

        public static UnityAction ADD_SCORE;
    }
}