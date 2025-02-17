using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MM : MonoBehaviour
{

    public GameObject bunny;
    public GameObject pink;
    public GameObject drag;
    public GameObject wiz;
    public Button playButton;

    void Start()
    {

        playButton.onClick.AddListener(PlayPushed);
        bunny.SetActive(true);
        pink.SetActive(false);
        drag.SetActive(false);
        wiz.SetActive(false);
        Rotate();
    }

    public void PlayPushed()
    {
        SceneManager.LoadScene("Game");
    }

    private void Rotate()
    {
        StartCoroutine(Cycle());
    }

    private IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            bunny.SetActive(false);
            pink.SetActive(true);
            yield return new WaitForSeconds(1);
            pink.SetActive(false);
            drag.SetActive(true);
            yield return new WaitForSeconds(1);
            drag.SetActive(false);
            wiz.SetActive(true);
            yield return new WaitForSeconds(1);
            wiz.SetActive(false);
            bunny.SetActive(true);
        }
    }

}
