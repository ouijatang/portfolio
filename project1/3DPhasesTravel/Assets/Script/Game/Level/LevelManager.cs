using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public ClickBehaviour startCube;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        PlayerBehaviour.instance.PlaceOnCube(startCube);
        CameraSystem.instance.SetToAxis1(CameraSystem.instance.GetCamPos(PlayerBehaviour.instance.GetCurrentCubePositionIgnoreMovement(), CubeAxis.One));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
