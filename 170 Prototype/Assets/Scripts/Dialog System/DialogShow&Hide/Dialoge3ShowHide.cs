using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoge3ShowHide : MonoBehaviour
{
    //search for game object with dialogue
    public DialogNew dialogue;

    //set sprite color
    public Color talkColor = Color.white;
    public Color hideColor = Color.white;

    //sprite render
    SpriteRenderer rend;

    //use to determine if the speaker is Evra or Cat
    public bool Evra = false;
    public bool Cat = false;

    // Start is called before the first frame update
    void Start()
    {
        //basic rending call and search for object with script
        rend = GetComponent<SpriteRenderer>();
        dialogue = GameObject.FindGameObjectWithTag("Untagged").GetComponent<DialogNew>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the target is Evra
        if(Evra == true)
        {
            // change color based on the line
            if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 4 || dialogue.index == 6)
            {
                rend.material.color = talkColor;
            }
            // change it back
            else
            {
                rend.material.color = hideColor;
            }
        }
        // if the target is Cat
        else if(Cat == true)
        {
            // change color based on the line
            if(dialogue.index == 1 || dialogue.index == 3 || dialogue.index == 5)
            {
                rend.material.color = talkColor;
            }
            // change it back
            else
            {
                rend.material.color = hideColor;
            }
        }
    }

}
