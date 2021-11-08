using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class MainUiScript : MonoBehaviour
{
    public UI_SkillTree uI_SkillTree;
    public GameObject uI_Inventory;
    private bool activeBtn = true;
    private void Awake()
    {
        transform.Find("SkillTreeBtn").GetComponent<Button_UI>().MouseOverOnceFunc = () => ToolTip.ShowTooltip_Static("SkillTree");
        transform.Find("SkillTreeBtn").GetComponent<Button_UI>().MouseOutOnceFunc = () => ToolTip.HideTooltip_Static();

        transform.Find("SkillTreeBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (activeBtn == true)
            {
                uI_SkillTree.gameObject.SetActive(true);
                activeBtn = false;
            }
            else if(activeBtn == false)
            {
                uI_SkillTree.gameObject.SetActive(false);
                activeBtn = true;
            }
        };
        
        transform.Find("InventoryBtn").GetComponent<Button_UI>().MouseOverOnceFunc = () => ToolTip.ShowTooltip_Static("Inventory");
        transform.Find("InventoryBtn").GetComponent<Button_UI>().MouseOutOnceFunc = () => ToolTip.HideTooltip_Static();

        transform.Find("InventoryBtn").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (activeBtn == true)
            {
                uI_Inventory.gameObject.SetActive(true);
                activeBtn = false;
            }
            else if(activeBtn == false)
            {
                uI_Inventory.gameObject.SetActive(false);
                activeBtn = true;
            }
        };
    }
}