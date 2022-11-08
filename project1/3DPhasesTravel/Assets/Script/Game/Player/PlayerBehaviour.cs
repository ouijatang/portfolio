using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerBehaviour : MonoBehaviour
{
    public static PlayerBehaviour instance;

    public float jumpHeight;
    public float jumpDuration;
    public float jumpOffset = 0.3f;

    float _jumpTimer;
    Vector3 _jumpStartPos;
    Vector3 _jumpEndPos;
    Vector3 _jumpUpward;
    Vector3 _jumpForwardDistance;

    private void Awake()
    {
        instance = this;
        _jumpTimer = 0;
    }

    public void TryJumpToCube(ClickBehaviour cube)
    {
        JumpToCube(cube);
    }

    public void JumpToCube(ClickBehaviour cube)
    {
        _jumpStartPos = transform.position;
        _jumpEndPos = GetIdealPosition(cube);
        _jumpTimer = jumpDuration;
        _jumpForwardDistance = _jumpEndPos - _jumpStartPos;

        if (cube.cubeAxis == CubeAxis.One)
        {
            _jumpUpward = cube.transform.right * 1f;
            _jumpUpward += cube.transform.up * jumpOffset;
        }
        else if (cube.cubeAxis == CubeAxis.Two)
        {
            _jumpUpward = cube.transform.up * 1f;
            _jumpUpward += -cube.transform.forward * jumpOffset;
        }
    }

    public void PlaceOnCube(ClickBehaviour cube)
    {
        transform.position = GetIdealPosition(cube);
    }

    Vector3 GetIdealPosition(ClickBehaviour cube)
    {
        var centerPos = cube.transform.position;
        var idealPos = centerPos;
        if (cube.cubeAxis == CubeAxis.One)
        {
            idealPos = idealPos + cube.transform.right * 1f;
        }
        else if (cube.cubeAxis == CubeAxis.Two)
        {
            idealPos = idealPos + cube.transform.up * 1f;
        }

        return idealPos;
    }

    private void Update()
    {
        if (_jumpTimer <= 0)
        {
            //not in jumping state
            return;
        }

        //_jumpStartPos 
        //_jumpEndPos
        //_jumpTimer 
        //_jumpUpward
        //public float jumpHeight;
        //public float jumpDuration;
        //_jumpForward
        _jumpTimer -= Time.deltaTime;
        if (_jumpTimer < 0)
        {
            _jumpTimer = 0;
        }

        var timeRatio = (1 - _jumpTimer / jumpDuration);
        var pos = _jumpStartPos;
        pos += timeRatio * _jumpForwardDistance;

        var jumpRatio = Mathf.Sin(timeRatio * Mathf.PI);
        pos += jumpRatio * _jumpUpward * jumpHeight;

        transform.position = pos;
    }
}