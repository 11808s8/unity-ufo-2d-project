using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;

    public float speed;
    public float winningCount;

    private int count;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    void Start()
    {
        winText.gameObject.SetActive(false);
        winText.text = "";
        rigidbody2d = GetComponent<Rigidbody2D> ();
        count = 0;
        SetCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody2d.AddForce(movement*speed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            WinCondition();
            SetCountText();

        }
    }

    void WinCondition()
    {
        if (count >= winningCount)
        {
            winText.gameObject.SetActive(true);
            winText.text = "You just won the game!";
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
