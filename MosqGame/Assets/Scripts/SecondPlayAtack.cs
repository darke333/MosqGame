
using UnityEngine;

public class SecondPlayAtack : MonoBehaviour {

    public Animator anim;
    public GameObject Moving;
    public GameObject BiteArea;
    public GameObject Bullet;
    public GameObject Green;
    public GameObject RGreen;
    public GameObject LGreen;
    public GameObject BRGreen;
    public GameObject BLGreen;
    GameObject player;
    GameObject bull;
    Transform UI;
    GameObject CreatedGreen;
    GameObject CreatedGreen2;
    bool stop;
    bool PlayAnim;
    bool Playing;
    float TimeCount;
    bool IsShoting;
    float ShootTime;
    bool Shoted;
    float SwapTime;
    public float reloadtime;
    public int ShootCount;
    bool StartMoving;
    bool hurted;
    public GameObject marker;



    // Use this for initialization
    void Start()
    {
        UI = GameObject.Find("BlotCanvas").transform;
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        BiteArea = GameObject.Find("BiteArea");
        stop = false;
        Shoted = false;
        Playing = false;
        TimeCount = 4.6f;
        ShootTime = 1.05f;
        reloadtime = 2;
        ShootCount = 1;
        anim.Play("AttackRange");
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop && !StartMoving)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackRange"))
            {

                ShootTime -= Time.deltaTime;
                if (ShootTime <= 0 && !Shoted)
                {
                    bull = Instantiate(Bullet, transform.parent.position, Quaternion.identity, gameObject.transform);
                    Shoted = true;
                }
            }
            if (bull != null)
            {
                bull.transform.position = Vector3.MoveTowards(bull.transform.position, player.transform.position, 2 * Time.deltaTime);
                if (bull.transform.position == player.transform.position)
                {
                    if (Vector3.Angle(Moving.transform.forward, player.transform.forward) >= 130 && Vector3.Angle(Moving.transform.forward, player.transform.forward) <= 180 || Vector3.Angle(Moving.transform.forward, player.transform.forward) >= 0 && Vector3.Angle(Moving.transform.forward, player.transform.forward) <= -30)
                    {
                        CreatedGreen = Instantiate(Green, UI);
                        Destroy(bull);
                        CreatedGreen.SendMessage("StartChangeColor");
                    }
                    else if (Vector3.Angle(Moving.transform.forward, player.transform.forward) < 130 && Vector3.Angle(Moving.transform.forward, player.transform.forward) > 40 && Moving.transform.forward.x > 0)
                    {
                        CreatedGreen = Instantiate(LGreen, UI);
                        Destroy(bull);
                        CreatedGreen.SendMessage("StartChangeColor");
                    }
                    else if (Vector3.Angle(Moving.transform.forward, player.transform.forward) < 130 && Vector3.Angle(Moving.transform.forward, player.transform.forward) > 40 && Moving.transform.forward.x < 0)
                    {
                        CreatedGreen = Instantiate(RGreen, UI);
                        Destroy(bull);
                        CreatedGreen.SendMessage("StartChangeColor");
                    }
                    else
                    {
                        CreatedGreen = Instantiate(BRGreen, UI);
                        CreatedGreen2 = Instantiate(BLGreen, UI);
                        Destroy(bull);
                        CreatedGreen.SendMessage("StartChangeColor");
                        CreatedGreen2.SendMessage("StartChangeColor");
                    }
                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyRange"))
            {
                reloadtime -= Time.deltaTime;
                if (ShootCount != 0)
                {
                    if (reloadtime <= 0)
                    {
                        ShootTime = 1.05f;
                        reloadtime = 2;
                        Shoted = false;
                        ShootCount--;
                        anim.Play("AttackRange");
                    }

                }
                else
                {
                    anim.Play("ConToMelee");                    

                }
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlyMelee"))
            {
                if (marker != null)
                    Destroy(marker);
                StartMoving = true;
                if(gameObject.transform.root.GetComponent<Bezier>() != null)
                gameObject.transform.root.GetComponent<Bezier>().StartMoving = true;
            }
        }
        if (StartMoving)
        {
            if (Moving.tag == "Hurted")
            {
                hurted = true;
            }
            else
            {
                hurted = false;
            }
            if (PlayAnim && !stop)
            {
                anim.Play("AttackMelee");
                PlayAnim = false;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("AttackMelee") && TimeCount > 0)
            {
                TimeCount -= Time.deltaTime;
            }
            if (TimeCount <= 0)
            {
                Moving.tag = "Untagged";
                TimeCount = 1000000;
                var player = GameObject.Find("Player");
                player.SendMessage("TakeDamage", Moving);
                gameObject.transform.Find("Шприц").SendMessage("ChangeColor");
                anim.Play("HardFly");
            }
        }
    }

        public void PlayOKl()
        {
            anim.Play("OhMelee");
        }

        public void StopAn()
        {
            stop = true;
            anim.enabled = false;
        }

        public void ResumeAn()
        {
            stop = false;
            anim.enabled = true;
        }

        public void StartAnimation()
        {
            PlayAnim = true;
        }

        public void EndAnimation()
        {
            PlayAnim = false;
        }
    }
