using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{

    public SelectLightScript SLS;
    public EnemyManager emScript;

    public Turns turnsScript;
    private GameObject selectedChar;
    private int dmgDrag = 1;
    private int inspDrag = 0;
    private int dmgWiz = 1;
    private int inspWiz = 0;
    public TextMeshProUGUI dmgDragText;
    public TextMeshProUGUI dmgWizText;
    private int fireballNumber = 3;
    public TextMeshProUGUI fireballNumberText;

    public Button help;
    public GameObject helpImg;

    public bool TauntOn = false;
    public bool CounterOn = false;

    private void Start()
    {
        helpImg.SetActive(false);
        fireballNumberText.text = "FB: " + fireballNumber.ToString() + "0%";
        help.onClick.AddListener(helpClicked);
    }

    private void Update()
    {
        Debug.Log(fireballNumber);
        inspDrag = dmgDrag - 1;
        inspWiz = dmgWiz - 1;
        dmgDragText.text = "Dmg + " + inspDrag.ToString();
        dmgWizText.text = "Dmg + " + inspWiz.ToString();
    }

    public void helpClicked()
    {
        helpImg.SetActive(!helpImg.activeSelf);
    }

    public void UseMove(string moveName)
    {
        selectedChar = SLS.hitObject;
        ApplyMove(moveName, selectedChar);
    }

    public void ApplyMove(string moveName, GameObject selectedChar)
    {

        switch (moveName)
        {
            case "Heal":
                Heal(selectedChar);
                break;

            case "Inspire":
                Inspire(selectedChar);
                break;

            case "Weaken":
                Weaken(selectedChar);
                break;

            case "Taunt":
                Taunt(selectedChar);
                break;

            case "Counter":
                Counter(selectedChar);
                break;

            case "Shield":
                Shield(selectedChar);
                break;

            case "Punch":
                Punch(selectedChar);
                break;

            case "Fireball":
                Fireball(selectedChar);
                break;

            case "HeatBreath":
                HeatBreath(selectedChar);
                break;

            case "Freeze":
                Freeze(selectedChar);
                break;

            case "Earthquake":
                Earthquake(selectedChar);
                break;

            case "LightningBolt":
                LightningBolt(selectedChar);
                break;
        }
    }

    public void Heal(GameObject selectedChar)
    {
        Health selectedHealth = selectedChar.GetComponent<Health>();
        selectedHealth.Heal(3);
    }

    public void Inspire(GameObject selectedChar)
    {
        if(selectedChar.name == "Drag")
        {
            dmgDrag += 1;
        }
        else if(selectedChar.name == "Wiz")
        {
            dmgWiz += 1;
        }
    }

    public void Weaken(GameObject selectedChar)
    {
        Health selectedHealth = selectedChar.GetComponent<Health>();
        selectedHealth.weakCount ++;
    }

    public void Taunt(GameObject selectedChar)
    {
        TauntOn = true;
    }

    public void Counter(GameObject selectedChar)
    {
        CounterOn = true;
    }

    public void Shield(GameObject selectedChar)
    {
        Health selectedHealth = selectedChar.GetComponent<Health>();
        selectedHealth.shieldOn = true;
    }

    public void Punch(GameObject selectedChar)
    {
        Health selectedHealth = selectedChar.GetComponent<Health>();
        selectedHealth.TakeDamage(dmgDrag);
    }

    public void Fireball(GameObject selectedChar)
    {
        Health selectedHealth = selectedChar.GetComponent<Health>();

        int randomNumber = Random.Range(1, 10);
        if(randomNumber <= fireballNumber)
        {
            selectedHealth.TakeDamage(dmgDrag + 3);
        }
    }

    public void HeatBreath(GameObject selectedChar)
    {
        fireballNumber ++;

        if(fireballNumber > 10)
        { 
            fireballNumber = 10;
        }

        fireballNumberText.text = "FB: " + fireballNumber.ToString() + "0%";
    }

    public void Freeze(GameObject selectedChar)
    {
        Health selectedHealth = selectedChar.GetComponent<Health>();
        selectedHealth.TakeDamage(dmgWiz);

        int randomNumber = Random.Range(1, 10);
        if (randomNumber <= 6)
        {
            selectedHealth.frozen = true;
        }
    }

    public void Earthquake(GameObject selectedChar)
    {
        foreach(GameObject enemy in emScript.badGuys)
        {
                Health enemyHealth = enemy.GetComponent<Health>();
                enemyHealth.TakeDamage(1);
        }
    }

    public void LightningBolt(GameObject selectedChar)
    {
        GameObject randomEnemy = emScript.badGuys[Random.Range(0, emScript.badGuys.Length)];
        Health enemyHealth = randomEnemy.GetComponent<Health>();
        enemyHealth.TakeDamage(dmgWiz + 1);
    }

}
