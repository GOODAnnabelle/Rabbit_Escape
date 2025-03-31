using UnityEngine;

public class RabbitController : MonoBehaviour
{
    [Header(" ")]
    [SerializeField] private float moveDistance = 1f;

    [Header(" ")]
    [SerializeField] private Transform footPoint;
    [SerializeField] private float scaleStep = 0.1f;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2f;


    private Vector3 _initialPosition;
    private Vector3 _initialScale;
    private Quaternion _initialRotation;
    private float _currentScale = 1f;

    void Start()
    {

        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _initialScale = transform.localScale;
    }

    public void MoveLeft() => transform.Translate(-moveDistance, 0, 0);
    public void MoveRight() => transform.Translate(moveDistance, 0, 0);

    public void ScaleUp() => SetScale(_currentScale + scaleStep);
    public void ScaleDown() => SetScale(_currentScale - scaleStep);

    private void SetScale(float newScale)
    {
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        Vector3 worldFootBefore = footPoint.position;
        transform.localScale = _initialScale * newScale;
        transform.position += worldFootBefore - footPoint.position;

        _currentScale = newScale;
    }

    public void FullReset()
    {
        transform.position = _initialPosition;
        transform.rotation = _initialRotation;
        transform.localScale = _initialScale;
        _currentScale = 1f;
    }


    void OnDrawGizmosSelected()
    {
        if (footPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(footPoint.position, 0.05f);
        }
    }
}