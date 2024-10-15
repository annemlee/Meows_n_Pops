using System.Collections;
using UnityEngine;

public class SpawnGrapes : MonoBehaviour
{
    public GameObject grape,
                      ground;
    private float xPosition;
    public GameObject playCanvas;
    public AudioSource audsrc;
    public AudioClip meow1, meow2, meow3, meow4, meow5,
                     pop1,  pop2,  pop3;
    private int randomMeow = 1, lastMeow = 0,
                randomPop = 1,  lastPop = 0;

    private void Start()
    {
        switch(PlayerPrefs.GetInt("GrapeEffect", 0))
        {
            case 0:
                StartCoroutine(SpawnGrape());
                break;
            case 1:
                StartCoroutine(DoubleGrapes());
                break;
            case 2:
                StartCoroutine(TripleGrapes());
                break;
            case 3:
                StartCoroutine(ShrinkGrapes());
                break;
            case 4:
                StartCoroutine(GrowGrapes());
                break;
        }

        xPosition = Random.Range(-(playCanvas.GetComponent<RectTransform>().rect.width * 0.0021f),
                                  (playCanvas.GetComponent<RectTransform>().rect.width * 0.0021f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playCanvas.GetComponent<Buttons>().gameIsPaused == false)
            if(collision.gameObject.tag == "Ground")
            {
                lastPop = PlayerPrefs.GetInt("lastPop", 0);
                randomPop = Random.Range(1, 4);
                while (randomPop == lastPop)
                {
                    randomPop = Random.Range(1, 4);
                }
                lastPop = randomPop;
                PlayerPrefs.SetInt("lastPop", lastPop);

                switch (randomPop)
                {
                    case 1:
                        audsrc.clip = pop1;
                        break;
                    case 2:
                        audsrc.clip = pop2;
                        break;
                    default:
                        audsrc.clip = pop3;
                        break;
                }
                audsrc.Play();

                Destroy(grape);
                ground.GetComponent<GrapeScores>().loseGrape();
            }
    }

    private void OnMouseDown()
    {
        if (playCanvas.GetComponent<Buttons>().gameIsPaused == false)
        {
            lastMeow = PlayerPrefs.GetInt("lastMeow", 0);
            randomMeow = Random.Range(1, 6);
            while (randomMeow == lastMeow)
            {
                randomMeow = Random.Range(1, 6);
            }
            lastMeow = randomMeow;
            PlayerPrefs.SetInt("lastMeow", lastMeow);

            switch (randomMeow)
            {
                case 1:
                    audsrc.clip = meow1;
                    break;
                case 2:
                    audsrc.clip = meow2;
                    break;
                case 3:
                    audsrc.clip = meow3;
                    break;
                case 4:
                    audsrc.clip = meow4;
                    break;
                default:
                    audsrc.clip = meow5;
                    break;
            }
            audsrc.Play();

            Destroy(grape);
            ground.GetComponent<GrapeScores>().saveGrape();
        }
    }

    IEnumerator SpawnGrape()
    {
        grape.transform.localScale = new Vector3(0.7f, 0.6f, 0);

        yield return new WaitForSeconds(0.9f);

        Instantiate(grape, new Vector3(xPosition, 7f, 0), Quaternion.identity);
    }

    IEnumerator DoubleGrapes()
    {
        yield return new WaitForSeconds(0.45f);

        Instantiate(grape, new Vector3(xPosition, 7f, 0), Quaternion.identity);
    }

    IEnumerator TripleGrapes()
    {
        yield return new WaitForSeconds(0.3f);

        Instantiate(grape, new Vector3(xPosition, 7f, 0), Quaternion.identity);
    }

    IEnumerator ShrinkGrapes()
    {
        grape.transform.localScale = new Vector3(0.5f, 0.35f, 0);

        yield return new WaitForSeconds(0.9f);

        Instantiate(grape, new Vector3(xPosition, 7f, 0), Quaternion.identity);
    }

    IEnumerator GrowGrapes()
    {
        grape.transform.localScale = new Vector3(1.3f, 1.1f, 0);

        yield return new WaitForSeconds(0.9f);

        Instantiate(grape, new Vector3(xPosition, 7f, 0), Quaternion.identity);
    }
}
