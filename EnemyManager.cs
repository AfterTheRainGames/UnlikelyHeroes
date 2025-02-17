using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyManager : MonoBehaviour
{

    public Turns turnScript;
    public Combat combatScript;
    public GameObject[] badGuys;
    public GameObject spawn;
    private int round = 1;
    public GameObject pink;

    public GameObject round1;
    public GameObject round2;
    public GameObject round3;
    public GameObject round4;
    public GameObject round5;
    public GameObject round6;
    public GameObject round7;
    public GameObject round8;
    public GameObject round9; 

    public AudioSource lossSound;

    public void Start()
    {
        round1.SetActive(true);
        round2.SetActive(false);
        round3.SetActive(false);
        round4.SetActive(false);
        round5.SetActive(false);
        round6.SetActive(false);
        round7.SetActive(false);
        round8.SetActive(false);
        round9.SetActive(false);
        badGuys = GetActiveBadGuys();
    }

    public GameObject[] GetActiveBadGuys()
    {
        return System.Array.FindAll(GameObject.FindGameObjectsWithTag("Bad"), enemy => enemy.activeInHierarchy);
    }

    public void Update()
    {
        badGuys = GetActiveBadGuys();
    }

    public void SpawnBads(int round)
    {

        StartCoroutine(AfterWin(round));

    }

    private IEnumerator AfterWin(int round)
    {
        if (round == 2)
        {
            yield return new WaitForSeconds(2);
            round2.SetActive(true);
            round2.transform.position = spawn.transform.position;
        }
        else if (round == 3)
        {
            yield return new WaitForSeconds(2);
            round3.SetActive(true);
            round3.transform.position = spawn.transform.position;
        }
        else if (round == 4)
        {
            yield return new WaitForSeconds(2);
            round4.SetActive(true);
            round4.transform.position = spawn.transform.position;
        }
        else if (round == 5)
        {
            yield return new WaitForSeconds(2);
            round5.SetActive(true);
            round5.transform.position = spawn.transform.position;
        }
        else if (round == 6)
        {
            yield return new WaitForSeconds(2);
            round6.SetActive(true);
            round6.transform.position = spawn.transform.position;
        }
        else if (round == 7)
        {
            yield return new WaitForSeconds(2);
            round7.SetActive(true);
            round7.transform.position = spawn.transform.position;
        }
        else if (round == 8)
        {
            yield return new WaitForSeconds(2);
            round8.SetActive(true);
            round8.transform.position = spawn.transform.position;
        }
        else if (round == 9)
        {
            yield return new WaitForSeconds(2);
            round9.SetActive(true);
            round9.transform.position = spawn.transform.position;
        }
        else
        {
            yield return new WaitForSeconds(2);
        }
}

    public void PreformAttack()
    {
        StartCoroutine(WaitToAttack());
    }

    private IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(1);
        badGuys = GetActiveBadGuys();
        foreach (GameObject enemy in badGuys)
        {
            Health enemyHealth = enemy.GetComponent<Health>();

            if (enemyHealth.health > 0)
            {
                if (!enemyHealth.frozen)
                {
                    yield return new WaitForSeconds(2);
                    GameObject target = GetRandomTarget();
                    int dmg = MoveSelect();
                    Health targetHealth = target.GetComponent<Health>();

                    if (target.name == "Pink" && combatScript.CounterOn)
                    {
                        targetHealth = enemy.GetComponent<Health>();
                        Animator pinkAnimator = pink.GetComponent<Animator>();
                        pinkAnimator.SetTrigger("Counter");
                        combatScript.CounterOn = false;
                    }

                    Animator animator = enemy.GetComponent<Animator>();

                    if(round == 3)
                    {
                        targetHealth.TakeDamage(dmg * 2);
                    }
                    else if(round == 4 || round == 5)
                    {
                        int randomNumber = Random.Range(1, 10);
                        if (randomNumber <= 3)
                        {
                            targetHealth.frozen = true;
                        }
                        targetHealth.TakeDamage(dmg);
                    }
                    else if(round == 6)
                    {
                        targetHealth.frozen = true;
                        targetHealth.TakeDamage(dmg * 2);
                    }
                    else if(round == 7 || round == 8)
                    {
                        int randomNumber = Random.Range(1, 10);
                        if (randomNumber <= 6)
                        {
                            targetHealth.poisoned = true;
                        }
                        targetHealth.TakeDamage(dmg);
                    }
                    else if(round == 9)
                    {
                        targetHealth.poisoned = true;
                        targetHealth.TakeDamage(dmg);
                    }
                    else
                    {
                        targetHealth.TakeDamage(dmg);
                    }
                    animator.SetTrigger("Punch");
                }
                else
                {
                    enemyHealth.frozen = false;
                }
            }
        }
        turnScript.TurnsActive = true;
    }

    public GameObject GetRandomTarget()
    {
        if (combatScript.TauntOn)
        {
            GameObject goodTargets = pink;
            combatScript.TauntOn = false;
            return goodTargets;
        }
        else
        {
            GameObject[] goodTargets = GameObject.FindGameObjectsWithTag("Good");
            return goodTargets[Random.Range(0, goodTargets.Length)];
        }
    }

    public int MoveSelect()
    {
        int move = Random.Range(1, 4);

        switch(move)
        {
            case 1:
                return 1;

            case 2:
                return 2;

            case 3:
                return  3;

            case 4:
                return 4;

            default:
                return 0;
        }
    }

    public void RoundWon()
    {
        round++;

        if(round != 10)
        {
            SpawnBads(round);
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }

    public void RoundLost()
    {
        lossSound.Play();
    }

}
