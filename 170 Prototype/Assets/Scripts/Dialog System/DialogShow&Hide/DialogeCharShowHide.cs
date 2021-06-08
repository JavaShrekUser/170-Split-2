using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeCharShowHide : MonoBehaviour
{
    //check for which dialogue stage
    public int dialogueNum;
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
        if(dialogueNum == 3)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 4 || dialogue.index == 6)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else// dark color when not talking
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 4)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 5)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 4 || dialogue.index == 6)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 2 || dialogue.index == 3 || dialogue.index == 5 || dialogue.index == 7)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 6)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 7)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 8)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 9)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 10)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 2)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 11)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 12)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 2 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 13)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 14)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 15)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 1)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 16)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 17)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 18)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 2 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 3 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 19)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 4 || dialogue.index == 5)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 20)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 2 || dialogue.index == 4)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 3)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

        if(dialogueNum == 21)
        {
            // if the target is Evra
            if(Evra == true)
            {
                // change color to light when talking
                if(dialogue.index == 1 || dialogue.index == 3 || dialogue.index == 5 || dialogue.index == 7 || dialogue.index == 9 || dialogue.index == 10)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
            // if the target is Cat
            else if(Cat == true)
            {
                // change color to light when talking
                if(dialogue.index == 0 || dialogue.index == 2 || dialogue.index == 4 || dialogue.index == 6 || dialogue.index == 8 || dialogue.index == 11)
                {
                    rend.material.color = talkColor;
                }
                // dark color when not talking
                else
                {
                    rend.material.color = hideColor;
                }
            }
        }

    }

}
