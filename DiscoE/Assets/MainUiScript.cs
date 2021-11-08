using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class MainUiScript : MonoBehaviour
{
    public UI_SkillTree uI_SkillTree;
    private void Awake()
    {
        transform.Find("SkillTreeBtn").GetComponent<Button_UI>().MouseOverOnceFunc = () => ToolTip.ShowTooltip_Static("SkillTree");
        transform.Find("SkillTreeBtn").GetComponent<Button_UI>().MouseOutOnceFunc = () => ToolTip.HideTooltip_Static();

        transform.Find("SkillTreeBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            uI_SkillTree.gameObject.SetActive(true);
        };
    }
}
