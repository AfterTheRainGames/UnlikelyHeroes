using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{

    public Turns turnsScript;
    public SelectLightScript SLS;
    public Combat combatScript;

    private Vector3 hiddenLight = new Vector3(0, -10, 0);

    public AudioSource magicSound;
    public AudioSource shieldSound;
    public AudioSource roar;

    public Animator bunnyAni;
    public Animator pinkAni;
    public Animator dragAni;
    public Animator wizAni;

    // Bunny Buttons
    public Button Heal;
    public Button Inspire;
    public Button Weaken;

    // Pink Buttons
    public Button Taunt;
    public Button Counter;
    public Button Shield;

    // Drag Buttons
    public Button Punch;
    public Button Fireball;
    public Button HeatBreath;

    // Wiz Buttons
    public Button Freeze;
    public Button Earthquake;
    public Button LightningBolt;

    void Start()
    {
        // Bunny Buttons
        Heal.onClick.AddListener(HealClick);
        Inspire.onClick.AddListener(InspireClick);
        Weaken.onClick.AddListener(WeakenClick);

        // Pink Buttons
        Taunt.onClick.AddListener(TauntClick);
        Counter.onClick.AddListener(CounterClick);
        Shield.onClick.AddListener(ShieldClick);

        // Drag Buttons
        Punch.onClick.AddListener(PunchClick);
        Fireball.onClick.AddListener(FireballClick);
        HeatBreath.onClick.AddListener(HeatBreathClick);

        // Wiz Buttons
        Freeze.onClick.AddListener(FreezeClick);
        Earthquake.onClick.AddListener(EarthquakeClick);
        LightningBolt.onClick.AddListener(LightningBoltClick);
    }

    //Bunny Animations
    public void HealClick()
    {
        if (SLS.isClicked)
        {
            bunnyAni.SetTrigger("Heal");
            magicSound.Play();
            combatScript.UseMove("Heal");
            turnsScript.BunnyTurn = false;
            turnsScript.PinkTurn = true;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void InspireClick()
    {
        if (SLS.isClicked)
        {
            bunnyAni.SetTrigger("Inspire");
            magicSound.Play();
            combatScript.UseMove("Inspire");
            turnsScript.BunnyTurn = false;
            turnsScript.PinkTurn = true;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void WeakenClick()
    {
        if (SLS.isClicked)
        {
            bunnyAni.SetTrigger("Weaken");
            magicSound.Play();
            combatScript.UseMove("Weaken");
            turnsScript.BunnyTurn = false;
            turnsScript.PinkTurn = true;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    //Pink Animations
    public void TauntClick()
    {
        if (SLS.isClicked)
        {
            pinkAni.SetTrigger("Taunt");
            shieldSound.Play();
            combatScript.UseMove("Taunt");
            turnsScript.PinkTurn = false;
            turnsScript.DragTurn = true;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void CounterClick()
    {
        pinkAni.SetTrigger("Counter");
        shieldSound.Play();
        combatScript.UseMove("Counter");
        turnsScript.PinkTurn = false;
        turnsScript.DragTurn = true;
        SLS.isClicked = false;
        SLS.selectorLight.transform.position = hiddenLight;
    }

    public void ShieldClick()
    {
        pinkAni.SetTrigger("Shield");
        shieldSound.Play();
        combatScript.UseMove("Shield");
        turnsScript.PinkTurn = false;
        turnsScript.DragTurn = true;
        SLS.isClicked = false;
        SLS.selectorLight.transform.position = hiddenLight;
    }

    //Dragon Animations
    public void PunchClick()
    {
        if (SLS.isClicked)
        {
            dragAni.SetTrigger("Punch");
            roar.Play();
            combatScript.UseMove("Punch");
            turnsScript.DragTurn = false;
            turnsScript.WizTurn = true;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void FireballClick()
    {
        if (SLS.isClicked)
        {
            dragAni.SetTrigger("Fireball");
            roar.Play();
            combatScript.UseMove("Fireball");
            turnsScript.DragTurn = false;
            turnsScript.WizTurn = true;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void HeatBreathClick()
    {
        dragAni.SetTrigger("HeatBreath");
        roar.Play();
        combatScript.UseMove("HeatBreath");
        turnsScript.DragTurn = false;
        turnsScript.WizTurn = true;
        SLS.isClicked = false;
        SLS.selectorLight.transform.position = hiddenLight;
    }

    //Wizard Animations
    public void FreezeClick()
    {
        if (SLS.isClicked)
        {
            wizAni.SetTrigger("Freeze");
            magicSound.Play();
            combatScript.UseMove("Freeze");
            turnsScript.WizTurn = false;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void EarthquakeClick()
    {
        if (SLS.isClicked)
        {
            wizAni.SetTrigger("Earthquake");
            magicSound.Play();
            combatScript.UseMove("Earthquake");
            turnsScript.WizTurn = false;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }

    public void LightningBoltClick()
    {
        if (SLS.isClicked)
        {
            wizAni.SetTrigger("LightningBolt");
            magicSound.Play();
            combatScript.UseMove("LightningBolt");
            turnsScript.WizTurn = false;
            SLS.isClicked = false;
            SLS.selectorLight.transform.position = hiddenLight;
        }
    }
}
