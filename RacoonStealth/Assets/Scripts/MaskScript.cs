using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    [SerializeField]
    [Range(0.05f, 0.2f)]
    private float flickTime;

    [SerializeField]
    [Range(0.02f, 0.9f)]
    private float addSize;

    float timer = 0;
    private bool bigger = true;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > flickTime)
        {
            if (bigger)
                transform.localScale = new Vector3(transform.localScale.x + addSize, transform.localScale.y + addSize);
            else
                transform.localScale = new Vector3(transform.localScale.x - addSize, transform.localScale.y - addSize);

            timer = 0;
            bigger =! bigger;
            
            
        }
    }
}
