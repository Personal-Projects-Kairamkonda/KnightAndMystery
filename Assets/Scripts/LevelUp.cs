using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public float speed;
    public Vector2 target;
    public const float height=30f;

    private void Start()
    {
        target = new Vector2(transform.position.x, transform.position.y+height);
    }

    private void Update()
    {
        MoveUp();
    }

    void MoveUp()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}
