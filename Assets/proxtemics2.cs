using UnityEngine;
using System.IO;
using System;



public class proxtemics2 : MonoBehaviour
{
    private float time = 0.0f;
    private UnityEngine.Camera FOV;
    private StreamWriter writer;
    private float distance;
    private int excel_line_counter;
    public Rigidbody gimiCentre;
    public float interpolationPeriod = 1f;
    public Transform head;
    public GimiData GD;

    void Awake()
    {
        GD = new GimiData();
        FOV = UnityEngine.Camera.main;
    }

    //-------------------------------------------------
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= interpolationPeriod)
        {
            distance = (float)Vector3.Distance(gimiCentre.position, head.position);
            GD.addToTable(distance,
                ((distance < 1) ? 1 : 0),
                ((distance >= 1 && distance <= 2) ? 1 : 0),
                ((distance > 3) ? 1 : 0),
                (IsVisable() ? 1 : 0));
            time = 0.0f;
            Debug.Log(GD.table.Count);
        }
    }


    void OnApplicationQuit()
    {
        if (!Directory.Exists(getPathToCSV()))
        {
            Directory.CreateDirectory(getPathToFile());
        }
        writer = new StreamWriter(getPathToCSV());
        writer.WriteLine("Time , distance to gimi, less than 1 , between 1 and 2 , between 2 and 3 , isGimiVisable");
        foreach (SingleGimiData element in GD.table)
        {
            writer.WriteLine(element.PrintCSV());
            writer.Flush();
        }
        writer.WriteLine(GD.getAverages());
        writer.Flush();
        writer.Close();
    }
    private bool IsVisable()
    {
        Vector3 viewPos = FOV.WorldToViewportPoint(gimiCentre.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            return true;
        }
        else
            return false;

    }



    private string getPathToCSV()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "ProxtemicsWith.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"/CSV/" + "ProxtemicsWith.csv";
#elif UNITY_IPHONE
                return Application.persistentDataPath+"/"+"Saved_Inventory.csv";
#else
        return Application.dataPath +"/CSV/" + "Proxtemics.csv";
#endif
    }
    private string getPathToFile()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"/CSV/";
#else
        return Application.dataPath +"/CSV/";
#endif
    }


}

