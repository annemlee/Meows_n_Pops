using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu,
                       settingsMenu,
                       settingsBackground,
                       shopBackground,
                       soundIcon,
                       noSoundIcon,
                       musicIcon,
                       noMusicIcon;
    private bool soundEffectsOn = true,
                 musicOn = true;
    public bool gameIsPaused = false;
    public AudioSource soundSrc,
                       musicSrc,
                       buttonSrc,
                       purrSrc;
    public AudioClip cloudPoof,
                     mcBreak,
                     musicBG;

    void Start()
    {
        if(PlayerPrefs.GetInt("soundOff", 0) == 1)
        {
            soundEffectsOn = true;
            ToggleSoundEffects();
        }

        if (PlayerPrefs.GetInt("musicOff", 0) == 1)
        {
            musicOn = true;
            ToggleMusic();
        }

        musicSrc.clip = musicBG;
        musicSrc.Play();
    }

    public void PlayButton()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        StartCoroutine(GoPlay());
    }

    public void PauseGame()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        soundSrc.Pause();
        purrSrc.Pause();

        gameIsPaused = true;

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CancelEffects()
    {
        PlayerPrefs.SetInt("GrapeEffect", 0);

        gameObject.GetComponent<EffectsTimer>().effectsDuration.SetActive(false);
        gameObject.GetComponent<EffectsTimer>().cancelButton.SetActive(false);
    }

    public void ResumeGame()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        soundSrc.UnPause();
        purrSrc.UnPause();

        gameIsPaused = false;

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToSettingsFromMenu()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        StartCoroutine(LagSettings());
    }

    public void ExitSettingsFromMenu()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        StartCoroutine(LagToMenu());
    }

    public void GoToSettingsFromGameplay()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ExitSettingsFromGameplay()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ToggleSoundEffects()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        if (soundEffectsOn)
        {
            soundSrc.mute = true;
            buttonSrc.mute = true;
            purrSrc.mute = true;
            soundEffectsOn = false;
            soundIcon.SetActive(false);
            noSoundIcon.SetActive(true);
            PlayerPrefs.SetInt("soundOff", 1);
        }
        else
        {
            soundSrc.mute = false;
            buttonSrc.mute = false;
            purrSrc.mute = false;
            soundEffectsOn = true;
            soundIcon.SetActive(true);
            noSoundIcon.SetActive(false);
            PlayerPrefs.SetInt("soundOff", 0);
        }
    }

    public void ToggleMusic()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        if (musicOn)
        {
            musicOn = false;
            musicSrc.mute = true;
            musicIcon.SetActive(false);
            noMusicIcon.SetActive(true);
            PlayerPrefs.SetInt("musicOff", 1);
        }
        else
        {
            musicOn = true;
            musicSrc.mute = false;
            musicIcon.SetActive(true);
            noMusicIcon.SetActive(false);
            PlayerPrefs.SetInt("musicOff", 0);
        }
    }

    public void ReturnHome()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        StartCoroutine(GoHome());

        Time.timeScale = 1f;
    }

    public void ResetButton()
    {
        buttonSrc.clip = cloudPoof;
        buttonSrc.Play();

        PlayerPrefs.SetInt("GrapesSaved", 0);
        PlayerPrefs.SetInt("GrapesLost", 0);

        shopBackground.GetComponent<ShopStuff>().currency.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
    }

    public void GoShopping()
    {
        buttonSrc.clip = mcBreak;
        buttonSrc.Play();

        StartCoroutine(LagShop());
    }

    IEnumerator GoHome()
    {
        yield return new WaitForSeconds(0.4f);

        SceneManager.LoadScene(0);
    }

    IEnumerator GoPlay()
    {
        yield return new WaitForSeconds(0.4f);

        SceneManager.LoadScene(1);
    }

    IEnumerator LagSettings()
    {
        yield return new WaitForSeconds(0.4f);

        settingsBackground.SetActive(true);
    }

    IEnumerator LagToMenu()
    {
        yield return new WaitForSeconds(0.4f);
        settingsBackground.SetActive(false);
        shopBackground.SetActive(false);
    }

    IEnumerator LagShop()
    {
        yield return new WaitForSeconds(0.4f);

        shopBackground.SetActive(true);
    }
} 