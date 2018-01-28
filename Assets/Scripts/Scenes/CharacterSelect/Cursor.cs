using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour {

    [SerializeField]
    float velocity;

    SpriteRenderer _sprRen;
    string _vertical;
    string _horizontal;
    string _jump;
    int _playerNumber;
    void Start () {

    }
	
	void Update () {
        if (Input.GetButtonDown(_jump))
        {
            RaycastHit2D hit;
            hit=Physics2D.Raycast(transform.position, Vector3.forward, 100);
        }

        float ver = Input.GetAxisRaw(_vertical);
        float hor = Input.GetAxisRaw(_horizontal);
        Vector3 deltaV = new Vector3(ver, hor, 0)*velocity*Time.deltaTime;
        transform.Translate(deltaV);

    }

    public void SetData(int playerNumber)
    {
        _playerNumber = playerNumber;
        _vertical = "Pad" + playerNumber + "Vertical";
        _horizontal = "Pad" + playerNumber + "Horizontal";
        _jump = "Pad" + playerNumber + "Jump";
        _sprRen = GetComponent<SpriteRenderer>();

        switch (playerNumber)
        {
            case 0:
                _sprRen.color = Color.red;
                _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                break;
            case 1:
                _sprRen.color = Color.blue;
                _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                break;
            case 2:
                _sprRen.color = Color.yellow;
                _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                break;
            case 3:
                _sprRen.color = Color.green;
                _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                break;
        }
    }
}
