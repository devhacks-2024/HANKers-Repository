using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System.Collections;

public class flashing : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Coroutine flashingCoroutine;

    bool dir = true;
    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        //flashingCoroutine = StartCoroutine(FlashTextCR());
    }

    private void Update()
    {
        if (dir)
        {
            t += Time.deltaTime;

            // if > 1
            if( t > 1)
            {
                dir = false;
            }
        }
        else
        {
            t -= Time.deltaTime;
            // if < 0
            if(t < 0)
            {
                dir = true;
            }
        }
        text.alpha = t;
        //text.color.MinAlpha = text.color.MinAlpha = t;

        if (text.alpha > 0.9f)
            text.CrossFadeAlpha(0.0f, 1f, false);
        else 
            text.CrossFadeAlpha(1.0f, 1f, false);

    }

    IEnumerator FlashTextCR()
    {
        while (true)
        {


            yield return null;
        }
    }

}
