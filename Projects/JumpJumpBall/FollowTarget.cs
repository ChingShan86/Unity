using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 offset;

    void Start()
    {
        offset = followTarget.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = followTarget.transform.position - offset;
    }
}
