using System.Collections;
using TMPro;
using UnityEngine;

public class EffectsTimer : MonoBehaviour
{
    public GameObject effectsDuration,
                      cancelButton;
    public TextMeshProUGUI effectsDurationTxt;

    void Start()
    {
        //PlayerPrefs.SetInt("effectsSeconds", PlayerPrefs.GetInt("effectsSeconds", 60));

        if (PlayerPrefs.GetInt("GrapeEffect", 0) > 0)
        {
            effectsDuration.SetActive(true);
            cancelButton.SetActive(true);
            effectsDurationTxt.text = PlayerPrefs.GetInt("effectsSeconds").ToString();
            StartCoroutine(CountSeconds());
        }
    }

    IEnumerator CountSeconds()
    {
        yield return new WaitForSeconds(1f);

        PlayerPrefs.SetInt("effectsSeconds", PlayerPrefs.GetInt("effectsSeconds") - 1);
        
        effectsDurationTxt.text = PlayerPrefs.GetInt("effectsSeconds").ToString();

        if (PlayerPrefs.GetInt("effectsSeconds") > 0)
            StartCoroutine(CountSeconds());
        else
        {
            effectsDuration.SetActive(false);
            cancelButton.SetActive(false);
            PlayerPrefs.SetInt("GrapeEffect", 0);
        }
    }
}
