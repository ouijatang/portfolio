using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Apple : MonoBehaviour
{
    public Color myColor;
    public string myNickname;
    public float weight;
    public float speed;

    RectTransform _rect;
    Image _image;
    //life span method
    private void Start()
    {
        Debug.Log("hello");
        Debug.Log(myColor);

        _rect = GetComponent<RectTransform>();
        _image = GetComponent<Image>();

        _rect.DOScale(1.5f, 5).SetEase(Ease.OutElastic);

        _image.DOColor(myColor, 3).OnComplete(
            () =>
            {
                _image.DOKill();
                _image.DOColor(Color.white, 2).OnComplete(
                    () =>
                    {
                        _image.DOKill();
                        _image.DOColor(Color.magenta, 2);
                    });
            }
            );
    }

    private void Update()
    {
        //move left using this method
        var newPos = _rect.anchoredPosition;
        newPos.x = newPos.x - speed * Time.deltaTime;
        newPos.y = newPos.y + Mathf.Sin(Time.time * 4f) * 0.9f;
        _rect.anchoredPosition = newPos;
        //_image.color = myColor;
    }

    public float GetWeight()
    {
        return weight;
    }
}
