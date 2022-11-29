using UnityEngine;
using System.Collections;

public class CharacterActor : ActorBehaviour
{
    float _totalWalkDelta;
    public float speed;
    RectTransform _rect;
    bool isWalking;
    bool isWalkingRight;
    public float walkDistance;
    float _walkDistanceLeft;
    ActorAnimationBehaviour _actorAnimation;

    private void Awake()
    {
        _totalWalkDelta = 0;
        _rect = GetComponent<RectTransform>();
        _actorAnimation = GetComponent<ActorAnimationBehaviour>();
    }

    private void Update()
    {
        if (!isWalking)
            return;

        var move = speed * Time.deltaTime;
        _walkDistanceLeft -= move;
        if (isWalkingRight)
            _rect.anchoredPosition += Vector2.right * move;
        else
            _rect.anchoredPosition -= Vector2.right * move;

        if (_walkDistanceLeft <= 0)
        {
            isWalking = false;
            CheckWalk();
        }
    }

    public void Walk(float delta)
    {
        _totalWalkDelta += delta;
        CheckWalk();
    }

    void CheckWalk()
    {
        //Debug.Log("_totalWalkDelta" + _totalWalkDelta);
        if (isWalking)
            return;

        if (_totalWalkDelta > walkDistance)
        {
            _actorAnimation?.StartWalk();
            isWalking = true;
            isWalkingRight = false;
            int steps = Mathf.FloorToInt(_totalWalkDelta / walkDistance);
            //Debug.Log("steps" + steps);
            _walkDistanceLeft = walkDistance * steps;
            _totalWalkDelta -= walkDistance * steps;
            //Debug.Log("go left " + _walkDistanceLeft + " rest " + _totalWalkDelta);
            return;
        }

        if (_totalWalkDelta < -walkDistance)
        {
            _actorAnimation?.StartWalk();
            isWalking = true;
            isWalkingRight = true;
            int steps = Mathf.FloorToInt((-_totalWalkDelta) / walkDistance);
            //Debug.Log("steps" + steps);
            _walkDistanceLeft = walkDistance * steps;
            _totalWalkDelta += walkDistance * steps;
            //Debug.Log("go right " + _walkDistanceLeft + " rest " + _totalWalkDelta);
            return;
        }

        _actorAnimation?.StopWalk();
    }
}