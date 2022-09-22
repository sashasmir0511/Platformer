using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public Transform RayStart;

    public float Speed;
    public float StopTime;
    public Direction CurrentDirection;
    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;


    private bool _isStopped;
    private Vector3 _LeftTargetPosition;
    private Vector3 _RightTargetPosition;

    void Start()
    {
        _LeftTargetPosition = LeftTarget.position;
        _RightTargetPosition = RightTarget.position;
    }

    void Update()
    {
        if (_isStopped) return;

        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x < _LeftTargetPosition.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0f, 0f);
            if (transform.position.x > _RightTargetPosition.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget.Invoke();
            }
        }

        RaycastHit Hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out Hit))
        {
            transform.position = Hit.point;
        }
    }

    void ContinueWalk()
    {
        _isStopped = false;
    }

}
