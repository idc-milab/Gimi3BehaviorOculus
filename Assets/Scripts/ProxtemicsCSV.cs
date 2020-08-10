using UnityEngine;
using System.IO;
using System;

public class ProxtemicsCSV : MonoBehaviour
{
    public Transform head;
    //#todo change for final build
    private StreamWriter writer;

    public Rigidbody gimiCentre;
    private float time = 0.0f;
    public float interpolationPeriod = 1f;
    public Renderer Gimi_renderer;
    private bool b_GimiIsVisable = false;
    private UnityEngine.Camera FOV;

    void Awake()
    {
        if (!Directory.Exists(getPathToCSV()))
        {
            Directory.CreateDirectory(getPathToFile());
        }
        writer = new StreamWriter(getPathToCSV());
        //This is writing the line of the type, name, damage... etc... (I set these)
        writer.WriteLine("Time , distance to gimi, isGimiVisable");
        FOV = UnityEngine.Camera.main;

    }

    //-------------------------------------------------
    void FixedUpdate()
    {
        //float distanceFromFloor = Vector3.Dot(head.localPosition, Vector3.up);
        //capsuleCollider.height = Mathf.Max(capsuleCollider.radius, distanceFromFloor);
        //transform.localPosition = head.localPosition - 0.5f * distanceFromFloor * Vector3.up;

        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;
            writer.WriteLine(DateTime.Now.ToString() + " , " + Vector3.Distance(gimiCentre.position, transform.position).ToString() + "," + IsVisable());
            writer.Flush();
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
        return Application.dataPath + "/CSV/" + "Proxtemics.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"/CSV/" + "Proxtemics.csv";
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