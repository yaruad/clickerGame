using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyMove : MonoBehaviour
{
    public Vector2 point;
    public TextMeshProUGUI txt;

    void Start()
    {
        txt = transform.GetComponentInChildren<TextMeshProUGUI>();

        //txt.text = "+" + GameManger.gm.moneyIncreaseAmount.ToString("###,###");

        txt.text = $"+{GameManger.gm.moneyIncreaseAmount:F0}";
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, point, Time.deltaTime * 10f);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - 0.01f);

        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, txt.color.a - 0.01f);

        Destroy(this.gameObject, 1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.2f);
    }
}
