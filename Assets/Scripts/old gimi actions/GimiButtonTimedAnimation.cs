using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GimiButtonTimedAnimation : MonoBehaviour {

    public new Animation animation;

    void Start()
    {
        animation = GetComponent<Animation>();
        StartCoroutine(MyCoroutine());
    }

    void RepeatMyCoroutine()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        animation.Play("ClipName");
        yield return new WaitForSeconds(5f);
        animation.Stop("ClipName");
        RepeatMyCoroutine();
        yield return null;
    }
    /*
        // Use this for initialization
        public Animation Uni_Animation_GimiB_move;
        public float f_threshhold; //trigger pf movement
        public int I_Timer;
        private bool b_TimePass;


        // Use this for initialization
        void Start()
        {
            Uni_Animation_GimiB_move = GetComponent<Animation>();
            b_TimePass = false;
            InvokeRepeating("b_TimePassSwitch", 0f, 10f);
        }

        // Update is called once per frame
        void Update()
        {
            if (Uni_Animation_GimiB_move.isPlaying||b_TimePass)
            {
                return;
            }
            float distance = GetDistanceFromGimi();
            if (distance < f_threshhold )
            {
                Uni_Animation_GimiB_move.Play();
                //yield wait(Timer);
                Uni_Animation_GimiB_move.Rewind(); 
            }
        }

        public float GetDistanceFromGimi()
        {
            float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
            return distance;
        }

        public void b_TimePassSwitch()
        {
            b_TimePass=!b_TimePass;
        }*/
}
