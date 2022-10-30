using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlPoint : MonoBehaviour
{
    public int point=0;
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI totalText;
    public int hP = 3;
    public Animator goldanim;
    public AnimationClip animClip;
    public bool getGold;
    float timer;
    public GameObject heartPanel;
    public GameObject restartPanel;
    public float interval = 1f;
    public GameObject cameraMain;
    Vector3 cameraOriginalPos;
    float timerr = 0;
    bool _cameraShake = false;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void Start()
    {
        cameraOriginalPos = cameraMain.transform.position;
    }
    private void Update()
    {
        Debug.Log(timerr);
        if (_cameraShake)
        {
            CameraShake();
        }
        PlayerDead();

        pointText.text ="POINT :"+ point.ToString();
        totalText.text = "Total Score \n" + point.ToString();
        if (getGold)
        {
            timer += Time.deltaTime;
            goldanim.SetBool("getPoint", true);

            if (timer >= animClip.length) 
            {
                goldanim.SetBool("getPoint", false);
                getGold = false;
                timer = 0;
            }
        }
       
    }
   public void PlayerHpDown()
    {
        _cameraShake = true;
        Destroy(heartPanel.transform.GetChild(0).gameObject);               
    }
    public void PlayerDead()
    {
        if (heartPanel.transform.childCount == 0)
        {
            
            restartPanel.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
    void CameraShake()
    {
        if (timerr<=0.3f) 
        {
            Debug.Log(timerr);
            float x = Random.Range(-0.8f, 0.8f);
            float y = Random.Range(-0.8f, 0.8f);
            cameraMain.transform.position = new Vector3(x+cameraOriginalPos.x, y+cameraOriginalPos.y, cameraOriginalPos.z);
            timerr = timerr + Time.deltaTime;
        }
        else
        {
            cameraMain.transform.position = cameraOriginalPos;
            timerr = 0;
            _cameraShake = false;
        }
        
    }
}
