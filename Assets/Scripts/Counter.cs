using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
[SerializeField]
private GameObject cube;
private float a = 2.00f;


    // Start is called before the first frame update
    void Start()
    {
    print("hi");
    
    }

    // Update is called once per frame
    void Update()
    {
    print(cube.name);
    cube.GetComponent<Transform>().position = new Vector3(1, a, 2);
    
    a += 1;

    }
}
