///////////////
///name: Thomas Allen
///Date: 11/12/2020
///desc: Changes the color of a text UI Object
///Credit: Shell by Ryan Scheppler, with modifications
//////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBSprite : MonoBehaviour
{
    [Tooltip("Time it takes to shift from one color to next")]
    public float ColorShiftTime = 2;
    Text mySR; //Text object to change color of
    // Start is called before the first frame update
    void Start()
    {
        //get the compionent to edit
        mySR = GetComponent<Text>();
        //start the loop
        StartCoroutine(TurnRed());
    }

    
    IEnumerator TurnRed()
    {
        float timer = 0;
        Color OriginalColor = mySR.color;

        while(timer < ColorShiftTime)
        {
            yield return null;
            timer += Time.deltaTime;
            mySR.color = Color.Lerp(OriginalColor, new Color(1, 0, 0, 1), timer / ColorShiftTime); //red
        }
        StartCoroutine(TurnYellow());
    }

    IEnumerator TurnYellow()
    {
        float timer = 0;
        Color OriginalColor = mySR.color;

        while (timer < ColorShiftTime)
        {
            yield return null;
            timer += Time.deltaTime;
            mySR.color = Color.Lerp(OriginalColor, new Color(1, 1, 0, 1), timer / ColorShiftTime); //yellow
        }
        StartCoroutine(TurnGreen());
    }

    IEnumerator TurnGreen()
    {
        float timer = 0;
        Color OriginalColor = mySR.color;

        while (timer < ColorShiftTime)
        {
            yield return null;
            timer += Time.deltaTime;
            mySR.color = Color.Lerp(OriginalColor, new Color(0, 1, 0, 1), timer / ColorShiftTime); //green
        }
        StartCoroutine(TurnBlue());
    }

    IEnumerator TurnBlue()
    {
        float timer = 0;
        Color OriginalColor = mySR.color;

        while (timer < ColorShiftTime)
        {
            yield return null;
            timer += Time.deltaTime;
            mySR.color = Color.Lerp(OriginalColor, new Color(0, 1, 1, 1), timer / ColorShiftTime); //blue
        }
        StartCoroutine(TurnMagenta());
    }
    IEnumerator TurnMagenta()
    {
        float timer = 0;
        Color OriginalColor = mySR.color;

        while (timer < ColorShiftTime)
        {
            yield return null;
            timer += Time.deltaTime;
            mySR.color = Color.Lerp(OriginalColor, new Color(1, 0, 1, 1), timer / ColorShiftTime); //magenta
        }
        StartCoroutine(TurnRed());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
