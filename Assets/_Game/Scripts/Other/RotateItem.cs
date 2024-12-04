using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    [SerializeField] Transform tf;
    [SerializeField] float speed = 360;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tf.Rotate(Vector3.back, speed * Time.deltaTime, Space.Self);
    }
}
