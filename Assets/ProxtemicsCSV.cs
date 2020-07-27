using UnityEngine;
using System.IO;
using System;

public class ProxtemicsCSV : MonoBehaviour
{
    public Transform head;
    //#todo change for final build
    private StreamWriter writer;

    private CapsuleCollider capsuleCollider;
    private Rigidbody position;
    public Rigidbody gimiCentre;
    private float time = 0.0f;
    public float interpolationPeriod = 1f;
    public Renderer Gimi_renderer;



    void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        if (!Directory.Exists(Application.dataPath + "/../CSV/" + "Proxtemics.csv"))
        {
            Directory.CreateDirectory(Application.dataPath + "/../CSV/");
        }
        writer = new StreamWriter(Application.dataPath + "/../CSV/" + "Proxtemics.csv");
        //This is writing the line of the type, name, damage... etc... (I set these)
        writer.WriteLine("Time , distance to gimi, isGimiVisable");

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
            writer.WriteLine(DateTime.Now.ToString() + " , " + Vector3.Distance(gimiCentre.position, this.transform.position).ToString() + "," + Gimi_renderer.isVisible);
            writer.Flush();
            //print(DateTime.Now.ToString() + " , " + Vector3.Distance(gimiCentre.position, this.transform.position).ToString() + "," + Gimi_renderer.isVisible
        }


    }


    private string getPath()
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

}