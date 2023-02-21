using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class MemoryBridge : MonoBehaviour
{
    public static MemoryBridge instance;

    public RectTransform rect;
    public Vector2 startAnchoredPos;
    public Vector2 endAnchoredPos;
    public float startScale;
    public float endScale;

    public float t_bridge;
    public float t_girls;
    public float t_scissors;

    public Image imgBridge;
    public Image imgGirls;
    public Image imgScissors;

    public float zoomDelay = 4f;

    public float bubble_Passager_Talk1_delay = 0.35f;
    public GameObject bubble_Passager_Talk1;
    public float bubble_Passager_Talk2_delay = 0.35f;
    public GameObject bubble_Passager_Talk2;
    public float bubble_Passager_Talk3_delay = 0.35f;
    public GameObject bubble_Passager_Talk3;
    public float bubble_Passager_Talk4_delay = 0.35f;
    public GameObject bubble_Passager_Talk4;
    public float bubble_Passager_Talk5_delay = 0.35f;
    public GameObject bubble_Passager_Talk5;
    public float bubble_Girl_Talk1_delay = 0.35f;
    public GameObject bubble_Girl_Talk1;
    public float bubble_Girl_Talk2_delay = 0.35f;
    public GameObject bubble_Girl_Talk2;
    public float bubble_Girl_Talk3_delay = 0.35f;
    public GameObject bubble_Girl_Talk3;
    public float enableInteractionDelay = 3f;

    public CanvasObject scissorsCo;

    private void Awake()
    {
        instance = this;
    }

    public void StartShowMemory()
    {
        rect.anchoredPosition = startAnchoredPos;
        rect.transform.localScale = startScale * Vector3.one;

        StartCoroutine(StartPassagerChat());
    }

    IEnumerator StartPassagerChat()
    {
        yield return new WaitForSeconds(bubble_Passager_Talk1_delay);
        bubble_Passager_Talk1.SetActive(true);
        yield return new WaitForSeconds(bubble_Passager_Talk2_delay);
        bubble_Passager_Talk2.SetActive(true);
        com.SoundSystem.instance.Play("crowd");
        yield return new WaitForSeconds(bubble_Passager_Talk3_delay);
        bubble_Passager_Talk3.SetActive(true);
        yield return new WaitForSeconds(bubble_Passager_Talk4_delay);
        bubble_Passager_Talk4.SetActive(true);
        yield return new WaitForSeconds(bubble_Passager_Talk5_delay);
        bubble_Passager_Talk5.SetActive(true);

        yield return new WaitForSeconds(zoomDelay);
        StartCoroutine(Zoom());
        StartCoroutine(ShowBridge());
        StartCoroutine(ShowGirls());
        StartCoroutine(ShowScissors());
        StartCoroutine(StartGirlChat());
    }

    IEnumerator StartGirlChat()
    {
        yield return new WaitForSeconds(bubble_Girl_Talk1_delay);
        bubble_Girl_Talk1.SetActive(true);
        yield return new WaitForSeconds(bubble_Girl_Talk2_delay);
        bubble_Girl_Talk2.SetActive(true);
        yield return new WaitForSeconds(bubble_Girl_Talk3_delay);
        bubble_Girl_Talk3.SetActive(true);
        yield return new WaitForSeconds(enableInteractionDelay);
        EnableInteraction();
    }

    void EnableInteraction()
    {
        scissorsCo.enabled = true;
    }

    IEnumerator Zoom()
    {
        yield return new WaitForSeconds(1);
        rect.DOScale(endScale, 4f).SetEase(Ease.InOutCubic);
        rect.DOAnchorPos(endAnchoredPos, 4f).SetEase(Ease.InOutCubic);
    }

    IEnumerator ShowBridge()
    {
        yield return new WaitForSeconds(t_bridge);
        imgBridge.DOFade(1, 2);
    }

    IEnumerator ShowGirls()
    {
        yield return new WaitForSeconds(t_girls);
        imgGirls.DOFade(1, 2);
    }

    IEnumerator ShowScissors()
    {
        yield return new WaitForSeconds(t_scissors);
        imgScissors.DOFade(1, 2);
    }
}