using UnityEngine;
using System.Collections;

public class AimMouse : MonoBehaviour
{

  private Vector3 mouse_pos;
  public Transform target;
  private Vector3 object_pos;
  private float angle;
  private Vector3 lastMousePos;
    private bool mouseAimActive;

  void Update()
  {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // aim with stick
        if (System.Math.Abs(moveHorizontal) + System.Math.Abs(moveVertical) > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, new Vector3(moveHorizontal, moveVertical,0));
            mouseAimActive = false;
        }
        else
        {
            mouse_pos = Input.mousePosition;
            if (!mouseAimActive)
                if (lastMousePos != mouse_pos) // mouse has moved!
                    mouseAimActive = true;

            if (mouseAimActive) // aim to mouse
            {
                lastMousePos = mouse_pos;
                mouse_pos.z = 0;
                object_pos = Camera.main.WorldToScreenPoint(target.position);
                mouse_pos.x = mouse_pos.x - object_pos.x;
                mouse_pos.y = mouse_pos.y - object_pos.y;
                //angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
                //transform.rotation = Quaternion.Euler(0, 0,360 -  angle + 90);
                //transform.rotation = Quaternion.FromToRotation(Vector3.up, mouse_pos);
                transform.rotation = Quaternion.LookRotation(Vector3.back, mouse_pos);
            }
            else  //no mouseAim and no input from controller
            {
            var lookdir = GetComponent<Rigidbody2D>().velocity;
            if (lookdir.magnitude > 0.5)
                transform.SetPositionAndRotation(transform.position, Quaternion.LookRotation(Vector3.back, GetComponent<Rigidbody2D>().velocity));
            }
        }



    }
}