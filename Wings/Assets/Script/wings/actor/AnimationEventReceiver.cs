using UnityEngine;
using com;

public class AnimationEventReceiver : MonoBehaviour
{
    public void Walked()
    {
        SoundSystem.instance.Play("step");
    }
}
