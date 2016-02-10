using UnityEngine;
using System.Collections;

public class TouchPosition : MonoBehaviour {
	private Vector2 _touchCoord;





	

	void Update () {
		#if UNITY_EDITOR_WIN
			if (Input.GetMouseButton(0)){
				//Debug.Log("Screen's been touched");
				_touchCoord.x = Camera.main.ScreenToWorldPoint( Input.mousePosition).x; //Просто Input.mousePosition работало только в правой верхней четверти), судя по всему дело в том, что просто mousePosition дает только положительные значения, во всех точках
				_touchCoord.y = Camera.main.ScreenToWorldPoint( Input.mousePosition).y; //Есть еще вариант через лучи, но не думаю, что он лучше
					
				//Debug.Log(_touchCoord);
				//Debug.Log(Input.mousePosition);	
				Controller.Rotate.Say (_touchCoord);

			}
		#endif


		#if UNITY_ANDROID
			if (Input.touchCount > 0){
				_touchCoord = Input.GetTouch(0).position;
				Controller.Rotate.Say (_touchCoord);
			}
		#endif
	}
}
