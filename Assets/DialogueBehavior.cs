using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueBehavior : MonoBehaviour
{
    public EndingInit end;

    public Animator talking;

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


    public void Start()
    {
        talking = gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        if (end.end == true)
        {
            talking.speed = 1;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (spriteRender.sprite == dialogueSprite1)
                {
                    talking.speed = 0;
                    Destroy(hint);
                    spriteRender.sprite = dialogueSprite2;
                }

                else if (spriteRender.sprite == dialogueSprite2)
                {
                    talking.speed = 1;
                    spriteRender.sprite = dialogueSprite3;
                }

                else if (spriteRender.sprite == dialogueSprite3)
                {
                    talking.speed = 0;
                    spriteRender.sprite = dialogueSprite4;
                }

                else if (spriteRender.sprite == dialogueSprite4)
                {
                    talking.speed = 1;
                    spriteRender.sprite = dialogueSprite5;
                }

                else if (spriteRender.sprite == dialogueSprite5)
                {
                    talking.speed = 0;
                    spriteRender.sprite = dialogueSprite6;
                }

                else if (spriteRender.sprite == dialogueSprite6)
                {
                    talking.speed = 1;
                    spriteRender.sprite = dialogueSprite7;
                }

                else if (spriteRender.sprite == dialogueSprite7)
                {
                    talking.speed = 0;
                    spriteRender.sprite = dialogueSprite8;
                }

                else if (spriteRender.sprite == dialogueSprite8)
                {
                    spriteRender.sprite = dialogueSprite9;
                }
            }
        }
    }

}
