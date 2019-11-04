using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RPCamera))]
public class RPCameraController : MonoBehaviour
{
	public RPCamera rPCamera = null;

	private Camera m_camera = null;
	private float m_cameraInitialSize = 0.0f;

	private Quaternion m_movingFlatDirection = Quaternion.identity;

	private SmoothValue m_smoothMouseX = new SmoothValue(0.0f, 10f);
	private SmoothValue m_smoothMouseY = new SmoothValue(0.0f, 10f);

	private SmoothValue m_smoothPerspective = new SmoothValue(0.0f, 10f);
	private SmoothValue m_smoothSizeScale   = new SmoothValue(0.0f, 10f);

    private float timer = 0.0f;

    void Start() {
		if (rPCamera == null) throw new UnityException ("Perspective Camera not set");
		if (rPCamera.pivot == null) throw new UnityException ("Pivot not set");

		m_camera = GetComponent<Camera>();
		m_cameraInitialSize = m_camera.orthographicSize;

		m_movingFlatDirection = Quaternion.Euler(0f, rPCamera.pivot.localRotation.eulerAngles.y, 0f);
	}


	void Update() {


        
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);

        
        if (timer > 3 && timer < 5 && rPCamera.perspective > -5)
        {
            rPCamera.perspective -= 7 * Time.deltaTime;
            rPCamera.UpdateProjection(true);
        }

        float count = (timer - 5) / 3.18f;
        float speed = (Mathf.Cos(count - 3.14f) + 1) / 2 + 1;
        if (timer > 5 && rPCamera.perspective < 100) {
            
            rPCamera.perspective += 15 * speed * Time.deltaTime;
            rPCamera.UpdateProjection(true);
        }
        Debug.Log(timer);
        Debug.Log("speed" + speed);
        Debug.Log(rPCamera.perspective);
    }

}


public class SmoothValue {
	public float target = 0.0f;
	private float value = 0.0f;
	private float velocity = 0.1f;
	public SmoothValue(float value, float velocity) {
		this.value = this.target = value;
		this.velocity = velocity;
	}
	public bool IsMoving() {
		return Mathf.Abs(target - value) > 0.000001f;  // !!! make configurable
	}
	public float GetValue() {
		value = Mathf.Lerp(value, target, velocity * Time.deltaTime);
		return value;
	}
}

