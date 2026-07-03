using UnityEngine;

public class CameraController: MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public int GetHighestPoint()
    {
        return (int)_camera.orthographicSize - 1;
    }

    public int GetLowestPoint()
    {
        return (int)_camera.orthographicSize * -1;
    }

    public int GetHeight()
    {
        return (int)_camera.orthographicSize;
    }

    public int GetRightEdge()
    {
        return GetHaldWidthWithOffset();
    }
    public int GetLeftEdge()
    {
        return GetHaldWidthWithOffset() * -1;
    }
    
    private int GetHaldWidthWithOffset()
    {
        return (int)(_camera.orthographicSize * _camera.aspect + 1);
    }
}