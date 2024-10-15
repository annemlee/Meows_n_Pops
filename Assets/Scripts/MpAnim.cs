using System.Collections;
using UnityEngine;

public class MpAnim : MonoBehaviour
{
    public GameObject MP,
                      playCanvas;
    private Animator animator;
    public AudioSource audsrc,
                       purrsrc;
    public AudioClip purr;
    private bool didPurr = false,
                 alreadyWaiting = false;

    private void Awake()
    {
        animator = MP.GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if(playCanvas.GetComponent<Buttons>().gameIsPaused == false)
        {
            if (didPurr == false)
                StartCoroutine(Purr());
            else if (alreadyWaiting == false)
                StartCoroutine(WaitPurr());
        }
    }

    IEnumerator Purr()
    {
        didPurr = true;

        audsrc.mute = true;
        purrsrc.clip = purr;
        purrsrc.Play();

        animator.SetBool("isIdle", false);
        animator.SetBool("isCheering", false);
        animator.SetBool("isDisappointed", false);
        animator.SetBool("isMeowing", false);
        animator.SetBool("isFrowning", false);
        animator.SetBool("isPurring", true);

        yield return new WaitForSeconds(2f);

        audsrc.mute = false;

        animator.SetBool("isPurring", false);
    }

    IEnumerator WaitPurr()
    {
        alreadyWaiting = true;
        yield return new WaitForSeconds(3f);
        alreadyWaiting = false;
        didPurr = false;
    }
}
