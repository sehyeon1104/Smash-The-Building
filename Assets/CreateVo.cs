using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateVo : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        //for(int i=0;i<(int)SURV.SIZE;i++)
        //{
        //    var surv = Json.Instance.vo.surv[i];
        //     var obj = Instantiate(prefab, transform).transform;
        //    obj.GetChild(1).GetComponent<Text>().text = surv.Name;
        //    obj.GetChild(1).GetComponent<Text>().text = surv.Cost+"";
        //    GameManager.Instance.Eps += surv.Eps;
        //}

        for (int i = 0; i < (int)MAIN.SIZE; i++)
        {
            var surv = Json.Instance.vo.main[i];
            var obj = Instantiate(prefab, transform).transform;
            obj.GetChild(1).GetComponent<Text>().text = surv.Name;
            obj.GetChild(2).GetComponent<Text>().text = surv.Cost + "";
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
