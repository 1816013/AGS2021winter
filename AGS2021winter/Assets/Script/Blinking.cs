using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public float speed = 1.0f;
    private SpriteRenderer image;
    private float time;

    private void Start()
    {
        image = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        image.color = GetAlphaColor(image.color);
    }
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}
