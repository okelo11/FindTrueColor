using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Boxes : MonoBehaviour
{
    public Material _green;
    public Material _yellow;
    public Material _black;
    public Material _white;
    public Material _purple;
    public Material _red;
    public Material _blue;
    public GameObject box;
    public List<Material> colors = new List<Material>();
    public TextMeshProUGUI textColor;
    GameObject box1, box2, box3;
    float timer=0;
    int firstBox, secondBox, thirdBox;
    
    public List<string> colorsName = new List<string>();
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateBox", 0, 4);
        InvokeRepeating("SelectColorForGame", 0, 4);

       

    }


    void InstantiateBox()
    {
        firstBox = Random.Range(0, 6);
        box1 = Instantiate(box, new Vector3(-5, 0, -10), Quaternion.identity);
        box1.GetComponent<Renderer>().material = colors[firstBox];
        secondBox = Random.Range(0, 6);
        while (secondBox == firstBox)
        {
            secondBox = Random.Range(0, 6);
            
        }
        box2 = Instantiate(box, new Vector3(0, 0, -10), Quaternion.identity);
        box2.GetComponent<Renderer>().material = colors[secondBox];

        thirdBox = Random.Range(0, 6);
        while(thirdBox==firstBox || thirdBox == secondBox)
        {
            thirdBox = Random.Range(0,6);
        }
        box3 = Instantiate(box, new Vector3(5, 0, -10), Quaternion.identity);
        box3.GetComponent<Renderer>().material = colors[thirdBox];

    }
    private void Update()
    {

       
        if (timer <= 1f)
        {
            textColor.color = new Color(textColor.color.r, textColor.color.g, textColor.color.b, Mathf.Lerp(0, 1, timer));
         
            timer += Time.deltaTime * 0.5f;

        }

    }
    void SelectColorForGame()
    {
        timer = 0;
       int select= Random.Range(1, 3);
        switch (select)
        {
            case 1:
                textColor.text = colorsName[firstBox];               
                box1.GetComponent<BoxSpecifications>()._amICorrect=true;
                break;
            case 2:
                textColor.text = colorsName[secondBox];
                box2.GetComponent<BoxSpecifications>()._amICorrect = true;
                break;
            case 3:
                textColor.text = colorsName[thirdBox];
                box3.GetComponent<BoxSpecifications>()._amICorrect = true;
                break;
            default:
                break;
        }

        
    }
    void GameLogic(int trueColorNumber)
    {
        
    }
}
