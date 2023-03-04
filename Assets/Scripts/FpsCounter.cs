using System.Collections;
using TMPro;
using UnityEngine;

namespace Tools
{

    public class FpsCounter : MonoBehaviour
    {

        public int Fps { get; private set; }
        [SerializeField] private float fpsRefreshTime = 1f;
        public TextMeshProUGUI FpsText;

        private WaitForSecondsRealtime _waitForSecondsRealtime;

        private void OnValidate()
        {

            SetWaitForSecondsRealtime();
        }

        private IEnumerator Start()
        {
            SetWaitForSecondsRealtime();

            while (true)
            {

                Fps = (int)(1 / Time.unscaledDeltaTime);
                yield return _waitForSecondsRealtime;
            }
        }

        private void SetWaitForSecondsRealtime()
        {

            _waitForSecondsRealtime = new WaitForSecondsRealtime(fpsRefreshTime);
        }
        private void Update()
        {
            FpsText.text = Fps.ToString() + " FPS";
        }
    }
}