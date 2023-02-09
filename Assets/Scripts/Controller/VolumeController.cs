
using UnityEngine;
using UnityEngine.UI;

namespace Controller
{
    public class VolumeController : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private AudioSource audioSource;

        private void Start()
        {
            slider.value = GameManager.Instance.volume;
        }

        public void ChangeVolume()
        {
            GameManager.Instance.volume = slider.value;
            audioSource.volume = slider.value;
        }
    }
}