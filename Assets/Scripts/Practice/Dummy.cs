using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public GameObject id;

    void Start()
    {
        id.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowId(id);
        }
    }

    void ShowId(GameObject id)
    {
        // GameObject id = null;// character.getId();
        // if (id == null) { // character has no id
        //     return;
        // }
        id.transform.position = new Vector3(5,-2.5f,0);
        id.transform.Rotate(0,180f,0,Space.Self);
        id.SetActive(true);
    }
}
