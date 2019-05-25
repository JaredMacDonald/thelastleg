using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    public enum Animation
    {
        Ready,
        Run,
        Jump,
        Slide,
        HurtNormal,
        HurtFire,
        HurtElectric
    }
    public Animation currentAnimation;
    private Animation previousAnimation;

    private int animationFrameIndex;
    private float animationFrameTime;

    private float animationFPS = 10f;

    public Sprite[] readyFrames;
    public Sprite[] runFrames;
    public Sprite[] jumpFrames;
    public Sprite[] slideFrames;
    public Sprite[] hurtNormalFrames;
    public Sprite[] hurtFireFrames;
    public Sprite[] hurtElectricFrames;
    private Sprite[] currentAnimationFrames;

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
        if (currentAnimation != previousAnimation || currentAnimationFrames == null)
        {
            animationFrameIndex = -1;
            animationFrameTime = 0f;

            switch (currentAnimation)
            {
                case Animation.Ready:
                    currentAnimationFrames = readyFrames;
                    break;

                case Animation.Run:
                    currentAnimationFrames = runFrames;
                    break;

                case Animation.Jump:
                    currentAnimationFrames = jumpFrames;
                    break;

                case Animation.Slide:
                    currentAnimationFrames = slideFrames;
                    break;

                case Animation.HurtNormal:
                    currentAnimationFrames = hurtNormalFrames;
                    break;

                case Animation.HurtFire:
                    currentAnimationFrames = hurtFireFrames;
                    break;

                case Animation.HurtElectric:
                    currentAnimationFrames = hurtElectricFrames;
                    break;
            }

            previousAnimation = currentAnimation;
        }

        if (currentAnimationFrames.Length == 0)
        {
            return;
        }

        float frameTimeMax = 1f / animationFPS;
        animationFrameTime += Time.deltaTime;

        if (animationFrameTime > frameTimeMax || animationFrameIndex == -1)
        {
            animationFrameIndex = (animationFrameIndex + 1) % currentAnimationFrames.Length;
            animationFrameTime = 0f;

            Renderer.sprite = currentAnimationFrames[animationFrameIndex];
        }
    }

    public void SetAnimation(Animation animation)
    {
        currentAnimation = animation;
    }

    public void SetAnimation(Animation animation, float fps)
    {
        currentAnimation = animation;
        animationFPS = fps;
    }

    public void SetAnimationFPS(float fps)
    {
        animationFPS = fps;
    }
}
