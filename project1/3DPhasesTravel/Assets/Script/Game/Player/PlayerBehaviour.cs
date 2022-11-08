using UnityEngine;

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

    ClickBehaviour _lastCube;

    private void Awake()
    {
        instance = this;
        _jumpTimer = 0;
    }

    public void TryJumpToCube(ClickBehaviour cube)
    {
        if (cube == _lastCube)
            return;

        var endPos = cube.transform.position;
        Vector3 endCubeUpward = cube.transform.right;
        if (cube.cubeAxis == CubeAxis.One)
        {
            endPos += cube.transform.right * 0.5f;
            endCubeUpward = cube.transform.right * 1f;
        }
        else if (cube.cubeAxis == CubeAxis.Two)
        {
            endPos += cube.transform.up * 0.5f;
            endCubeUpward = cube.transform.up * 1f;
        }

        var fromPos = _lastCube.transform.position;
        if (_lastCube.cubeAxis == CubeAxis.One)
        {
            fromPos += _lastCube.transform.right * 0.5f;
        }
        else if (_lastCube.cubeAxis == CubeAxis.Two)
        {
            fromPos += _lastCube.transform.up * 0.5f;
        }

        var dist = endPos - fromPos;
        float angle = Vector3.Angle(dist, endCubeUpward);
        float radian = angle * Mathf.Deg2Rad;
        //Debug.Log(angle + " angle in degree");
        var sin = Mathf.Sin(radian);
        var length = sin * dist.magnitude;
        //Debug.Log("origin length " + dist.magnitude);
        //Debug.Log("final length " + length);

        if (length > 1.4f)
            return;

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
        _lastCube = cube;
    }

    public void PlaceOnCube(ClickBehaviour cube)
    {
        transform.position = GetIdealPosition(cube);
        _lastCube = cube;
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
            return; //not in jumping state

        _jumpTimer -= Time.deltaTime;
        if (_jumpTimer < 0)
            _jumpTimer = 0;

        var timeRatio = (1 - _jumpTimer / jumpDuration);
        var pos = _jumpStartPos;
        pos += timeRatio * _jumpForwardDistance;

        var jumpRatio = Mathf.Sin(timeRatio * Mathf.PI);
        pos += jumpRatio * _jumpUpward * jumpHeight;

        transform.position = pos;
    }
}