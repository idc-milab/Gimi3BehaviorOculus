// C#
using System;
using UnityEngine;


public class GimiStalker : MonoBehaviour {

    #region possion and time parameters
    
    public Transform target;
    public float timedelay = .5f;
    Quaternion orginalPosition;
    [SerializeField]
    bool B_shouldJiggle = false;
    private float time;
    private Vector3 oldPos;
    private float timmerForJiggle;

    #endregion


    #region jitter function parameters 

    [Range(0, 1)]
    public float power = .1f;
    [Header("Position Jiggler")]
    public Vector3 positionJigAmount;
    [Range(0, 120)]
    public float positionFrequency = 10;
    float positionTime;
    Vector3 basePosition;
    #endregion


    private void Awake() {
       
    }

    private void Start() {
        orginalPosition = transform.rotation;
        basePosition = this.transform.localPosition;
        oldPos = transform.position;
        timmerForJiggle = 1;
    }

    void Update() {
        time += Time.deltaTime;
        timmerForJiggle += Time.deltaTime;
        positionTime += time * positionFrequency;

        if (Vector3.Distance(this.transform.position,oldPos)>1.0f)//moved
        {
            oldPos = transform.position;
            B_shouldJiggle = true;
            timmerForJiggle = 0;
            transform.LookAt(target);
        }
        else {
            if(timmerForJiggle < 0.1f)//finished move jiggle time delay
            {
                transform.LookAt(target);
                this.transform.localPosition = basePosition + positionJigAmount * Mathf.Sin(positionTime) * power;
            }
            else
            {
                transform.LookAt(target);
            }
        }
        

       
    }



    #region not used fundtions
    void SmoothLookAt(Vector3 newDirection)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDirection - transform.position), Time.deltaTime * 3);
    }


    /// <summary>
    /// maybe usefull in the future
    /// </summary>
    /// <param name="looker"></param>
    /// <param name="targetPos"></param>
    /// <param name="FOVAngle"></param>
    /// <returns></returns>
    bool IsLookingAtObject(Transform looker, Vector3 targetPos, float FOVAngle)
    {

        Vector3 direction = targetPos - looker.position;
        float ang = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float lookerAngle = looker.eulerAngles.z;
        float checkAngle = 0f;

        if (ang >= 0f)
            checkAngle = ang - lookerAngle - 90f;
        else if (ang < 0f)
            checkAngle = ang - lookerAngle + 270f;

        if (checkAngle < -180f)
            checkAngle = checkAngle + 360f;

        if (checkAngle <= FOVAngle * .5f && checkAngle >= -FOVAngle * .5f)
            return true;
        else
            return false;
    }
    #endregion
}
