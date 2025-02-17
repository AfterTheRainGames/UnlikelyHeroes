using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth = 20;
    public TextMeshProUGUI healthText;
    public bool dead = false;
    private Animator animator;
    public GameObject UI;
    private Color HPColor;

    public int weakCount = 0;
    public bool shieldOn = false;
    public int shield = 0;
    public bool frozen = false;
    public bool poisoned = false;

    public EnemyManager emScript;

    public AudioSource asOof;
    public AudioSource asVineBoom;

    void Start()
    {
        health = maxHealth;
        healthText.text = "HP: " + health.ToString() + "/" + maxHealth.ToString();
        animator = GetComponent<Animator>();
        HPColor = healthText.color;
    }

    private void Update()
    {
        if (frozen)
        {
            healthText.color = Color.cyan;
        }
        else if (poisoned)
        {
            healthText.color = Color.grey;
        }
        else
        {
            healthText.color = HPColor;
        }
    }

    private IEnumerator Remove(int time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);

        if (GameObject.FindGameObjectsWithTag("Bad").Length == 0)
        {
            emScript.RoundWon();
        }

        if (GameObject.FindGameObjectsWithTag("Good").Length == 0)
        {
            emScript.RoundLost();
        }

        UI.SetActive(false);
    }

    private IEnumerator WaitForHit(float time)
    {
        asOof.Play();
        yield return new WaitForSeconds(time);
        animator.SetTrigger("Hit");
    }

    public void Heal(int healed)
    {
        health += healed;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        healthText.text = "HP: " + health.ToString() + "/" + maxHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        if(shieldOn)
        {
            shield = 1;
        }
        else
        {
            shield = 0;
        }

        health = health - damage - weakCount + shield;
        shieldOn = false;

        if (health <= 0)
        {
            health = 0;
            dead = true;
            animator.SetTrigger("Die");
            asVineBoom.Play(); 
            StartCoroutine(Remove(2));
        }
        else
        {
            StartCoroutine(WaitForHit(.25f));
        }

        healthText.text = "HP: " + health.ToString() + "/" + maxHealth.ToString();

    }

}
