using System.Collections.Generic;
using System;
using System.IO;
public class GimiData
{
    private float f_avarageDistance;
    private float f_avarageless11;
    private float f_avaragebetween;
    private float f_avaragemore3;
    private float f_avarageVisab;
    private int entries;
    public List<SingleGimiData> table = new List<SingleGimiData>();

    public GimiData()
    {
        this.f_avarageDistance = 0;
        this.f_avarageless11 = 0;
        this.f_avaragebetween = 0;
        this.f_avaragemore3 = 0;
        this.f_avarageVisab = 0;
        this.entries = 0;
    }

    
    public void addToTable(float dis,float l1,float between,float m3,float vis)
    {
        table.Add(new SingleGimiData(DateTime.Now, dis, l1, between, m3, vis));
        f_avarageDistance += dis;
        f_avarageless11 += l1;
        f_avaragebetween += between;
        f_avaragemore3 += m3;
        f_avarageVisab += vis;
        entries++;
        
    }
    public string getAverages()
    {
        return $"{entries},{getAvergeDistance()},{getAvergeLessThan1()},{getAvergeBetween()},{getAvergeMore3()},{getAverageVis()}";
    }
    public float getAvergeDistance()
    {
        return f_avarageDistance / entries;
    }
    public float getAvergeLessThan1()
    {
        return f_avarageless11 / entries;
    }
    public float getAvergeBetween()
    {
        return f_avaragebetween / entries;
    }
    public float getAvergeMore3()
    {
        return f_avaragemore3 / entries;
    }
    public float getAverageVis()
    {
        return f_avarageVisab / entries;
    }

}