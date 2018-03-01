using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageArea: MonoBehaviour {

    public Slider _slider = null;
    float _hp = 1.0f;
    bool _isOutOfArena = false;

    // Use this for initialization
    void Start()
    {
        _slider = GameObject.Find("player1HP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {


        if (_isOutOfArena)
        {
            _hp -= 0.01f;
            if (_hp < 0)
            {
                _hp = 0;
            }
        }
        _slider.value = _hp;
    }

    void OnTriggerEnter(Collider col)
    {
        _isOutOfArena = false;
        Debug.Log("Enter");
    }

    void OnTriggerStay(Collider col)
    {
        _isOutOfArena = false;
        Debug.Log("Stay!");
    }

    void OnTriggerExit(Collider col)
    {
        _isOutOfArena = true;
        Debug.Log("Exit");
    }
}
