using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public float minValue = 0f;
    public float maxValue = 10f;
    public float loadingSpeed = 2;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = minValue;
        slider.maxValue = maxValue;
    }

    private void Update()
    {
        slider.value += loadingSpeed * Time.deltaTime;

        if (slider.value >= maxValue)
        {
            SceneManager.LoadScene(3);
        }
        
    }
}



