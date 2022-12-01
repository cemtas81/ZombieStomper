using UnityEngine;



//[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector3 draggingPos;
    Touch touch;
    public float maxdrag;
    private Rigidbody rb;
    public float power;
    private bool isShoot;
    LineRenderer lr;
    public float shoot;
    public int lineSegment;
    public Transform shootPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        lr.positionCount = lineSegment;
    }

    //private void OnMouseDown()
    //{
    //    mousePressDownPos = Input.mousePosition;
    //}

    //private void OnMouseUp()
    //{
    //    mouseReleasePos = Input.mousePosition;
    //    Shoot(mousePressDownPos - mouseReleasePos);
    //}

    //private float forceMultiplier = 200;
    //void Shoot(Vector3 Force)
    //{
    //    if (isShoot)
    //        return;

    //    rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier * Time.deltaTime);
    //    isShoot = true;
    //}
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();

            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }
    void DragStart()
    {
        //mousePressDownPos = Camera.main.ScreenToWorldPoint(touch.position);

        mousePressDownPos = touch.position;

    }
    void Dragging()
    {
        //draggingPos = Camera.main.ScreenToWorldPoint(touch.position);

        draggingPos = touch.position;

    }
    void DragRelease()
    {
        //mouseReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        mouseReleasePos = touch.position;
        Vector3 force = mousePressDownPos - mouseReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxdrag) * power * Time.deltaTime;
        rb.AddForce(clampedForce.x, clampedForce.y, clampedForce.y, ForceMode.Impulse);
        //shootPoint= Vector3.ClampMagnitude(force, maxdrag) * power * Time.deltaTime;
        Vector3 vo= Vector3.ClampMagnitude(force, maxdrag) * power * Time.deltaTime;
        Visualize(vo);
        
    }
    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i / (float)lineSegment);
            lr.SetPosition(i, pos);

        }
    }
    Vector3 CalculatePosInTime(Vector3 vo,float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;
        Vector3 result = shootPoint.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shootPoint.position.y;
        result.y = sY;
        return result;
    }


}