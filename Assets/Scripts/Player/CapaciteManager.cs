using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapaciteManager : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction capa_01Action;
    private InputAction capa_02Action;
    private InputAction capa_03Action;

    //spell 1:
    private GameObject spell_01;
    private UIcapacite spell_01Front;
    private UIcapaciteBackground spell_01Back;
    private float timerSpell_01;
    private float timerSpell_01Ecoule;
    private bool spell_01Charge = true;

    //spell 2:
    private GameObject spell_02;
    private UIcapacite spell_02Front;
    private UIcapaciteBackground spell_02Back;
    private float timerSpell_02;
    private float timerSpell_02Ecoule;
    private bool spell_02Charge = true;

    //spell 3:
    private GameObject spell_03;
    private UIcapacite spell_03Front;
    private UIcapaciteBackground spell_03Back;
    private float timerSpell_03;
    private float timerSpell_03Ecoule;
    private bool spell_03Charge = true;

    [SerializeField] private Inventory inventory;
    private PlayerMoveManager player;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMoveManager>();
        inventory = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();


        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        capa_01Action = inputs.actions.FindAction("Capacite_01");
        capa_02Action = inputs.actions.FindAction("Capacite_02");
        capa_03Action = inputs.actions.FindAction("Capacite_03");

        spell_01 = GameObject.Find("Spell_01");
        spell_01Front = spell_01.transform.Find("Frontground").gameObject.GetComponent<UIcapacite>();
        spell_01Back = spell_01.transform.Find("Background").gameObject.GetComponent<UIcapaciteBackground>();

        spell_02 = GameObject.Find("Spell_02");
        spell_02Front = spell_02.transform.Find("Frontground").gameObject.GetComponent<UIcapacite>();
        spell_02Back = spell_02.transform.Find("Background").gameObject.GetComponent<UIcapaciteBackground>();

        spell_03 = GameObject.Find("Spell_03");
        spell_03Front = spell_03.transform.Find("Frontground").gameObject.GetComponent<UIcapacite>();
        spell_03Back = spell_03.transform.Find("Background").gameObject.GetComponent<UIcapaciteBackground>();
    }

    public void modifierCapacite()
    {
        if (inventory.GetItem(12).Data != null)
        {
            spell_01Back.UpdateImage(inventory.GetItem(12).Data.getIcon);
            spell_01Front.UpdateImage(inventory.GetItem(12).Data.getIcon);
            spell_01Front.CurrentTime = 100;
            timerSpell_01 = inventory.GetItem(12).Data.getTimerCapacite;
        }

        if (inventory.GetItem(13).Data != null)
        {
            spell_02Back.UpdateImage(inventory.GetItem(13).Data.getIcon);
            spell_02Front.UpdateImage(inventory.GetItem(13).Data.getIcon);
            spell_02Front.CurrentTime = 100;
            timerSpell_02 = inventory.GetItem(13).Data.getTimerCapacite;
        }

        if (inventory.GetItem(14).Data != null)
        {
            spell_03Back.UpdateImage(inventory.GetItem(14).Data.getIcon);
            spell_03Front.UpdateImage(inventory.GetItem(14).Data.getIcon);
            spell_03Front.CurrentTime = 100;
            timerSpell_03 = inventory.GetItem(14).Data.getTimerCapacite;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (capa_01Action.triggered && spell_01Charge)
        {
            Item item = inventory.GetItem(12);
            if (item.Data != null)
            {
                Capacite capacite = item.Data.getCapacite;
                capacite.activer();

                spell_01Front.CurrentTime = 100;
                timerSpell_01Ecoule = 0f;
                spell_01Charge = false;
            }
        }

        timerSpell_01Ecoule += Time.deltaTime;
        if (timerSpell_01Ecoule >= timerSpell_01)
        {
            spell_01Charge = true;
            spell_01Front.CurrentTime = 100;
        }
        if (!spell_01Charge)
        {
            spell_01Front.CurrentTime = (int)(timerSpell_01Ecoule * 100 / timerSpell_01);
        }

        if (capa_02Action.triggered && spell_02Charge)
        {
            Item item = inventory.GetItem(13);
            if (item.Data != null)
            {
                Capacite capacite = item.Data.getCapacite;
                capacite.activer();

                spell_02Front.CurrentTime = 100;
                timerSpell_02Ecoule = 0f;
                spell_02Charge = false;
            }
        }

        timerSpell_02Ecoule += Time.deltaTime;
        if (timerSpell_02Ecoule >= timerSpell_02)
        {
            spell_02Charge = true;
            spell_02Front.CurrentTime = 100;
        }
        if (!spell_02Charge)
        {
            spell_02Front.CurrentTime = (int)(timerSpell_02Ecoule * 100 / timerSpell_02);
        }

        if (capa_03Action.triggered && spell_03Charge)
        {
            Item item = inventory.GetItem(14);
            if (item.Data != null)
            {
                Capacite capacite = item.Data.getCapacite;
                capacite.activer();

                spell_03Front.CurrentTime = 100;
                timerSpell_03Ecoule = 0f;
                spell_03Charge = false;
            }
        }

        timerSpell_03Ecoule += Time.deltaTime;
        if (timerSpell_03Ecoule >= timerSpell_03)
        {
            spell_03Charge = true;
            spell_03Front.CurrentTime = 100;
        }
        if (!spell_03Charge)
        {
            spell_03Front.CurrentTime = (int)(timerSpell_03Ecoule * 100 / timerSpell_03);
        }
    }
}
