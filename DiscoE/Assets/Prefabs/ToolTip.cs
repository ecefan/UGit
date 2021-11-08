using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private static ToolTip instance;
    
    [SerializeField]
    private Camera uiCamera;
   /* [SerializeField]
    private RectTransform canvasRectTransform;*/
    private Text toolTipText;
    private RectTransform backgroundRectTransform;
    
    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("toolBack").GetComponent<RectTransform>();
        toolTipText = transform.Find("toolText").GetComponent<Text>();
        HideToolTip();

        
    }

    private void Update()
    {
        Vector2 localPoint = Input.mousePosition;

        if (Screen.width - Input.mousePosition.x < backgroundRectTransform.rect.width)
        {

            localPoint -= new Vector2(backgroundRectTransform.rect.width, 0);
        }

        if (Screen.height - Input.mousePosition.y < backgroundRectTransform.rect.height)
        {

            localPoint -= new Vector2(0, backgroundRectTransform.rect.height);
        }

        transform.position = localPoint;



        /*  Vector2 localPoint;
          RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
          transform.localPosition = localPoint;

          Vector2 anchoredPosition = transform.GetComponent<RectTransform>().anchoredPosition;
          if( anchoredPosition.x + backgroundRectTransform.rect.width > canvasRectTransform.rect.width)
          {
              anchoredPosition.x = canvasRectTransform.rect.width - backgroundRectTransform.rect.width;
          }
          transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;  ƒÎˇ Í‡Ì‚‡Ò‡ Ò ﬁ¿…  ¿Ã≈–Œ…*/
    }
    private void ShowToolTip(string toolTipString)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        toolTipText.text = toolTipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 2f, toolTipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideToolTip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowToolTip(tooltipString);
    }

    public static void HideTooltip_Static()
    {
        instance.HideToolTip();
    }
}
