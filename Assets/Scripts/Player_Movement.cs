using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController2D))]
public class Player_Movement : MonoBehaviour
{
    [SerializeField] public CharacterController2D controller { get; private set; }

    [SerializeField] private float horizontalMove = 0f;

    [SerializeField] private float runSpeed = 140f;

    [SerializeField] private bool jump = false;

    [SerializeField] private bool crouch = false;

    [SerializeField] private bool alive = true;

    public bool Alive
    {
        get
        {
            return alive;
        }
        set
        {
            alive = value;
        }
    }
    
    void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }

    void Awake()
    {
        controller = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(alive)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            } else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
    }


    void FixedUpdate()
    {
        //Move Character
        if(alive)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        }
        horizontalMove = 0;
        jump = false;
    }
}
