using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    public bool TurnsActive;
    public bool BunnyTurn;
    public bool PinkTurn;
    public bool DragTurn;
    public bool WizTurn;

    public GameObject bunny;
    public GameObject pink;
    public GameObject drag;
    public GameObject wiz;

    public Combat combatScript;
    public EnemyManager emScript;

    public GameObject BunnyUI;
    private Button[] bunnyButtons;
    public GameObject PinkUI;
    private Button[] pinkButtons;
    public GameObject DragUI;
    private Button[] dragButtons;
    public GameObject WizUI;
    private Button[] wizButtons;

    public RawImage BunnyWhite;
    public RawImage PinkWhite;
    public RawImage DragWhite;
    public RawImage WizWhite;
    private Color yellowShade = new Color(.949f, .949f, .619f);
    private Color defaultShade = Color.white; 

    void Start()
    {
        bunnyButtons = BunnyUI.GetComponentsInChildren<Button>();
        pinkButtons = PinkUI.GetComponentsInChildren<Button>();
        dragButtons = DragUI.GetComponentsInChildren<Button>();
        wizButtons = WizUI.GetComponentsInChildren<Button>();



        TurnsActive = true;
        BunnyTurn = true;
    }

    void Update()
    {
        Health bunnyHealth = bunny.GetComponent<Health>();
        Health pinkHealth = pink.GetComponent<Health>();
        Health dragHealth = drag.GetComponent<Health>();
        Health wizHealth = wiz.GetComponent<Health>();

        if (TurnsActive)
        {
            WhosTurn();
        }
    }

    public void WhosTurn()
    {
        Health bunnyHealth = bunny.GetComponent<Health>();
        Health pinkHealth = pink.GetComponent<Health>();
        Health dragHealth = drag.GetComponent<Health>();
        Health wizHealth = wiz.GetComponent<Health>();

        DisableButtons();

        if (TurnsActive)
        {
            if (BunnyTurn)
            {
                if (BunnyUI.activeSelf && !bunnyHealth.frozen)
                {
                    EnableTurn(BunnyWhite, bunnyButtons);
                }
                else
                {
                    bunnyHealth.frozen = false;
                    BunnyTurn = false;
                    PinkTurn = true;
                }

                if (bunnyHealth.poisoned)
                {
                    bunnyHealth.TakeDamage(1);
                    bunnyHealth.poisoned = false;
                }
            }
            else if (PinkTurn)
            {
                if (PinkUI.activeSelf && !pinkHealth.frozen)
                {
                    EnableTurn(PinkWhite, pinkButtons);
                }
                else
                {
                    BunnyWhite.color = defaultShade;
                    pinkHealth.frozen = false;
                    PinkTurn = false;
                    DragTurn = true;
                }

                if (pinkHealth.poisoned)
                {
                    pinkHealth.TakeDamage(1);
                    pinkHealth.poisoned = false;
                }
            }
            else if (DragTurn)
            {
                if (DragUI.activeSelf && !dragHealth.frozen)
                {
                    EnableTurn(DragWhite, dragButtons);
                }
                else
                {
                    PinkWhite.color = defaultShade;
                    dragHealth.frozen = false;
                    DragTurn = false;
                    WizTurn = true;
                }

                if (dragHealth.poisoned)
                {
                    dragHealth.TakeDamage(1);
                    dragHealth.poisoned = false;
                }
            }
            else if (WizTurn)
            {
                if (WizUI.activeSelf && !wizHealth.frozen)
                {
                    EnableTurn(WizWhite, wizButtons);
                }
                else
                {
                    DragWhite.color = defaultShade;
                    wizHealth.frozen = false;
                    WizTurn = false;
                }

                if (wizHealth.poisoned)
                {
                    wizHealth.TakeDamage(1);
                    wizHealth.poisoned = false;
                }
            }
            else
            {
                WizWhite.color = defaultShade;
                TurnsActive = false;
                emScript.PreformAttack();
                BunnyTurn = true;
            }
        }

    }

    public void EnableTurn(RawImage activeColor, Button[] activeButtons)
    {
        BunnyWhite.color = defaultShade;
        PinkWhite.color = defaultShade;
        DragWhite.color = defaultShade;
        WizWhite.color = defaultShade;

        activeColor.color = yellowShade;

        foreach (Button btn in activeButtons)
        {
            btn.interactable = true;
        }
    }

    public void DisableButtons()
    {
        foreach(Button btn in bunnyButtons)
        {
            btn.interactable = false;
        }
        foreach (Button btn in pinkButtons)
        {
            btn.interactable = false;
        }
        foreach (Button btn in dragButtons)
        {
            btn.interactable = false;
        }
        foreach (Button btn in wizButtons)
        {
            btn.interactable = false;
        }
    }
}
