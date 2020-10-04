using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jump;
    private Game game;
    private int coins;
    private Vector3 inputVector;
    private GameObject sword;

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private TMPro.TextMeshProUGUI coinText;



    void Start()
    {
        Application.targetFrameRate = 144;
        sword = transform.GetChild(5).gameObject;
        game = FindObjectOfType<Game>();
        playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Attack"))
        {
            PerformAttack();
        }
    }

    private void FixedUpdate()
    {

        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        inputVector = new Vector3(Input.GetAxis("Horizontal")*8.5f, playerBody.velocity.y, Input.GetAxis("Vertical")*8.5f);

        playerBody.velocity = inputVector;

        if (jump && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * 20, ForceMode.Impulse);
            jump = false;
        }

    }

    private void PerformAttack()
    {
        if(!sword.activeSelf)
        {
            sword.SetActive(true);
        }
    }

    bool IsGrounded()
    {
        float distanceFromGround = GetComponent<Collider>().bounds.extents.y+0.01f;
        Ray ray = new Ray(transform.position, Vector3.down);
        return Physics.Raycast(ray,distanceFromGround);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            game.ReloadCurrentLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                coins++;
                Destroy(other.gameObject, 0.05f);
                coinText.text = string.Format("Coins:\n{0}", coins);
                //update the UI
                break;

            case "Goal":
                other.GetComponent<Goal>().CheckForCompletion(coins);
                break;

            default:
                break;
        }
    }

}
