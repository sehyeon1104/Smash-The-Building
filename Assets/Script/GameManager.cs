using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleTon<GameManager>
{
    public int Eps;
    Canvas canvas;
    public int money = 0;
    Button Clicker;
    Building building;
    public MAIN CurMain;
    public SURV CurSurv;
    public Text moneyText;
    public Building buildingPrefab;
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    void SetUI()
    {
        moneyText.text = money.ToString();
    }

    public void Breaked()
    {
        print("StartBera");
        building = Instantiate(buildingPrefab,canvas.transform).GetComponent<Building>();
        SetUI();
    }

    private void Start()
    {
        money = Json.Instance.vo.Money;      
    }

    public void BuyMain(MAIN m)
    {
        money -= Json.Instance.vo.main[(int)m].Cost;
        Json.Instance.vo.main[(int)m].Level += 1;
        Json.Instance.vo.main[(int)m].Cost += 500;
        Json.Instance.vo.main[(int)m].Damage += 5;
    }

    public void BuySurv(SURV s)
    {
        Json.Instance.vo.main[(int)s].Level += 1;
        money -= Json.Instance.vo.surv[(int)s].Cost;
        Json.Instance.vo.surv[(int)s].Eps += 10;
    }

    IEnumerator EpsPlay()
    {
        yield return new WaitForSeconds(1);
        building.Clicked(Eps);
        
    }
}
