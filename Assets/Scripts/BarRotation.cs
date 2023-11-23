using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarRotation : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0f,0f);

    }
}
