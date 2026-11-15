using UnityEngine;

public class FlyingCarController : MonoBehaviour
{
    public float speed = 22f;
    public float verticalSpeed = 12f;
    public float turnSpeed = 95f;
    float steer, throttle, lift;
    bool touchActive;

    void Update()
    {
        float horizontal = Mathf.Clamp(Input.GetAxisRaw("Horizontal") + steer,-1,1);
        float forward = Mathf.Clamp(Input.GetAxisRaw("Vertical") + throttle,-1,1);
        float vertical = Mathf.Clamp((Input.GetKey(KeyCode.Space)?1:0)-(Input.GetKey(KeyCode.LeftShift)?1:0)+lift,-1,1);
        transform.Rotate(0,horizontal*turnSpeed*Time.deltaTime,0);
        Vector3 velocity = transform.forward*forward*speed + Vector3.up*vertical*verticalSpeed;
        transform.position += velocity*Time.deltaTime;
        var p = transform.position;
        p.y = Mathf.Clamp(p.y,3,90);
        p.x = Mathf.Clamp(p.x,-120,120);
        p.z = Mathf.Clamp(p.z,-120,120);
        transform.position = p;
    }

    void OnGUI()
    {
        float w = Mathf.Min(Screen.width*.17f,110);
        float h = Mathf.Min(Screen.height*.16f,90);
        float y = Screen.height-h-18;
        steer = ButtonHeld(new Rect(15,y,w,h),"LEFT") ? -1 : ButtonHeld(new Rect(25+w,y,w,h),"RIGHT") ? 1 : 0;
        throttle = ButtonHeld(new Rect(Screen.width-2*w-35,y,w,h),"BACK") ? -1 : ButtonHeld(new Rect(Screen.width-w-20,y,w,h),"GO") ? 1 : 0;
        lift = ButtonHeld(new Rect(Screen.width-2*w-35,15,w,h),"DOWN") ? -1 : ButtonHeld(new Rect(Screen.width-w-20,15,w,h),"UP") ? 1 : 0;
    }

    static bool ButtonHeld(Rect rect,string label)
    {
        GUI.Box(rect,label);
        foreach (var touch in Input.touches)
            if (rect.Contains(new Vector2(touch.position.x,Screen.height-touch.position.y)) && touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) return true;
        return Input.GetMouseButton(0) && rect.Contains(new Vector2(Input.mousePosition.x,Screen.height-Input.mousePosition.y));
    }
}
