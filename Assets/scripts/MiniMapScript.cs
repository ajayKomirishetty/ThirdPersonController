using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = Player.position;
        position.y = transform.position.y;
        transform.position = position;
        transform.rotation = Quaternion.Euler(90f,Player.eulerAngles.y,0f);

    }
}
