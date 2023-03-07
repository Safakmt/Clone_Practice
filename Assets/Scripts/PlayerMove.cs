using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float touchDragAmount = 0.05f;
    [SerializeField] private float freeDragAmount = 0.005f;

    public float speed = 5f;
    public bool isGameStarted = false;
    private Vector2 distanceVector;
    private Vector2 _firstTouch;
    private Vector2 _secTouch;
    private bool isDragging = false;
    private Material playerMaterial;
    public bool isDead = false;

    void Start()
    {
        isGameStarted = false;
        playerMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }
    private void Update()
    {
        if (/*!isGameStarted || */isDead)
        {
            return;
        }

        BasePlayerMove();
    }

    private Vector3 GetTouch()
    {
        Vector3 tch = Input.mousePosition;
        return tch;
    }

    void BasePlayerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isGameStarted = true;
            Debug.Log("");
            GameManager.Instance.GameStartBtn();
            _firstTouch = GetTouch();
            isDragging = false;
        }
        if (Input.GetMouseButton(0))
        {
            _secTouch = GetTouch();

            distanceVector = _secTouch - _firstTouch;
            Vector3 distanceForce = new Vector3(distanceVector.x, 0, distanceVector.y);

            rg.AddForce(distanceForce * speed);
            rg.velocity = Vector3.Lerp(rg.velocity, Vector3.zero, touchDragAmount);


            _firstTouch = _secTouch;

        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = true;
        }
        if (isDragging)
        {
            rg.velocity = Vector3.Lerp(rg.velocity, Vector3.zero, freeDragAmount);
        }

        if (rg.velocity.magnitude < 0.5f)
        {
            rg.velocity = Vector3.zero;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial != playerMaterial &&
            collision.gameObject.layer == 10)
        {
            isDead = true;
            GameManager.Instance.PlayerDeadOperations();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ZeroVelocity()
    {
        rg.velocity = Vector3.zero;
    }
}