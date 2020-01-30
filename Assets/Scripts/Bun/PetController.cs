using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    const string HORIZONTAL = "Horizontal";

    private Transform myTransform;
    [SerializeField]
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myTransform.position = Vector2.Lerp(myTransform.position, myTransform.TransformPoint(Vector2.right), speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myTransform.position = Vector2.Lerp(myTransform.position, myTransform.TransformPoint(-Vector2.right), speed * Time.deltaTime);
        }
    }
}
