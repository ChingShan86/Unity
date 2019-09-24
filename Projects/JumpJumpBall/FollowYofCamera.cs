using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowYofCamera : MonoBehaviour
{
    public GameObject cam;
    private float offsetY;

    void Start()
    {
        offsetY = cam.transform.position.y - this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, 
                                              cam.transform.position.y - offsetY,
                                              this.transform.position.z);
    }
}
