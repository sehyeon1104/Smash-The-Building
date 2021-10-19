using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Building : MonoBehaviour
{
    
    Button Clicker;
    public int fullhp;
    int DeathMoney=5;
    public int hp;
    public Image hpbar;
    int BreakLevel;
    const int BreakCount = 5;
    public float[] pos = new float[BreakCount];

    private void Awake()
    {
        
        print("AWAkewasstartd");
        for(int i=0;i<BreakCount;i++)
        {
            pos[i] = (1 / (float)(BreakCount-1))* i;
            print(i);
        }

        Clicker = GetComponent<Button>();
        Clicker.onClick.RemoveAllListeners();
        Clicker.onClick.AddListener(() => {
            Main main = Json.Instance.vo.main[((int)GameManager.Instance.CurMain)];
            Clicked(main.Damage);
        });
    }
    // Start is called before the first frame update
    public void Clicked(int damage)
    {
        //´åÆ®¿ø
        hp -= damage;
        
        if(hp<=0)
        {
            GameManager.Instance.money += DeathMoney;
            GameManager.Instance.Breaked();
            Destroy(gameObject);
            return;
        }
        
        hpbar.fillAmount = hp / (float)fullhp;
        int BreakLevel = 0;
        for(int i=0; i<BreakCount-2; i++)
        {
            if (pos[i] <= hpbar.fillAmount && hpbar.fillAmount < pos[i + 1])
            {
                BreakLevel = i+1;
                break;
            }
                
        }

        if (!(this.BreakLevel == BreakLevel)) ;
           

        
    }

}
