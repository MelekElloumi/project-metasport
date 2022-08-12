using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Fader : MonoBehaviour
{
    public bool isfading=true;
    public float minFadingDistance=10.0f;
    public float maxFadingDistance=20.0f;
    public bool isfacingatplayer=true;
    Color text_alpha;
    Text text;
    Transform textTransform;
    // Start is called before the first frame update
    void Start()
    {
        text= GetComponent<Text>();
        textTransform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {        
            if (isfading)
            {
                text_alpha = text.color;
                text_alpha.a=fadeout();
                text.color = text_alpha;
            }
            
        }
        if (textTransform != null)
        {
            if (isfacingatplayer)
            {
                facing();
            }
        }
    }
    void facing()
    {
        Vector3 targetPostition = Camera.main.transform.position;
        targetPostition.y = textTransform.position.y;
        textTransform.LookAt(targetPostition);
        textTransform.Rotate(0, 180, 0);
    }
    float fadeout()
    {
        float dist = Vector3.Distance(Camera.main.transform.position, text.transform.position);
        if (dist < minFadingDistance)
        {
            return 1.0f;
        }
        if(dist > maxFadingDistance)
        {
            return 0.0f;
        }
        return Mathf.Max(1-((dist - minFadingDistance) / (maxFadingDistance - minFadingDistance)), 0.0f);


    }
}