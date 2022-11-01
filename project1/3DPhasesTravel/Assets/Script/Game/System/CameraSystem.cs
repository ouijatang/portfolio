using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraSystem : MonoBehaviour
{
    public static CameraSystem instance;
    public Transform cameraTrans;

    public Transform axis1;
    public Transform axis2;

    public float duration = 1.0f;
    public float distanceFromTarget = 10f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }

    public void SetToAxis1(Vector3 targetPos)
    {
        com.SoundSystem.instance.Play("note1");
        cameraTrans.DOKill();
        cameraTrans.DORotate(axis1.eulerAngles, duration, RotateMode.Fast);
        cameraTrans.DOMove(targetPos, duration);
    }

    public void SetToAxis2(Vector3 targetPos)
    {
        com.SoundSystem.instance.Play("note2");
        cameraTrans.DOKill();
        cameraTrans.DORotate(axis2.eulerAngles, duration, RotateMode.Fast);
        cameraTrans.DOMove(targetPos, duration);
    }

    public Vector3 GetCamPos(Vector3 cubePos, CubeAxis axis)
    {
        if (axis == CubeAxis.One)
            return cubePos - axis1.forward * distanceFromTarget;

        if (axis == CubeAxis.Two)
            return cubePos - axis2.forward * distanceFromTarget;

        return cameraTrans.position;
    }
}
