using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    public GameObject ruleBtn;
    public GameObject playBtn;
    public GameObject gotItBtn;
    public GameObject rule;
    public CanvasGroup cg;

    void Start()
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;
        rule.SetActive(false);
        ruleBtn.SetActive(true);
        playBtn.SetActive(false);
        gotItBtn.SetActive(false);
    }

    public void OnClickRules()
    {
        com.SoundSystem.instance.Play("note1");
        rule.SetActive(true);
        ruleBtn.SetActive(false);
        playBtn.SetActive(false);
        gotItBtn.SetActive(true);
    }

    public void OnClickGotIt()
    {
        com.SoundSystem.instance.Play("note1");
        rule.SetActive(false);
        ruleBtn.SetActive(true);
        playBtn.SetActive(true);
        gotItBtn.SetActive(false);
    }

    public void OnClickPlay()
    {
        com.SoundSystem.instance.Play("note2");
        cg.alpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;
    }
}