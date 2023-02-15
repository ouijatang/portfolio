using UnityEngine;
using System.Collections;

public class GameStart_girlsRun : MonoBehaviour
{
    public GameObject bubble1;
    public GameObject bubble2;
    public CanvasObject dragBg;
    public CharacterActor walker;

    public float t1 = 0.8f;
    public float t2 = 2.8f;
    public float t3 = 3.5f;

    void Start()
    {
        StartCoroutine(Bubble1(t1));
        StartCoroutine(Bubble2(t2));
        StartCoroutine(EnableWalk(t3));
    }

    IEnumerator Bubble1(float delay)
    {
        yield return new WaitForSeconds(delay);
        bubble1.SetActive(true);
    }

    IEnumerator Bubble2(float delay)
    {
        yield return new WaitForSeconds(delay);
        bubble2.SetActive(true);
    }

    IEnumerator EnableWalk(float delay)
    {
        yield return new WaitForSeconds(delay);
        dragBg.enabled = true;
        //walker.StopWalk();
    }
}