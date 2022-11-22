using UnityEngine;
using DG.Tweening;

public class CameraSizeTrigger : MonoBehaviour
{
    public float targetSize;
    public float duration = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Camera.main.DOOrthoSize(targetSize, duration);
    }
}