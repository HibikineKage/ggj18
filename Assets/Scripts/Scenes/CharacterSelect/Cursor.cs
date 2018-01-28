using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    SpriteRenderer sprRen;
    string vertical;
    string horizontal;
    void Start () {

    }
	
	void Update () {
        if (Input.GetButtonDown("vertical"))
        {

        }

    }

    public void SetData(int playerNumber)
    {
        vertical = "Pad" + playerNumber + "Vertical";
        horizontal = "Pad" + playerNumber + "Horizontal";
        sprRen = GetComponent<SpriteRenderer>();

        switch (playerNumber)
        {
            case 0:
                sprRen.color = Color.red;
                sprRen.color = new Color(sprRen.color.r, sprRen.color.g, sprRen.color.b, 0.75f);
                break;
            case 1:
                sprRen.color = Color.blue;
                sprRen.color = new Color(sprRen.color.r, sprRen.color.g, sprRen.color.b, 0.75f);
                break;
            case 2:
                sprRen.color = Color.yellow;
                sprRen.color = new Color(sprRen.color.r, sprRen.color.g, sprRen.color.b, 0.75f);
                break;
            case 3:
                sprRen.color = Color.green;
                sprRen.color = new Color(sprRen.color.r, sprRen.color.g, sprRen.color.b, 0.75f);
                break;
        }
    }
}
