using UnityEngine;

public class ChangePlayerColors : MonoBehaviour
{
    public SpriteRenderer head;
    public SpriteRenderer tail;
    public SpriteRenderer body;
    public SpriteRenderer left_arm;
    public SpriteRenderer right_arm;

    public void ChangePrimaryColor(Color color)
    {
        head.color = color;
        left_arm.color = color;
        right_arm.color = color;
    }
    public void ChangeSecondaryColor(Color color)
    {
        tail.color = color;
        body.color = color;
    }
}
