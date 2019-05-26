using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreen : MonoBehaviour {

    public enum ResultStatus
    {
        blankScreen,
        processing,
        tooMuchHealth,
        clear
    }


    [SerializeField]
    public Sprite[] sprites = new Sprite[4];

    public SpriteRenderer spriteRenderer;


    public void SetSprite(int spriteIndex)
    {
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }







}
