using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMeter : MonoBehaviour
{
    float timerSize;
    float timerSizeReset;
    float originalPosition;
    float originalSize;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position.x;
    }

    public void MoveMeter(float time, float maxTime)
    {
        timerSize = time;
        timerSizeReset = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = new Vector3(originalPosition + timerSize, transform.position.y);
        transform.localScale = new Vector3(originalSize * (timerSize * 2), transform.localScale.y);
        
    }
}
