using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class SpellHandler : MonoBehaviour
{

    public GameObject aqua1;
    public GameObject aqua2;
    public GameObject aqua3;
    public GameObject aqua4;
    public GameObject igni1;
    public GameObject igni2;
    public GameObject igni3;
    public GameObject igni4;
    public GameObject lux1;
    public GameObject lux2;
    public GameObject lux3;
    public GameObject lux4;
    public GameObject aero1;
    public GameObject aero2;
    public GameObject aero3;
    public GameObject aero4;

    public GameObject aqua11;
    public GameObject igni11;
    public GameObject lux11;
    public GameObject aero11;


    List<string> options;
    Dictionary<string, GameObject> currentSpells;
    //[SerializeField] Dropdown slotOne;
    //[SerializeField] GameObject one;
    //[SerializeField] GameObject two;
    //[SerializeField] GameObject three;

    // Use this for initialization
    void Start()
    {
        /*
        currentSpells = new Dictionary<string, GameObject>();
        currentSpells.Add(one.name, one);
        currentSpells.Add(two.name, two);
        currentSpells.Add(three.name, three);
        slotOne.AddOptions(options);*/

    }

    // Update is called once per frame
    void Update()
    {
        //slotOne.onValueChanged.AddListener(delegate { DropdownValueChanged(slotOne); });
    }

   // void DropdownValueChanged(Dropdown change)
    //{
        //slotOne.captionText.text = "" + options[change.value];
    //}

    public void addSpell()
    {
        options.Add("");
    }
}
