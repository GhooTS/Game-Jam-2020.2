using Cinemachine;
using UnityEngine;

public class ManageableCamera : MonoBehaviour
{
    public CinemachineVirtualCamera mainCamera;
    public CameraFocusManager manager;
    public Transform mainTarget;

    private void OnEnable()
    {
        manager.Current = this;
    }

    public void Focus(Transform target)
    {
        mainCamera.Follow = target;
    }

    public void LoseFocus()
    {
        mainCamera.Follow = mainTarget;
    }

}
