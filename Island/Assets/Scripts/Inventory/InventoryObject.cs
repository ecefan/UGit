using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{

    

    public string savePath;
    private ItemDatabase database;
    public List<InvenorySlot> Container = new List<InvenorySlot>();

    private void OnEnable()
    {
#if  UNITY_EDITOR
    database = (ItemDatabase)AssetDatabase.LoadAssetAtPath("Assets/Resourses/DataBase.asset", typeof (ItemDatabase));
    Debug.Log(Application.persistentDataPath);
#else 
    database = Resources.Load<ItemDatabase>("DataBase");
#endif

}


    public void AddItem(ItemObject _item, int _amount)
    {


        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }     
            Container.Add(new InvenorySlot(database.GetId[_item] ,_item, _amount));
     }
    public void OnAfterDeserialize()
    {
    for (int i = 0; i < Container.Count; i++)
    {
        Container[i].item = database.GetItem[Container[i].id];
    }
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.dataPath, saveData));
        bf.Serialize(file, saveData);
        file.Close();

    }

    public void Load()
    {
        if(File.Exists(string.Concat(Application.dataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.dataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();

        }
    }



    public void OnBeforeSerialize()
    {
       
    }
}




[System.Serializable]
public class InvenorySlot
{
    public int id;
    public ItemObject item;
    public int amount;
    public InvenorySlot(int _id, ItemObject _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}