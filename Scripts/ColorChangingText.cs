using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections;

public class ColorChangingText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;


    void Start()
    {
        // Get a reference to the TextMeshProUGUI component attached to the GameObject
        textComponent = GetComponent<TextMeshProUGUI>();
        // Start the coroutine to flash and fade the text
        StartCoroutine(FlashFadeText());
    }

    IEnumerator FlashFadeText()
    {
        while (true)
        {
            // Fade the text in by setting its alpha to 1 over a duration of 0.5 seconds
            textComponent.CrossFadeAlpha(1f, 0.5f, false);

            // Wait for 0.3 seconds
            yield return new WaitForSeconds(0.3f);

            // Fade the text out by setting its alpha to 0 over a duration of 0.5 seconds
            textComponent.CrossFadeAlpha(0f, 0.5f, false);

            // Wait for 0.3 seconds
            yield return new WaitForSeconds(0.3f);
        }
    }
}