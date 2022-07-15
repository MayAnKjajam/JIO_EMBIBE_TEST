using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlacedCorrect : MonoBehaviour
{
    public bool isCorrect;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Target.name)
        {
            isCorrect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isCorrect = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
