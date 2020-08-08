using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using FMODUnity;
using GTVariable;

public class CameraFocus : MonoBehaviour
{
    public UnityEvent onStartFocus;
    public UnityEvent onEndFocus;
    public Cinemachine.CinemachineVirtualCamera virtualCamera;

    private Transform followOld;


    public void Focus()
    {

        followOld = virtualCamera.Follow;
        virtualCamera.Follow = transform;
        onStartFocus?.Invoke();
    }

    private void ExitFocus()
    {

        virtualCamera.Follow = followOld;
        onEndFocus?.Invoke();
    }


}
