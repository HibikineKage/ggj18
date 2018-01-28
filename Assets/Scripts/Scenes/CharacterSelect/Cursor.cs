using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ggj2018
{
    public class Cursor : MonoBehaviour
    {
        public bool IsTypeSelected;

        [SerializeField]
        float velocity;

        SpriteRenderer _sprRen;
        TextMesh _textMesh;
        string _vertical;
        string _horizontal;
        string _jump;
        int _playerNumber;

        void Update()
        {
            float ver = -Input.GetAxisRaw(_vertical);
            float hor = Input.GetAxisRaw(_horizontal);
            Vector3 deltaV = new Vector3(hor, ver, 0) * velocity * Time.deltaTime;
            transform.Translate(deltaV);

            if (Input.GetButtonDown(_jump))
            {
                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position, Vector3.forward, 100);
                if (hit.collider)
                {
                    var type = hit.collider.GetComponent<CharacterSelectButtons>().animalType;
                    ScenesDataManager.Instance.GetPlayer(_playerNumber).SetAnimalType(type);
                    IsTypeSelected = true;


                    _textMesh.text = "P" + _playerNumber + type.ToString();
                }
            }
        }

        public void SetData(int playerNumber)
        {
            _playerNumber = playerNumber;
            _vertical = "Pad" + playerNumber + "Vertical";
            _horizontal = "Pad" + playerNumber + "Horizontal";
            _jump = "Pad" + playerNumber + "Jump";
            _sprRen = GetComponent<SpriteRenderer>();
            _textMesh = GetComponentInChildren<TextMesh>();

            _textMesh.text += playerNumber;
            switch (playerNumber)
            {
                case 0:
                    _sprRen.color = Color.red;
                    _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                    _textMesh.color = _sprRen.color;
                    break;
                case 1:
                    _sprRen.color = Color.blue;
                    _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                    _textMesh.color = _sprRen.color;
                    break;
                case 2:
                    _sprRen.color = Color.yellow;
                    _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                    _textMesh.color = _sprRen.color;
                    break;
                case 3:
                    _sprRen.color = Color.green;
                    _sprRen.color = new Color(_sprRen.color.r, _sprRen.color.g, _sprRen.color.b, 0.3f);
                    _textMesh.color = _sprRen.color;
                    break;
            }
        }
    }
}