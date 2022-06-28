using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBeh : MonoBehaviour
{
    public Vector2 pos;
    public float angle;
    public Joystick js;
    public Vector3 rotation;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (js.Horizontal > 0 && js.Vertical > 0)
        {
            angle = Mathf.Rad2Deg * Mathf.Acos(js.Direction.normalized.x);
        }
        if (js.Horizontal > 0 && js.Vertical < 0)
        {
            angle = Mathf.Rad2Deg * Mathf.Asin(js.Direction.normalized.y);
        }
        if (js.Horizontal < 0 && js.Vertical > 0)
        {
            angle = Mathf.Rad2Deg * Mathf.Acos(js.Direction.normalized.x);
        }
        if (js.Vertical < 0 && js.Vertical < 0)
        {
            angle = Mathf.Rad2Deg * -Mathf.Acos(js.Direction.normalized.x);
        }
        if (js.Horizontal != 0 || js.Vertical != 0)
        {
            pos = new Vector2(player.transform.position.x + 1 * Mathf.Cos(Mathf.Deg2Rad * angle), player.transform.position.y + 1 * Mathf.Sin(Mathf.Deg2Rad * angle));

        }
        else
        {
            pos = new Vector2(player.transform.position.x + ((0.5f) * Mathf.Cos(Mathf.Deg2Rad * angle)), player.transform.position.y + ((0.5f) * Mathf.Sin(Mathf.Deg2Rad * angle)));
        }
        rotation = new Vector3(0, 0, angle);
        transform.SetPositionAndRotation(pos, Quaternion.Euler(rotation));
    }
}
