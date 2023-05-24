using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeManager : MonoBehaviour
{

    public static StrokeManager instance;

    public Text strokeText;
    int strokes=0;

    private void Awake(){
        instance=this;
    }

    // Start is called before the first frame update
    void Start()
    {
        strokeText.text="Strokes: "+strokes.ToString();
    }

    public void AddStroke(){
        strokes+=1;
        strokeText.text="Strokes: "+strokes.ToString();

    }
    public void ResetStrokes(){
        strokes=0;
        strokeText.text="Strokes: "+strokes.ToString();

    }

}
