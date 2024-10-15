using TMPro;
using UnityEngine;

public class ShopStuff : MonoBehaviour
{
    public TextMeshProUGUI currency;
    public GameObject smileBG, smileBG1, smileBG2, smileBG3,
                      sadBG,   sadBG1,   sadBG2,   sadBG3,
                      cancelButton;
    private int seconds = 60;

    void Start()
    {
        currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);

        switch (PlayerPrefs.GetInt("GrapeEffect", 0))
        {
            case 0:
                {
                    smileBG.SetActive(false);
                    smileBG1.SetActive(false);
                    smileBG2.SetActive(false);
                    smileBG3.SetActive(false);
                    sadBG.SetActive(false);
                    sadBG1.SetActive(false);
                    sadBG2.SetActive(false);
                    sadBG3.SetActive(false);
                    cancelButton.SetActive(false);
                }
                break;
            case 1:
                {
                    smileBG.SetActive(true);
                    sadBG1.SetActive(true);
                    sadBG2.SetActive(true);
                    sadBG3.SetActive(true);
                    if (PlayerPrefs.GetInt("effectsSeconds", seconds) >= seconds - 10)
                        cancelButton.SetActive(true);
                }
                break;
            case 2:
                {
                    smileBG1.SetActive(true);
                    sadBG.SetActive(true);
                    sadBG2.SetActive(true);
                    sadBG3.SetActive(true);
                    if (PlayerPrefs.GetInt("effectsSeconds", seconds) >= seconds - 10)
                        cancelButton.SetActive(true);
                }
                break;
            case 3:
                {
                    smileBG2.SetActive(true);
                    sadBG.SetActive(true);
                    sadBG1.SetActive(true);
                    sadBG3.SetActive(true);
                    if (PlayerPrefs.GetInt("effectsSeconds", seconds) >= seconds - 10)
                        cancelButton.SetActive(true);
                }
                break;
            case 4:
                {
                    smileBG3.SetActive(true);
                    sadBG.SetActive(true);
                    sadBG1.SetActive(true);
                    sadBG2.SetActive(true);
                    if (PlayerPrefs.GetInt("effectsSeconds", seconds) >= seconds - 10)
                        cancelButton.SetActive(true);
                }
                break;
        }
    }

    public void CancelEffects()
    {
        smileBG.SetActive(false);
        smileBG1.SetActive(false);
        smileBG2.SetActive(false);
        smileBG3.SetActive(false);
        sadBG.SetActive(false);
        sadBG1.SetActive(false);
        sadBG2.SetActive(false);
        sadBG3.SetActive(false);
        cancelButton.SetActive(false);

        switch (PlayerPrefs.GetInt("GrapeEffect", 0))
        {
            case 1:
                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) + 100));
                break;
            case 2:
                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) + 200));
                break;
            case 3:
                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) + 100));
                break;
            case 4:
                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) + 200));
                break;
        }

        PlayerPrefs.SetInt("GrapeEffect", 0);
        currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
    }

    public void GrapesTimesTwo()
    {
        if (PlayerPrefs.GetInt("GrapeEffect", 0) == 0)
        {
            if (PlayerPrefs.GetInt("GrapesSaved", 0) >= 100)
            {
                smileBG.SetActive(true);
                sadBG1.SetActive(true);
                sadBG2.SetActive(true);
                sadBG3.SetActive(true);
                cancelButton.SetActive(true);

                PlayerPrefs.SetInt("effectsSeconds", seconds);

                PlayerPrefs.SetInt("GrapeEffect", 1);

                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) - 100));

                currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
            }
        }
    }

    public void GrapesTimesThree()
    {
        if(PlayerPrefs.GetInt("GrapeEffect", 0) == 0)
        {
            if (PlayerPrefs.GetInt("GrapesSaved", 0) >= 200)
            {
                smileBG1.SetActive(true);
                sadBG.SetActive(true);
                sadBG2.SetActive(true);
                sadBG3.SetActive(true);
                cancelButton.SetActive(true);

                PlayerPrefs.SetInt("effectsSeconds", seconds);

                PlayerPrefs.SetInt("GrapeEffect", 2);

                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) - 200));

                currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
            }
        }
    }

    public void GrapesTiny()
    {
        if (PlayerPrefs.GetInt("GrapeEffect", 0) == 0)
        {
            if (PlayerPrefs.GetInt("GrapesSaved", 0) >= 100)
            {
                smileBG2.SetActive(true);
                sadBG.SetActive(true);
                sadBG1.SetActive(true);
                sadBG3.SetActive(true);
                cancelButton.SetActive(true);

                PlayerPrefs.SetInt("effectsSeconds", seconds);

                PlayerPrefs.SetInt("GrapeEffect", 3);

                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) - 100));

                currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
            }
        }
    }

    public void GrapesGiant()
    {
        if (PlayerPrefs.GetInt("GrapeEffect", 0) == 0)
        {
            if (PlayerPrefs.GetInt("GrapesSaved", 0) >= 200)
            {
                smileBG3.SetActive(true);
                sadBG.SetActive(true);
                sadBG1.SetActive(true);
                sadBG2.SetActive(true);
                cancelButton.SetActive(true);

                PlayerPrefs.SetInt("effectsSeconds", seconds);

                PlayerPrefs.SetInt("GrapeEffect", 4);

                PlayerPrefs.SetInt("GrapesSaved", (PlayerPrefs.GetInt("GrapesSaved", 0) - 200));

                currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
            }
        }
    }
}
