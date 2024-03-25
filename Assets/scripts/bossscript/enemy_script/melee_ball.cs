using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class melee_ball : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject p=null;
    int timer=0;
    float frame=0.0166f;
    float lastti=0;
    int framed=0;
    float rdeg=0;
    float edeg=0;
    void Start()
    {
        basicbullet basb=GetComponent<basicbullet>();
        basb.bound=false;
        basb.chv(0);
    }
    public void setparent(GameObject x,float d){
        p=x;
        rdeg=d;
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time-lastti>frame){
            timer++;
            framed=1;
            lastti=Time.time;
        }
        if(framed==1){
            basicbullet basb=GetComponent<basicbullet>();
            if(p==null){
                basb.chv(4);
                basb.chdeg(edeg);
                basb.bound=true;
                return;
            }
            
            datas ds=p.GetComponent<datas>();
            float x=p.transform.localPosition.x,y=p.transform.localPosition.y;
            basb.chplace(x+ds.rax*(float)Math.Cos((rdeg+ds.rbx)/180f*3.14),y+ds.rax*(float)Math.Sin((rdeg+ds.rbx)/180f*3.14));
            edeg=rdeg+ds.rbx;
        }
        
    }
}
