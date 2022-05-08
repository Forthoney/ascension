using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePlayer : MonoBehaviour
{

    public Sprite[] frames;
    public int framesPerSecond = 10;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * framesPerSecond) % frames.Length; 
        image.sprite = frames[index];
    }
}

