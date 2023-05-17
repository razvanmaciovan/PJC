using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private float dissapearTimer;
    private Color textColor;
    private GameObject _pfDamagePopup;
    // Start is called before the first frame update

    void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _pfDamagePopup = Resources.Load<GameObject>("Prefabs/DamagePopup");
    }
    public DamagePopup CreateDamagePopup(Vector3 position, int damageAmount)
    {
        var damagePopupTransform = Instantiate(_pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.SetText(damageAmount);
        return damagePopup;
    }
    public DamagePopup CreateDamagePopup(Vector3 position, int damageAmount, Color fontColor, int fontSize)
    {
        var damagePopupTransform = Instantiate(_pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.SetText(damageAmount,fontColor,fontSize);
        return damagePopup;
    }
    public void SetText(int damage)
    {
        _textMeshPro.SetText(damage.ToString());
        textColor = _textMeshPro.color;
        dissapearTimer = 1f;
    }
    public void SetText(int damage,Color color, int fontSize)
    {
        _textMeshPro.SetText(damage.ToString());
        _textMeshPro.color = color;
        _textMeshPro.fontSize = fontSize;
        textColor = _textMeshPro.color;
        dissapearTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 0.2f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        dissapearTimer -= Time.deltaTime;
        if(dissapearTimer < 0) //Fade out
        {
            float dissapearSpeed = 3f;
            textColor.a -= dissapearSpeed * Time.deltaTime;
            _textMeshPro.color = textColor;
            if (_textMeshPro.color.a <= 0) Destroy(gameObject);
        }

    }
}
