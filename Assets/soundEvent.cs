using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using UnityEngine;

public class soundEvent : MonoBehaviour
{
    private AudioClip clip;
    private AudioSource source;
    private GameObject parent;
    private Renderer target;
    private string[] pObj;

    async void Start()
    { 
        int coundNum = int.Parse(this.gameObject.name);
        int count = 400 * coundNum;

        Transform parentTransform = transform.parent;
        parent = parentTransform.gameObject;
        pObj = this.parent.name.Split("_");
        if (pObj[0] == "timing")
        {
            target = GetComponent<Renderer>();
            target.material.color = new Color32(0, 0, 0, 0);
        }
        else
        {
            source = gameObject.AddComponent<AudioSource>();
            clip = Resources.Load<AudioClip>(pObj[0]);

            if (pObj[1] == "#")
            {
                IncreasePitchByHalfStep();
            }
        }
        await Task.Delay(count);
        InvokeRepeating(nameof(TimerEvent), 1f, 12.8f);
    }
    void Update()
    {

    }

    void TimerEvent()
    {
        if (pObj[0] == "timing")
        {
            target.material.color = new Color32(0, 100, 255, 255);
            Invoke("RestoreOriginalColor", 0.4f);
            return;
        }
        if (this.gameObject.tag == "active")
        {
            source.PlayOneShot(clip);
        }
    }

    void RestoreOriginalColor()
    {
        target.material.color = new Color32(0, 0, 0, 0);
    }
    void IncreasePitchByHalfStep()
    {
        float semitoneRatio = Mathf.Pow(2.0f, 1.0f / 12.0f);
        source.pitch *= semitoneRatio;
    }
}
