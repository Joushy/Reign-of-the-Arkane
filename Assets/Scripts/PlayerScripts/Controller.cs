using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Controller : MonoBehaviour
{

    private GameObject player;
    private Animator anim;
    [SerializeField] float speed, healSpeed;
    [SerializeField] GameObject leftHand, rightHand, leftFoot, rightFoot, wall, sparkles, healingEffect;
    private bool attacking, canTurn;
    public int attackNum, num;
    private bool grounded = true;
    public bool jumped, wait, swapping, vertical, hault, hit;
    public int mode = 1;
    private Rigidbody rb;
    private string forward;
    public bool left = false;
    bool right = true;
    bool once = true;
    bool check, restart, nope, healing;
    private float distance;
    private Transform hallwayCube;
    public bool ability2, ability3, ability4;

    GameObject[] enemies;
    [SerializeField] GameObject spawnThing;

    GameObject currentSpell, comboSpell, spire;
    private float startTime, waitTime;

    Vector3 rot;
    SpellHandler spells;

    public enum states { death, flinch, idle, walk, run, jump, fall, land, attack, waitDelay, heals };
    states currentState = states.idle;


    // Use this for initialization
    void Start()
    {
        spells = transform.GetComponent<SpellHandler>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();
        anim.SetInteger("animation", 1);
        forward = "Horizontal";
        rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        mode = 1;
        num = 0;
        canTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (once) { once = false; Destroy(spire.gameObject); }

        if (Input.GetAxis(forward) > 0 && canTurn && left && currentState != states.waitDelay) { left = false; right = true; transform.localRotation *= Quaternion.Euler(0, 180, 0); }
        else if (Input.GetAxis(forward) < 0 && canTurn && right && currentState != states.waitDelay) { right = false; left = true; transform.localRotation *= Quaternion.Euler(0, 180, 0); }

        if (Input.GetButtonDown("ChangeMode") && !swapping) { StartCoroutine("SwapMode"); }

        if (!attacking) { if (Input.GetButton("Lbutton")) { healing = true; this.GetComponent<Health>().giveHealth(healSpeed); } else { healing = false; } }

        if (grounded && currentState != states.waitDelay)
        {
            //WATER MODE
            if (mode == 1)
            {
                if (!(attacking) && Input.GetButtonDown("X")) { attacking = true; currentState = states.attack; attackNum = 1; }
                if (!ability2 && !(attacking) && !nope && Input.GetButtonDown("B")) { hault = true; attacking = true; currentState = states.attack; attackNum = 2; }
                if (!ability3 && !(attacking) && Input.GetButtonDown("A")) { attacking = true; currentState = states.attack; attackNum = 3; }
                if (!ability4 && !(attacking) && Input.GetButtonDown("Y")) { attacking = true; currentState = states.attack; attackNum = 4; }
            }
            //FIRE MODE
            else if (mode == 2)
            {
                if (!(attacking) && Input.GetButtonDown("X")) { attacking = true; currentState = states.attack; attackNum = 5; }
                if (!ability2 && !(attacking) && Input.GetButtonDown("B")) { hault = true; attacking = true; currentState = states.attack; attackNum = 6; }
                if (!ability3 && !(attacking) && Input.GetButtonDown("A")) { attacking = true; currentState = states.attack; attackNum = 7;  }
                if (!ability4 && !(attacking) && Input.GetButtonDown("Y")) { attacking = true; currentState = states.attack; attackNum = 8; }
            }
            else if (mode == 3)
            {
                if (!(attacking) && Input.GetButtonDown("X")) { attacking = true; currentState = states.attack; attackNum = 9; }
                if (!ability2 && !(attacking) && Input.GetButtonDown("B")) { hault = true; attacking = true; currentState = states.attack; attackNum = 10; }
                if (!ability3 && !(attacking) && Input.GetButtonDown("A")) { attacking = true; currentState = states.attack; attackNum = 11; }
                if (!ability4 && !(attacking) && Input.GetButtonDown("Y")) { attacking = true; currentState = states.attack; attackNum = 12; }
            }
            else if (mode == 4)
            {
                if (!(attacking) && Input.GetButtonDown("X")) { attacking = true; currentState = states.attack; attackNum = 13; }
                if (!ability2 && !(attacking) && Input.GetButtonDown("B")) { hault = true; attacking = true; currentState = states.attack; attackNum = 14; }
                if (!ability3 && !(attacking) && Input.GetButtonDown("A")) { attacking = true; currentState = states.attack; attackNum = 15; }
                if (!ability4 && !(attacking) && Input.GetButtonDown("Y")) { attacking = true; currentState = states.attack; attackNum = 16; }
            }





            if (anim.GetInteger("animation") == 2 && (Input.GetAxis(forward) > 0)) { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
            if (anim.GetInteger("animation") == 2 && (Input.GetAxis(forward) < 0)) { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        }

        if (!grounded)
        {
            if (Input.GetAxis(forward) > .5f) { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
            if (Input.GetAxis(forward) < -.5f) { transform.Translate(Vector3.forward * speed * Time.deltaTime); }
        }

        switch (currentState)
        {
            case states.idle:

                grounded = true;
                check = false;
                if (healing)
                {
                    anim.SetInteger("animation", 90);

                    if (GameObject.Find("HealingEffect(Clone)") == null)
                    {
                        Instantiate(healingEffect, this.transform);
                    }
                }
                else
                {
                    anim.SetInteger("animation", 1);
                    Destroy(GameObject.Find("HealingEffect(Clone)"));
                }

                if (!(attacking) && Input.GetButtonDown("X")) { currentState = states.attack; attackNum = 1; }
                if (Input.GetAxis(forward) > 0 || Input.GetAxis(forward) < 0) { currentState = states.walk; }
                break;

            case states.walk:
                check = false;
                if (!attacking)
                {
                    if (healing)
                    {
                        anim.SetInteger("animation", 90);

                        if (GameObject.Find("HealingEffect(Clone)") == null)
                        {
                            Instantiate(healingEffect, this.transform);
                        }

                    }
                    else
                    {
                        anim.SetInteger("animation", 2);
                        Destroy(GameObject.Find("HealingEffect(Clone)"));
                    }
                }
                if (Input.GetAxis(forward) == 0) { currentState = states.idle; }
                break;
            case states.jump:
                anim.SetInteger("animation", 4);
                if (jumped) { rb.AddForce(Vector3.up * 2000, ForceMode.Acceleration); jumped = false; }
                break;
            case states.fall:
                RaycastHit hit;
                if (Physics.Raycast(transform.Find("JumpCast").transform.position, transform.Find("JumpCast").transform.forward, out hit, 100))
                {
                    if (hit.distance < .7f) { currentState = states.land; } else { grounded = false; }
                }
                if (Physics.Raycast(transform.Find("JumpCastTwo").transform.position, transform.Find("JumpCastTwo").transform.forward, out hit, 100))
                {
                    if (hit.distance < .7f) { currentState = states.land; } else { grounded = false; }
                }
                break;
            case states.land:
                anim.SetInteger("animation", 69);
                break;
            case states.attack:
                switch (attackNum)
                {
                    case 1:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aqua1;
                            startTime = spells.aqua1.GetComponent<Spell>().startTime;
                            waitTime = spells.aqua1.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        if (check)
                        {
                            if (Input.GetButtonDown("X"))
                            {
                                restart = true;
                                check = false;
                                if (currentSpell == spells.aqua1) { currentSpell = spells.aqua11; }
                                else if (currentSpell == spells.aqua11) { currentSpell = spells.aqua1; }
                                if (anim.GetInteger("animation") == 54) { anim.SetInteger("animation", 55); }
                                else if (anim.GetInteger("animation") == 55) { anim.SetInteger("animation", 54); }
                            }
                        }
                        break;

                    case 2:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aqua2;
                            startTime = spells.aqua2.GetComponent<Spell>().startTime;
                            waitTime = spells.aqua2.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 3:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aqua3;
                            startTime = spells.aqua3.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 4:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aqua4;
                            startTime = spells.aqua4.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 5:
                        if (!wait)
                        {

                            wait = true;
                            currentSpell = spells.igni1;
                            startTime = spells.igni1.GetComponent<Spell>().startTime;
                            waitTime = spells.igni1.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        if (check)
                        {
                            if (Input.GetButtonDown("X"))
                            {
                                restart = true;
                                check = false;
                                if (currentSpell == spells.igni1) { currentSpell = spells.igni11; }
                                else if (currentSpell == spells.igni11) { currentSpell = spells.igni1; }
                                if (anim.GetInteger("animation") == 54) { anim.SetInteger("animation", 55); }
                                else if (anim.GetInteger("animation") == 55) { anim.SetInteger("animation", 54); }
                            }
                        }
                        break;

                    case 6:

                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.igni2;
                            startTime = spells.igni2.GetComponent<Spell>().startTime;
                            waitTime = spells.igni2.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 7:

                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.igni3;
                            startTime = spells.igni3.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 8:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.igni4;
                            startTime = spells.igni4.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 9:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.lux1;
                            startTime = spells.lux1.GetComponent<Spell>().startTime;
                            waitTime = spells.lux1.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        if (check)
                        {
                            if (Input.GetButtonDown("X"))
                            {
                                restart = true;
                                check = false;
                                if (currentSpell == spells.lux1) { currentSpell = spells.lux11; }
                                else if (currentSpell == spells.lux11) { currentSpell = spells.lux1; }
                                if (anim.GetInteger("animation") == 54) { anim.SetInteger("animation", 55); }
                                else if (anim.GetInteger("animation") == 55) { anim.SetInteger("animation", 54); }
                            }
                        }
                        break;

                    case 10:

                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.lux2;
                            startTime = spells.lux2.GetComponent<Spell>().startTime;
                            waitTime = spells.lux2.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 11:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.lux3;
                            startTime = spells.lux3.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 12:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.lux4;
                            startTime = spells.lux4.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 13:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aero1;
                            startTime = spells.aero1.GetComponent<Spell>().startTime;
                            waitTime = spells.aero1.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        if (check)
                        {
                            if (Input.GetButtonDown("X"))
                            {
                                restart = true;
                                check = false;
                                if (currentSpell == spells.aero1) { currentSpell = spells.aero11; }
                                else if (currentSpell == spells.aero11) { currentSpell = spells.aero1; }
                                if (anim.GetInteger("animation") == 54) { anim.SetInteger("animation", 55); }
                                else if (anim.GetInteger("animation") == 55) { anim.SetInteger("animation", 54); }
                            }
                        }
                        break;

                    case 14:

                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aero2;
                            startTime = spells.aero2.GetComponent<Spell>().startTime;
                            waitTime = spells.aero2.GetComponent<Spell>().waitTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 15:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aero3;
                            startTime = spells.aero3.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                    case 16:
                        if (!wait)
                        {
                            wait = true;
                            currentSpell = spells.aero4;
                            startTime = spells.aero4.GetComponent<Spell>().startTime;
                            anim.SetInteger("animation", currentSpell.GetComponent<Spell>().animNum);
                        }
                        break;

                }
                break;
            case states.waitDelay:
                anim.SetInteger("animation", 2);
                transform.Translate(Vector3.forward * 50 * Time.deltaTime);
                Camera.main.GetComponent<MainCamera>().TurnCam();
                break;


        }

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumped = true; grounded = false; currentState = states.jump;
        }

    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(startTime);
        string loc = currentSpell.GetComponent<Spell>().spawnLoc;
        Vector3 rota = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
        Vector3 rota2 = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        try
        {
            if (!nope)
            {
                switch (loc)
                {

                    case "leftHand":
                        Instantiate(currentSpell, leftHand.transform.position, Quaternion.Euler(rota));
                        break;
                    case "rightHand":
                        Instantiate(currentSpell, rightHand.transform.position, Quaternion.Euler(rota));
                        break;
                    case "leftFoot":
                        Instantiate(currentSpell, leftFoot.transform.position, Quaternion.Euler(rota));
                        break;
                    case "rightFoot":
                        Instantiate(currentSpell, rightFoot.transform.position, Quaternion.Euler(rota2));
                        break;
                    case "other":
                        Instantiate(currentSpell, transform.Find("SpawnLocs").transform.Find(currentSpell.GetComponent<Spell>().spawnName).transform.position, Quaternion.Euler(rota));
                        break;
                    case "wall":
                        Instantiate(currentSpell, wall.transform.position, Quaternion.Euler(rota));
                        break;
                    default:
                        Debug.Log("None Specified");
                        break;
                }
            }

        }
        catch
        {

        }

        yield return new WaitForSeconds(waitTime);
    }

    private IEnumerator SwapMode()
    {
        swapping = true;
        mode++;
        if (mode == 5) { mode = 1; }
        yield return new WaitForSeconds(0.21f);
        swapping = false;
    }

    private void StartFall()
    {
        if (currentState != states.waitDelay) { anim.SetInteger("animation", 5); currentState = states.fall; }
        else { anim.SetInteger("animation", 2); }
    }

    private void ChangeRotation()
    {
        if (Camera.main.GetComponent<MainCamera>().right)
        {
            rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        }
        else { rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z); }

        transform.rotation = Quaternion.Euler(rot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Stop") {
            rb.isKinematic = true; rb.isKinematic = false; try {
                this.transform.Find("blueBody").GetComponent<SkinnedMeshRenderer>().enabled = false;
                this.transform.Find("redBody").GetComponent<SkinnedMeshRenderer>().enabled = false;
                this.transform.Find("yellowBody").GetComponent<SkinnedMeshRenderer>().enabled = false;
                this.transform.Find("greenBody").GetComponent<SkinnedMeshRenderer>().enabled = false;
                player.GetComponent<BoxCollider>().enabled = true;
            } catch { }
        }
        if (other.transform.tag == "Portal")
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
            hault = true;
            currentState = states.waitDelay;
        }
        if (other.transform.tag == "Rotate") { ChangeRotation(); }

        if (other.transform.tag == "FixX")
        {
            string name = other.transform.name;
            switch (name)
            {
                case "B1":
                    transform.position = new Vector3(475, transform.position.y, transform.position.z);
                    break;
                case "B2":
                    transform.position = new Vector3(475, transform.position.y, transform.position.z);
                    break;
                case "D1":
                    transform.position = new Vector3(25, transform.position.y, transform.position.z);
                    break;
                case "D2":
                    transform.position = new Vector3(25, transform.position.y, transform.position.z);
                    break;
            }
        }
        if (other.transform.tag == "FixZ")
        {

            string name = other.transform.name;
            switch (name)
            {
                case "A1":
                    transform.position = new Vector3(transform.position.x, transform.position.y, 25);
                    break;
                case "A2":
                    transform.position = new Vector3(transform.position.x, transform.position.y, 25);
                    break;
                case "C1":
                    transform.position = new Vector3(transform.position.x, transform.position.y, 475);
                    break;
                case "C2":
                    transform.position = new Vector3(transform.position.x, transform.position.y, 475);
                    break;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Stop")
        {
            nope = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Stop")
        {
            nope = false;
        }
    }

    public void ExitPortal()
    {
        currentState = states.idle;
        this.GetComponent<BoxCollider>().isTrigger = false;
        hault = false;
    }

    public void ComboCheck()
    {
        check = true;
    }

    public void resPos()
    {
        canTurn = true;
        restart = false;
        rb.isKinematic = false;
        this.GetComponent<BoxCollider>().isTrigger = false;
        if (Input.GetAxis(forward) != 0)
        {
            attacking = false; wait = false;
            currentState = states.walk;
        }
        else { attacking = false; wait = false; currentState = states.idle; }
        
    }

    private IEnumerator WaitLonger()
    {
        yield return new WaitForSeconds(.3f);
        hault = false;
    }

    private IEnumerator outOfUlt()
    {
        yield return new WaitForSeconds(1f);
        this.GetComponent<Health>().invinc = false;
    }

    public void reAppear()
    {
        rb.isKinematic = true;
        for (int i = 0; i < this.GetComponent<HoldCloths>().clothes.Count; i++)
        {
            this.GetComponent<HoldCloths>().clothes[i].GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
    }

    public IEnumerator canDamage()
    {
        hit = true;
        yield return new WaitForSeconds(.3f);
        hit = false;
    }

    private void scaleTime()
    {
        canTurn = false;
        Time.timeScale = 0.2f;
        anim.speed = anim.speed / .2f;
    }
}