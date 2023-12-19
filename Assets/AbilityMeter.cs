using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
        rectTransform = GetComponent<RectTransform>();
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
        transform.localScale = new Vector3(originalSize * (timerSize * 200), transform.localScale.y);
        
    }
}
