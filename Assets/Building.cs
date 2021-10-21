using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Building : MonoBehaviour
{
    object[] sprites; 
    Button Clicker;
    public int fullhp;
    int DeathMoney=5;
    public int hp;
    public Image hpbar;
    int BreakLevel;
    const int BreakCount = 6;
    Image SP;
    public float[] pos = new float[BreakCount];

    private void Awake()
    {
        sprites = Resources.LoadAll("Building");
         SP = GetComponent<Image>();
         SP.sprite = (Sprite)sprites[5];
        print(sprites);
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
        transform.DOShakePosition(1f,10);
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
        for(int i=0; i<BreakCount-1; i++)
        {
            if (pos[i] <= hpbar.fillAmount && hpbar.fillAmount < pos[i + 1])
            {
                BreakLevel = i;
                break;
            }
                
        }
        //if (!(this.BreakLevel == BreakLevel))
        {
            this.BreakLevel = BreakLevel;
            print(BreakLevel);
            
                
            SP.sprite = (Sprite)sprites[BreakLevel];
        }
           

        
    }

}
