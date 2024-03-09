using UnityEngine;

public class PlatformMoveScript : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 startPosition;
    [SerializeField]
    private Vector3 finishPosition;
    private void Start()
    {
        startPosition = this.gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        if(this.gameObject.transform.position == startPosition)
        {
            startPosition = finishPosition;
            if (startPosition == finishPosition)
                finishPosition = this.gameObject.transform.position;
        }
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, startPosition, Time.deltaTime * speed);
    }
}
