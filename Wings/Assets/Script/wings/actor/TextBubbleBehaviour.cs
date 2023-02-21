using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class TextBubbleBehaviour : MonoBehaviour
{
    public enum MoveAnim
    {
        None,
        Shake,
        Float,
    }

    public enum FadeAnim
    {
        None,
        Alpha,
    }
    public MoveAnim moveAnim;
    public FadeAnim fadeAnim;

    public float moveStrength = 4;

    public float stayTime;
    public Image img;

    // Use this for initialization
    void Start()
    {
        switch (moveAnim)
        {
            case MoveAnim.None:
                break;
            case MoveAnim.Shake:
                transform.DOShakePosition(stayTime, moveStrength, 10, 90, false, false).SetEase(Ease.InOutCubic);
                break;
            case MoveAnim.Float:
                var y = transform.position.y;
                transform.DOMoveY(y + moveStrength, stayTime).SetEase(Ease.OutCubic);
                break;
        }

        StartCoroutine(EndAction());
    }

    IEnumerator EndAction()
    {
        yield return new WaitForSeconds(stayTime + 0.1f);

        switch (fadeAnim)
        {
            case FadeAnim.None:
                Destroy(gameObject);
                break;
            case FadeAnim.Alpha:
                img.DOFade(0, 0.4f).OnComplete(() => { Destroy(gameObject); });
                break;
        }
    }
}