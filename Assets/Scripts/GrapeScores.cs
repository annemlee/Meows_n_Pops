using System.Collections;
using TMPro;
using UnityEngine;

public class GrapeScores : MonoBehaviour
{
    private int savedScore = 0,
                lostScore = 0;
    private bool alreadyEncouraged = false,
                 alreadyDiscouraged = false,
                 meowing = false;
    public TextMeshProUGUI savedText,
                           lostText;
    public GameObject encouragement,
                      discouragement,
                      MP;
    private Animator animator;
    public AudioSource audsrc;
    public AudioClip yay,
                     uhOh;

    private void Awake()
    {
        savedText.text = ":)  " + PlayerPrefs.GetInt("GrapesSaved", 0);
        lostText.text = ":(  " + PlayerPrefs.GetInt("GrapesLost", 0);
        savedScore = PlayerPrefs.GetInt("GrapesSaved", 0);
        lostScore = PlayerPrefs.GetInt("GrapesLost", 0);

        animator = MP.GetComponent<Animator>();
    }

    private void Update()
    {
        if (savedScore != 0 && savedScore % 100 == 0 && alreadyEncouraged == false)
        {
            alreadyEncouraged = true;

            animator.SetBool("isIdle", false);
            animator.SetBool("isCheering", true);
            animator.SetBool("isDisappointed", false);

            audsrc.clip = yay;
            audsrc.Play();

            discouragement.SetActive(false);
            encouragement.SetActive(true);
            StartCoroutine("RemoveEncouragement");
        }

        if (lostScore != 0 && lostScore % 100 == 0 && alreadyDiscouraged == false)
        {
            alreadyDiscouraged = true;

            animator.SetBool("isIdle", false);
            animator.SetBool("isCheering", false);
            animator.SetBool("isDisappointed", true);

            audsrc.clip = uhOh;
            audsrc.Play();

            encouragement.SetActive(false);
            discouragement.SetActive(true);

            StartCoroutine("RemoveDiscouragement");
        }
    }

    public void saveGrape()
    {
        meowing = true;

        animator.SetBool("isIdle", false);
        animator.SetBool("isMeowing", true);
        animator.SetBool("isFrowning", false);
        StartCoroutine(RemoveMeowHead());

        if(savedScore <= 999999)
        {
            savedScore++;
            savedText.text = ":)  " + savedScore;
        }

        alreadyEncouraged = false;

        PlayerPrefs.SetInt("GrapesSaved", savedScore);
    }

    public void loseGrape()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isMeowing", false);
        animator.SetBool("isFrowning", true);
        StartCoroutine(RemoveFrownHead());

        if (lostScore <= 999999)
        {
            lostScore++;
            lostText.text = ":(  " + lostScore;
        }

        alreadyDiscouraged = false;

        PlayerPrefs.SetInt("GrapesLost", lostScore);
    }

    IEnumerator RemoveEncouragement()
    {
        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(0.8f);
        encouragement.SetActive(false);

        animator.SetBool("isIdle", true);
        animator.SetBool("isCheering", false);
        animator.SetBool("isDisappointed", false);

        Time.timeScale = 1f;
    }

    IEnumerator RemoveDiscouragement()
    {
        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(0.8f);
        discouragement.SetActive(false);

        animator.SetBool("isIdle", true);
        animator.SetBool("isCheering", false);
        animator.SetBool("isDisappointed", false);

        Time.timeScale = 1f;
    }

    IEnumerator RemoveMeowHead()
    {
        yield return new WaitForSeconds(0.7f);

        meowing = false;

        animator.SetBool("isIdle", true);
        animator.SetBool("isMeowing", false);
        animator.SetBool("isFrowning", false);
    }

    IEnumerator RemoveFrownHead()
    {
        yield return new WaitForSeconds(0.7f);

        if(!meowing)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isMeowing", false);
            animator.SetBool("isFrowning", false);
        }
    }
}
