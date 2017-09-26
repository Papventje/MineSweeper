using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultElement : MonoBehaviour
{
    public bool mine;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    public Sprite flagTexture;
    public Sprite spriteTexture;

    void Start()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;
        // randomise mines
        mine = UnityEngine.Random.value < 0.15;

    }

    //load textures on click
    public void LoadTexture(int adjacentCount)
    {
        if (mine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }


    public bool Iscovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    
    void OnMouseUpAsButton()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (GetComponent<SpriteRenderer>().sprite == flagTexture)
            {
                GetComponent<SpriteRenderer>().sprite = spriteTexture;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = flagTexture;
            }
        }
        if (!Input.GetKeyDown(KeyCode.LeftShift)){
            if (mine)
            {
                // uncover all mines
                Grid.uncoverMines();
                // game over
                print("you lose");
            }
            else
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                LoadTexture(Grid.adjacentMines(x, y));

                //uncover mineless area
                Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);

                if (Grid.isFinished())
                    print("you win");

            }
        }
    }
        
}