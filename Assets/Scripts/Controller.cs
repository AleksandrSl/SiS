using UnityEngine;
using System.Collections;


public class Controller{
	public static Message<Touch> Touch = new Message<Touch>();
	public static Message<float> Fire = new Message<float>();
    public static Message<float> demoFire = new Message<float>();
    public static Message<float> fillRadialElement = new Message<float>();
    public static Message demoMissileDestroy = new Message();
}
