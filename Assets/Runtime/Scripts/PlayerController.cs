using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {


    }
}
