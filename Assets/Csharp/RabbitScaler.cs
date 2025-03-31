using UnityEngine;

public class RabbitScaler : MonoBehaviour
{
    [Header("RabbitScaler")]
    [SerializeField] private Transform footPoint;
    [SerializeField] private float scaleStep = 0.1f;
    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 2f;

    private Vector3 _initialScale;
    private float _currentScale = 1f;

    void Start()
    {
        _initialScale = transform.localScale;
        _currentScale = 1f;
    }

    // 放大
    public void ScaleUp()
    {
        SetScale(_currentScale + scaleStep);
    }

    // 缩小
    public void ScaleDown()
    {
        SetScale(_currentScale - scaleStep);
    }

    private void SetScale(float newScale)
    {
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        // 计算脚底世界坐标（缩放前）
        Vector3 worldFootPosBefore = footPoint.position;

        // 应用新缩放
        transform.localScale = _initialScale * newScale;

        // 计算位置补偿
        Vector3 worldFootPosAfter = footPoint.position;
        transform.position += worldFootPosBefore - worldFootPosAfter;

        _currentScale = newScale;
    }

    // 可视化脚底中心（编辑器调试用）
    void OnDrawGizmosSelected()
    {
        if (footPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(footPoint.position, 0.05f);
        }
    }
}