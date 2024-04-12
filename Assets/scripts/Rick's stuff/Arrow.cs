using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private float arrowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.localPosition += arrowSpeed * Vector3.right * Time.deltaTime;
    }
}
