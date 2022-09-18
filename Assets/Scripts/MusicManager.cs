using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioLowPassFilter))]
public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource music;
    float lastTime;
    const float MIN_FREQ = 500;
    const float MAX_FREQ = 15000;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioLowPassFilter>().cutoffFrequency = MIN_FREQ;
        GetComponent<AudioLowPassFilter>().lowpassResonanceQ = 1.5f;

        


        music.Play();
        lastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        //on next person
        //GetComponent<AudioLowPassFilter>().cutoffFrequency = 3000;
        //GetComponent<AudioLowPassFilter>().lowpassResonanceQ = 1.5f;
    }

    public void openDoor()
    {
        StopAllCoroutines();
        StartCoroutine(OpenDoor());
    }

    public void closeDoor()
    {
        StopAllCoroutines();
        StartCoroutine(CloseDoor());
    }

    IEnumerator OpenDoor()
    {
        lastTime = Time.time;
        while(GetComponent<AudioLowPassFilter>().cutoffFrequency < MAX_FREQ)
        {
            GetComponent<AudioLowPassFilter>().cutoffFrequency = Mathf.Clamp(Mathf.Pow((Time.time - lastTime) + 1, 8) + MIN_FREQ, MIN_FREQ, MAX_FREQ);
            Debug.Log(GetComponent<AudioLowPassFilter>().cutoffFrequency);
            yield return new WaitForSeconds(.1f);
        }

    }

    IEnumerator CloseDoor()
    {
        lastTime = Time.time;
        while (GetComponent<AudioLowPassFilter>().cutoffFrequency > MIN_FREQ)
        {          
            GetComponent<AudioLowPassFilter>().cutoffFrequency = Mathf.Clamp(-(Time.time - lastTime) * MAX_FREQ + MAX_FREQ, MIN_FREQ, MAX_FREQ);
            Debug.Log(GetComponent<AudioLowPassFilter>().cutoffFrequency);
            Debug.Log(Time.time - lastTime);
            yield return new WaitForSeconds(.1f);
        }
    }
}
