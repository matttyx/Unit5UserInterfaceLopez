using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject camera;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = camera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = gameObject.GetComponent<Slider>().value;
    }

    public void UpdateVolume()
    {
       
    }
}
