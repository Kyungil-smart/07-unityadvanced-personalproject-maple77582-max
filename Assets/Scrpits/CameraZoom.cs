using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera cam;
    public float zoomSpeed = 5f;    
    public float minSize = 3f;
    public float maxSize = 8f;

    void Update()
    {
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (scroll != 0)
        {
            float size = cam.Lens.OrthographicSize;
            size -= scroll * zoomSpeed*Time.deltaTime;
            size = Mathf.Clamp(size, minSize, maxSize);
            cam.Lens.OrthographicSize = size;
            Debug.Log(cam);
        }
    }
}