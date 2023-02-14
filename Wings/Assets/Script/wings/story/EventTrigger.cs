using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public GameObject target;
    public bool once = true;
    private bool _triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D " + collision.gameObject.name);
        if (_triggered)
            return;

        if (collision.gameObject == target)
        {
            OnTrigger();
            if (once)
                _triggered = true;
        }
    }

    protected virtual void OnTrigger()
    {
        Debug.Log("OnTrigger " + gameObject.name);
    }
}