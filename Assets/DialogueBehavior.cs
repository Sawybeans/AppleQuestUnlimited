using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBehavior : MonoBehaviour
{
    public EndingInit end;

    public SpriteRenderer spriteRender;
    public Sprite dialogueSprite1;
    public Sprite dialogueSprite2;
    public Sprite dialogueSprite3;
    public Sprite dialogueSprite4;
    public Sprite dialogueSprite5;
    public Sprite dialogueSprite6;
    public Sprite dialogueSprite7;
    public Sprite dialogueSprite8;
    public Sprite dialogueSprite9;

    public GameObject hint;

    public void Update()
    {
        if (end.end == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (spriteRender.sprite == dialogueSprite1)
                {
                    Destroy(hint);
                    spriteRender.sprite = dialogueSprite2;
                }

                else if (spriteRender.sprite == dialogueSprite2)
                {
                    spriteRender.sprite = dialogueSprite3;
                }

                else if (spriteRender.sprite == dialogueSprite3)
                {
                    spriteRender.sprite = dialogueSprite4;
                }

                else if (spriteRender.sprite == dialogueSprite4)
                {
                    spriteRender.sprite = dialogueSprite5;
                }

                else if (spriteRender.sprite == dialogueSprite5)
                {
                    spriteRender.sprite = dialogueSprite6;
                }

                else if (spriteRender.sprite == dialogueSprite6)
                {
                    spriteRender.sprite = dialogueSprite7;
                }

                else if (spriteRender.sprite == dialogueSprite7)
                {
                    spriteRender.sprite = dialogueSprite8;
                }

                else if (spriteRender.sprite == dialogueSprite8)
                {
                    spriteRender.sprite = dialogueSprite9;
                }

                else if (spriteRender.sprite == dialogueSprite9)
                {
                    SceneManager.LoadScene("Level2", LoadSceneMode.Single);
                }

                //^ Gotta figure out how to make this work for each level, might just end up having it right at the very end of the game, with the last doors of each level just moving you on to the next one.
            }
        }
    }

}
