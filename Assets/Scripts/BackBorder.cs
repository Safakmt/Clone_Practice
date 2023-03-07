using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBorder : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private MeshRenderer m_Renderer;
    private Vector3 screenBorders;
    private float speed;
    private bool isMoving = false;

    void Start()
    {
        m_Renderer= GetComponent<MeshRenderer>();
        m_Renderer.enabled=false;

        screenBorders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(screenBorders.x, player.transform.position.y, screenBorders.z);

        speed = Camera.main.GetComponent<CameraFollow>().followSpeed;

    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void StartMove(bool state)
    {
        isMoving = state;
    }
}
