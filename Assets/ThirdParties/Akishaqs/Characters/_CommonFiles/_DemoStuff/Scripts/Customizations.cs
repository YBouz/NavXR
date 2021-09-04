using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class BodyPart{
    public string bodyName="";
    public GameObject[] bodyParts;
    public Button nextBodyPart;
    public Button previosBodyPart;
    public Text bodyNameDisplay;
    public int currentIndex=0;
    public bool visibleInSuit=false;
}
[System.Serializable]
public class BodySuit{
    public string suitName="";
    public GameObject suitParts;
}
public class Customizations : MonoBehaviour
{
    public List<BodyPart> allParts=new List<BodyPart>();

    [Header("Suits Part")]
    public List<BodySuit> allSuits=new List<BodySuit>();
    public Button nextSuit;
    public Button previosSuit;
    private int suitIndex=0;
    public Text suitText;

    void Start(){
        foreach(BodyPart b in allParts){
            foreach(GameObject g in b.bodyParts){
                g.SetActive(false);
            }
            b.bodyParts[b.currentIndex].SetActive(true);
            b.nextBodyPart.onClick.AddListener(()=>{ChangePart(b,true);});
            b.previosBodyPart.onClick.AddListener(()=>{ChangePart(b,false);});
            b.bodyNameDisplay.text=b.bodyParts[b.currentIndex].gameObject.name;
        }
        if (allSuits.Count <1)
        {
            return;
        }
        foreach(BodySuit suit in allSuits){
            if(suit.suitParts)
                suit.suitParts.SetActive(false);
        }
        nextSuit.onClick.AddListener(()=>{ChangeSuit(true);});
        previosSuit.onClick.AddListener(()=>{ChangeSuit(false);});
        suitText.text=allSuits[suitIndex].suitName;
    }
    void NonSuitParts(bool visibility){
        foreach(BodyPart b in allParts){
            if(b.visibleInSuit)
                continue;
            b.bodyParts[b.currentIndex].SetActive(visibility);
            b.nextBodyPart.interactable=visibility;
            b.previosBodyPart.interactable=visibility;
        }
    }
    void ChangeSuit(bool increase){
        if(suitIndex>0)
            allSuits[suitIndex].suitParts.SetActive(false);
        suitIndex+=increase?1:-1;
        if(suitIndex>allSuits.Count-1)
            suitIndex=0;
        if(suitIndex<0)
            suitIndex=allSuits.Count-1;
        if(suitIndex==0)
            NonSuitParts(true);
        else if(suitIndex==1)
            NonSuitParts(false);
        if(suitIndex>0)
            allSuits[suitIndex].suitParts.SetActive(true);
        suitText.text=allSuits[suitIndex].suitName;
    }
    void ChangePart(BodyPart b, bool increase)
    {
        b.bodyParts[b.currentIndex].SetActive(false);
        b.currentIndex += increase ? 1 : -1;
        if (b.currentIndex > b.bodyParts.Length - 1)
            b.currentIndex = 0;
        if (b.currentIndex < 0)
            b.currentIndex = b.bodyParts.Length - 1;
        b.bodyParts[b.currentIndex].SetActive(true);
        b.bodyNameDisplay.text = b.bodyParts[b.currentIndex].gameObject.name;
    }
}
