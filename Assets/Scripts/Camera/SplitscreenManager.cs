using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitscreenManager : MonoBehaviour
{
    static SplitscreenManager instance;
    List<Camera> localCams;
    List<RenderTexture> camTargets;

    public static SplitscreenManager GetSplitscreenManager() { return instance; }

    public void AddCamera(Camera _cam)
    {
        localCams.Add(_cam);
        camTargets.Add(new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB64));
    }

    public void RemoveCam(Camera _cam)
    {
        int camIndex = localCams.IndexOf(_cam);
        localCams.Remove(_cam);
        camTargets.RemoveAt(camIndex);
    }

    void Update()
    {
        CameraPos();
        CameraMask();
    }

    void CameraPos()
    {
        if (localCams.Count > 0)
        {
            Vector2 total = Vector2.zero;

            for (int i = 0; i < localCams.Count; i++)
            {
                total += new Vector2(localCams[i].transform.position.x, localCams[i].transform.position.z);
            }

            total /= localCams.Count;
        }
    }

    void CameraMask()
    {

    }
}