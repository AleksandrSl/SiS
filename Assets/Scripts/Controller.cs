using UnityEngine;
using System.Collections;


public class Controller{
	public static Message<Touch> Touch = new Message<Touch>();
	public static Message<float> FireForce = new Message<float>();
    public static Message DestroyDemoFire = new Message();
    public static Message<float> DemoFireForce = new Message<float>();
    public static Message<float> FillRadialElement = new Message<float>();
    public static Message DemoMissileDestroy = new Message();
    public static Message<float> ExplSpawned = new Message<float>();
    public static Message<float> UpdateEnergyBar = new Message<float>();
}
