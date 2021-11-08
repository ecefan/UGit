using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip_Warning : MonoBehaviour
{
    private static ToolTip_Warning instance;

    [SerializeField]
    private Camera uiCamera;
 
    private Text toolTipText;
    private RectTransform backgroundRectTransform;
    private float showTimer;
    private Func<string> getTooltipStringFunc;

    private void Awake()
    {
        instance = this;
        backgroundRectTransform = transform.Find("toolBack").GetComponent<RectTransform>();
        toolTipText = transform.Find("toolText").GetComponent<Text>();
        HideToolTipWarning();


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

        SetText(getTooltipStringFunc());
        showTimer -= Time.deltaTime;

        if(showTimer <= 0)
        {
            HideToolTipWarning();
        }

    }
    private void ShowToolTipWarning(string tooltipString, float showTimerMax = 2f)
    {
        ShowToolTipWarning(() => tooltipString, showTimerMax);
    }

    private void ShowToolTipWarning(Func<string> getTooltipStringFunc, float showTimerMax = 2f)
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        this.getTooltipStringFunc = getTooltipStringFunc;
        showTimer = showTimerMax;
        Update();
    }

    private void SetText(string tooltipString)
    {
        toolTipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 2f, toolTipText.preferredHeight + textPaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideToolTipWarning()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltipWarning_Static(string tooltipString)
    {
        instance.ShowToolTipWarning(tooltipString);
    }

    public static void HideTooltipWarning_Static()
    {
        instance.HideToolTipWarning();
    }
}
