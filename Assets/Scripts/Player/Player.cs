using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class Player : MonoBehaviour {

    [Header("Requirements")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SkinManager manager;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Ladder ladder;
    [SerializeField] private GameObject spawn;
    [SerializeField] private Camera camera;
    [SerializeField] private PhotonView view;
    [SerializeField] private TMP_Text text;
    [Header("UI")]
    [SerializeField] private GameObject PauseUI;
    [SerializeField] private GameObject FinishUI;
    [SerializeField] private GameObject LadderGrid;
    [Header("Sounds")]
    [SerializeField] private AudioSource jumpEffect;
    [SerializeField] private AudioSource dieEffect;
    [SerializeField] private AudioSource die2Effect;
    [SerializeField] private AudioSource finishEffect;
    //private GameObject Chekpoint;

    [Header("Variables")]
    [Range(5f, 20f)]
    [SerializeField] private float moveSpeed;
    [Range(5f, 20f)]
    [SerializeField] private float jumpForce;
    [Range(0f, 25f)]
    [SerializeField] private float kbPower;
    [SerializeField] private bool isMultiplayer;
    [SerializeField] private int DieCount;
    [Space]
    [SerializeField] private string dieTag;
    [SerializeField] private string groundTag;
    [SerializeField] private string finishTag;
    [SerializeField] private string ladderTag;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isRespawn;
    [SerializeField] private bool showHud = true;
    [SerializeField] private float dir;
    [HideInInspector]
    public static bool isFinish = false;
    public static bool inPause = false;

    void Start()
    {
        spawn = GameObject.Find("Spawn");

        //Add Comps
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        sprite.sprite = manager.getSelectedSkin().sprite;

        if (!isMultiplayer)
        {
            camera = GameObject.Find("Main Camera").GetComponent<Camera>();
            PauseUI = GameObject.Find("Canvas/PauseUI");
            FinishUI = GameObject.Find("Canvas/EndText");
            PauseUI.SetActive(false);
            FinishUI.SetActive(false);
            DiscordPresence.PresenceManager.UpdatePresence("Little Rage v0.1.7a", "Playing in Solo", 0, 0, "basicicon", "Playing Little Rage", null, null, null, 0, 0, null, null, null);
        }
        else if (isMultiplayer)
        {
            camera = GameObject.Find(gameObject.name + "/Camera").GetComponent<Camera>();
            PauseUI = GameObject.Find(gameObject.name + "/Canvas/PauseUI");
            view = GetComponent<PhotonView>();
            text = GameObject.Find("Canvas/Text (TMP)").GetComponent<TMP_Text>();
            PauseUI.SetActive(false);
            view.RPC("SendNickname", RpcTarget.AllViaServer, PlayerPrefs.GetString("Nickname"));
            DiscordPresence.PresenceManager.UpdatePresence("Little Rage v0.1.7a", "Playing in Multiplayer", 0, 0, "basicicon", "Playing Little Rage in Multiplayer", null, null, null, 0, 0, null, null, null);
        }
        LadderGrid = GameObject.Find("Grid/Ladder");
        ladder = LadderGrid.gameObject.GetComponent<Ladder>();
        transform.localPosition = new Vector2(spawn.transform.position.x, spawn.transform.position.y);
        //camera.backgroundColor = new Color(49, 77, 121, 0);
    }

    void Update()
    {
        //Respawn sys
        if (isRespawn)
        {
            DieCount++;
            transform.localPosition = new Vector2(spawn.transform.position.x, spawn.transform.position.y);
            isRespawn = false;
        }

        if(transform.localPosition.y < -15f)
        {
            die2Effect.Play();
            isRespawn = true;
        }

        MenuManager();

        //Movement Check
        if (!isFinish)
        {
            if (!inPause)
            {
                PlayerMovement();
            }
        }

        //Finish sys
        if (isFinish) {
            FinishUI.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == groundTag || collision.gameObject.tag == "Player")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == dieTag)
        {
            dieEffect.Play();
            isRespawn = true;
        }
        else if (collision.gameObject.tag == finishTag)
        {
            if (!isMultiplayer)
            {
                finishEffect.Play();
                isFinish = true;
            }else if (isMultiplayer)
            {
                finishEffect.Play();
                PhotonNetwork.LoadLevel("Game1");
            }
        }
        else
        {
            isGrounded = false;
        }   
    }

    private void PlayerMovement()
    {
        dir = Input.GetAxis("Horizontal");

        if (dir < 0)
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            sprite.flipX = true;
        }
        else if (dir > 0)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            sprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                isGrounded = false;
                jumpEffect.Play();
            }

        }
    }

    private void MenuManager()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && ladder.isPlayer)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!inPause)
            {
                PauseUI.SetActive(true);
                inPause = true;
            }
            else if (inPause)
            {
                PauseUI.SetActive(false);
                inPause = false;
            }
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            StartCoroutine(captureScreen(Screen.width, Screen.height));
        }else if (Input.GetKeyDown(KeyCode.F1))
        {
            showHud = !showHud;
        }
    }

    WaitForSeconds waitTime = new WaitForSeconds(0.1F);
    WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
    private IEnumerator captureScreen(int width, int height)
    {

        string dir = Application.persistentDataPath + "/Screenshots";


        if (!Directory.Exists(dir))
        {
            var folder = Directory.CreateDirectory(dir);
        }

        yield return waitTime;
        yield return frameEnd;

        camera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        RenderTexture renderTexture = camera.targetTexture;

        Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        renderResult.ReadPixels(rect, 0, 0);

        byte[] byteArray = renderResult.EncodeToPNG();
        File.WriteAllBytes(dir + "/" + System.DateTime.Now.ToString("yyyy_MM_dd HH mm ss") + ".png", byteArray);
        Debug.Log("Saved Screenshot in " + dir);
        camera.targetTexture = null;
    }

    [PunRPC]
    public void SendNickname(string nickname)
    {
        text.text = nickname;
    }

    public int getDieCount
    {
        get{return DieCount;}
        set{DieCount = value;}
    }

    public bool getShowHud
    {
        get { return showHud; }
    }
}
