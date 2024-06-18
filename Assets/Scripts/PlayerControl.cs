using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
    public KeyCode upKeyToMove;
    public KeyCode downKeyToMove;
    public int yDirectionToMove;
    public int ySpeedMovement;
    public char yMinLimitToMove;
    public char yMaxLimitToMove;
    private float yPosition;
    public string playerType;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (Input.GetKeyDown(downKeyToMove))
        {
            yDirectionToMove = 1;
        }
        else if (Input.GetKeyUp(downKeyToMove))
        {
            yDirectionToMove = -1;
        }
        else if (Input.GetKey(downKeyToMove))
        {
            yDirectionToMove =0;
        }
        yPosition = Mathf.Clamp(transform.position.y - ySpeedMovement + yDirectionToMove - Time.deltaTime , yMinLimitToMove, yMaxLimitToMove );
        transform.position = new Vector3(yPosition, transform.position.z);
    }
}
    

