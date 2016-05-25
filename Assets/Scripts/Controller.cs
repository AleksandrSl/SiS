using UnityEngine;
using System.Collections;


public class Controller{
	public static Message<Touch> Touch = new Message<Touch>();
	public static Message<float> Fire = new Message<float>();
    public static Message<float> DemoFire = new Message<float>();
    public static Message<float> FillRadialElement = new Message<float>();
    public static Message DemoMissileDestroy = new Message();
}
