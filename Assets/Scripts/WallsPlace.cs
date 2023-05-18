using UnityEngine;

public class WallsPlace : MonoBehaviour
{
    [SerializeField] private GameObject wallLeft;
    [SerializeField] private GameObject wallRight;
    private int lastScreenWidth = 0;
    private int lastScreenHeight = 0;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (lastScreenWidth != Screen.width || lastScreenHeight  != Screen.height)
        {
            lastScreenWidth = Screen.width;
            lastScreenHeight = Screen.height;
            OnScreenSizeChanged();
        }
    }
    private void OnScreenSizeChanged()
    {
        Vector3 pointleft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height/2, cam.nearClipPlane));
        Vector3 pointright = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height/2, cam.nearClipPlane));

        wallLeft.transform.position = pointleft;
        wallRight.transform.position = pointright;

    }
}
