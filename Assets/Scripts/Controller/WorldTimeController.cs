using UnityEngine;

namespace Controller
{
    public class WorldTimeController : MonoBehaviour
    {
        public float slowdownFactor;
        public float num;
        
        public void SetTime(bool didPlayerOnVision)
        {
            if (didPlayerOnVision) Time.timeScale = slowdownFactor;
            else Time.timeScale = 1;
            Time.fixedDeltaTime = Time.timeScale * num;
        }
    }
}