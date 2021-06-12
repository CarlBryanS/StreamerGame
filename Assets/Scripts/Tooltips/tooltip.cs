using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;
    public int characterLimit;
    public RectTransform rectTransform;
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }
    // Start is called before the first frame update
    public void SetText(string content, string header = ""){
        if(string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else{
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled =(headerLength>characterLimit|| contentLength>characterLimit)?true:false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position =Input.mousePosition;

        float pivotX = position.x / Screen.width;
        float pivotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);
        transform.position = position;
    }
}
