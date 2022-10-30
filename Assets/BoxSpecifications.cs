using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxSpecifications : MonoBehaviour
{   
    PlPoint _plPoint;
    public BackGroundsc backGroundSc;
    public bool _amICorrect= false;
    public float speed;
    public GameObject _particleWhenDestroy;
    public GameObject point;
    //public Image gold_ui;
    
    void Start()
    {
        
       _plPoint= FindObjectOfType<PlPoint>();
        backGroundSc = FindObjectOfType<BackGroundsc>();
        backGroundSc._hitOnce = true;
        Destroy(gameObject, 6);
    }

    void Update()
    {
        speed += Time.deltaTime;
        if (speed >= 5f)
        {
            speed = 5f;
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
    
    private void OnMouseDown()
    {
        if (_amICorrect)
        {
            _plPoint.point += 1;
            _plPoint.getGold = true;
            
            Instantiate(point, transform.position, Quaternion.identity);
            DestroyBoxes();
        }
        else
        {
            _plPoint.hP -= 1;
            _plPoint.PlayerHpDown();
            DestroyBoxes();
            
        }
    }
    void DestroyBoxes()
    {
        BoxSpecifications[] boxes = FindObjectsOfType<BoxSpecifications>();
        foreach (var item in boxes)
        {
            Instantiate(_particleWhenDestroy, item.transform.position, Quaternion.identity);
            
            Destroy(item.gameObject);    
        }
    }
}
