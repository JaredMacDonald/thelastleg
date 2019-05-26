using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    private int animationFrameIndex;
    private float animationFrameTime;

    private float animationFPS = 10f;

    public Sprite[] Frames;

    private SpriteRenderer _Renderer;
    private SpriteRenderer Renderer
    {
        get
        {
            if (_Renderer == null)
            {
                _Renderer = GetComponent<SpriteRenderer>();
            }
            return _Renderer;
        }
    }

    void Update()
    {
        if (Frames.Length == 0)
        {
            return;
        }

        float frameTimeMax = 1f / animationFPS;
        animationFrameTime += Time.deltaTime;

        if (animationFrameTime > frameTimeMax || animationFrameIndex == -1)
        {
            animationFrameIndex = (animationFrameIndex + 1) % Frames.Length;
            animationFrameTime = 0f;

            Renderer.sprite = Frames[animationFrameIndex];
        }
    }

    public void SetAnimationFPS(float fps)
    {
        animationFPS = fps;
    }
}
