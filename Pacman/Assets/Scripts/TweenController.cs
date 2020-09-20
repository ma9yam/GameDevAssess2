using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenController : MonoBehaviour
{
    [SerializeField] private Moveable target;
    private void Start()
    {
        MoveWithMover();
    }

    private void MoveWithMover()
    {
        target.MoveTo(new Vector3(x: 12, y: -1, z: 0),
            onComplete: () => target.MoveTo(new Vector3(x: 1, y: -1, z: 0),
             onComplete: () => target.MoveTo(new Vector3(x: 1, y: -8, z: 0),
              onComplete: () => Debug.Log("done moving"))));
    }
}
