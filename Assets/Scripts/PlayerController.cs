using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHitWater, IHitVehicle
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float squeezeMinScale = 0.8f;
    [SerializeField]
    private float squeezeAnimationSpeed = 1;

    private bool canMove = true;
    private const int verticalAngle = 90;
    private SqueezeAnimation squeezeAnimation;
    private SwipeInput swipeInput;
    private ObstacleCollision obstacleCollision;
    private WaterCollision waterCollision;
    private float previousZPosition;

    public event System.Action MovingForward;

    private void Start()
    {
        obstacleCollision = new ObstacleCollision(transform);
        waterCollision = new WaterCollision(transform);
        squeezeAnimation = new SqueezeAnimation(transform);
        swipeInput = new SwipeInput();
    }

    private void Update()
    {
        if (!canMove)
            return;

        if (Input.GetMouseButton(0))
        {
            squeezeAnimation.Animate(squeezeMinScale, squeezeAnimationSpeed);
        }

        if (Input.GetMouseButtonDown(0))
        {
            swipeInput.MouseClickPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            swipeInput.MouseReleasePosition = Input.mousePosition;

            squeezeAnimation.Reset();
            RotateAndMove();
        }
    }

    private IEnumerator Move()
    {
        canMove = false;
        var newPosition = new Vector3(transform.position.x.RoundToEven(), 0, transform.position.z) + transform.forward * GlobalScale.scale;
        var currentPosition = transform.position;
        float movePercentage = 0;
        float jumpPercentage = 0;

        while (movePercentage <= 1.0f)
        {
            //Moving
            movePercentage += speed * Time.deltaTime;
            transform.position = Vector3.Lerp(currentPosition, newPosition, movePercentage);

            //Jumping 
            jumpPercentage = movePercentage * 2;
            transform.position = new Vector3(transform.position.x, MyLerp(jumpPercentage), transform.position.z);

            yield return null;
        }

        if(previousZPosition < transform.position.z)
        {
            OnMovingForward();
            previousZPosition = transform.position.z;
        }

        transform.position = newPosition;
        canMove = true;
        waterCollision.CheckCollision();
    }

    private void RotateAndMove()
    {
        if (swipeInput.IsSwipe)
        {
            if (swipeInput.IsSwipeHorizontal)
            {
                if (swipeInput.IsSwipeLeft)
                {
                    SetRotationAndMove(-verticalAngle);
                }
                else
                {
                    SetRotationAndMove(verticalAngle);
                }
            }
            else
            {
                if (swipeInput.IsSwipeDown)
                {
                    SetRotationAndMove(180);
                }
                else
                {
                    SetRotationAndMove(0);
                }
            }
        }
        else
        {
            SetRotationAndMove(0);
        }
    }

    private void SetRotationAndMove(int angle)
    {
        transform.rotation = Quaternion.Euler(Vector3.up * angle);

        if (obstacleCollision.IsHit)
            StartCoroutine(Move());
    }

    private static float MyLerp(float x)
    {
        return Mathf.Lerp(0, 1, -x * x + 2 * x);
    }

    public void Drown()
    {
        OnPlayerDie();
    }

    public void CrashIntoVehicle()
    {
        OnPlayerDie();
    }

    private void OnPlayerDie()
    {
        StopAllCoroutines();
        canMove = false;
    }

    private void OnMovingForward()
    {
        var handler = MovingForward;

        if (handler != null)
            handler();
    }
}
