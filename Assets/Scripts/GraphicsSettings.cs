using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    void Start()
    {
        //graphics settings
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 300;
    }
}