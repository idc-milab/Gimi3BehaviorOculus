using UnityEngine;
using System.IO;
using System;

public class ProxtemicsCSV : MonoBehaviour
{
    private float time = 0.0f;
    private UnityEngine.Camera FOV;
    private StreamWriter writer;
    public Rigidbody gimiCentre;
    public float interpolationPeriod = 1f;
    public Transform head;


    void Awake()
    {
        if (!Directory.Exists(getPathToCSV()))
        {
            Directory.CreateDirectory(getPathToFile());
        }
        writer = new StreamWriter(getPathToCSV());
        writer.WriteLine("Time , distance to gimi, isGimiVisable");
        FOV = UnityEngine.Camera.main;

    }

    //-------------------------------------------------
    void FixedUpdate()
    { 

        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            writer.WriteLine(DateTime.Now.ToString() + " , " + Vector3.Distance(gimiCentre.position, head.position).ToString() + "," + IsVisable());
            writer.Flush();
            //Debug.Log("HMD position: " + head.position);
            //Debug.Log("Distance from Gimi: " + Vector3.Distance(gimiCentre.position, head.position));
        }
    }

    private string IsVisable()
    {
        Vector3 viewPos = FOV.WorldToViewportPoint(gimiCentre.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            return  true.ToString();
        }
        else
            return false.ToString();

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