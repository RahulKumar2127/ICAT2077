using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable_Objs : MonoBehaviour
{
  
    public GameObject E_Text;
    public GameObject _objs;
    
    public int _coins;
    public TextMeshProUGUI coinsText;
    

    // Start is called before the first frame update
    void Start()
    {
        E_Text.gameObject.SetActive(false);
        _coins = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "Coins: " + _coins;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectable" )
        {
            E_Text.gameObject.SetActive(true);
             
        }

        if (other.gameObject.tag == "Coins")
        {
            _coins += 1;
            Destroy(other.gameObject);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Collectable" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("[E]");
            Destroy(other.gameObject);
            E_Text.gameObject.SetActive(false);
            var obj= Instantiate(_objs, new Vector3(0,0,0), Quaternion.identity);
            obj.transform.parent= GameObject.FindGameObjectWithTag("parentPanel").transform;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            E_Text.gameObject.SetActive(false);
        }
    }
}
