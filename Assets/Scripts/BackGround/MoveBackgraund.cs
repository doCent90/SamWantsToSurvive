using UnityEngine;

public class MoveBackgraund : MonoBehaviour
{
    private Vector2 _offSet = Vector2.zero;
    private Material _material;

    private const float SpeedBackGround = 0.09f;
    private const string Texture = "_MainTex";

    private void Start()
    {
        var hieght = Camera.main.orthographicSize * 2f;
        var wight = hieght * Screen.width / Screen.height;
        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector2(wight, hieght);
        }
        else
        {
            transform.localScale = new Vector2(wight + 3, 5);
        }

        _material = GetComponent<Renderer>().material;
        _offSet = _material.GetTextureOffset(Texture);
    }

    private void FixedUpdate()
    {
        _offSet.y += SpeedBackGround * Time.deltaTime;
        _material.SetTextureOffset(Texture, _offSet);
    }
}
