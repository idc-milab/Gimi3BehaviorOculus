
using System;
public class SingleGimiData
{
    private DateTime Ti;
    private float dis;
    private float l1;
    private float between;
    private float m3;
    private float vis;

    public SingleGimiData(DateTime Ti, float dis, float l1, float between, float m3, float vis)
    {
        this.Ti = Ti;
        this.dis = dis;
        this.l1 = l1;
        this.between = between;
        this.m3 = m3;
        this.vis = vis;
    }
    public string PrintCSV()
    {
        return $"{Ti},{dis},{l1},{between},{m3},{vis}";
    }
}