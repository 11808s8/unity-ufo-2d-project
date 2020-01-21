using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody2d;

    public float speed;

    private GameObject pickups;
    private int count;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    void Start()
    {
        pickups = GameObject.Find("Pickups"); // search gameobject by name!
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
        // transform.childCount counts all the children that a transform has!
        if (count >= pickups.transform.childCount)
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
