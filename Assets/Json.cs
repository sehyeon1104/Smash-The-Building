using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public enum SURV
{ 
    ³ëµ¿ÀÚ,ºÒµµÀú,±¼Âø±â,ºÒÅ©·¹ÀÎ,ÆøÅº,SIZE
}
public enum MAIN
{
    ºü·ç,¿ÀÇÔ¸¶,ÁÖ¸Ô,»Ñ·¹Ä«,SIZE 
}

public class Json : MonoSingleTon<Json>
{
    string Path;
    string Name = "/Save.txt";
    
    public ItemVO vo;

    private void Start()
    {
        InvokeRepeating("SaveToJson", 3, 7);
    }
    public void Awake()
    {
        Path = Application.dataPath;
        //asset Æú´õ
        print(Path+Name);
        if (!File.Exists(Path))
        {
            Directory.CreateDirectory(Path);
        }

        LoadFromJson();

    }
    void LoadFromJson()
    {

        string json = File.ReadAllText(Path + Name);
        vo = JsonUtility.FromJson<ItemVO>(json);
    }
    [ContextMenu("savetoJson")]
    public void SaveToJson()
    {
        string data = JsonUtility.ToJson(vo);
        File.WriteAllText(Path + Name, data, System.Text.Encoding.UTF8);
        print("svae");
    }


    private void OnApplicationQuit()
    {
        SaveToJson();
    }

    
    
}
[System.Serializable]
public class ItemVO
{
    public int Money;
    public List<Main> main = new List<Main>();
    public List<Surv> surv = new List<Surv>();
}

[System.Serializable]
public class Main
{
    public string Name;
    public  int Level=0;
    public int Damage;
    public float Delay;
    public int RepeatTime = 0;
    public int RepeatDelay = 0;
    public int Cost;

}

[System.Serializable]
public class Surv
{
    public string Name;
    public int Level=0;
    public int Eps;
    public int Cost;
}

