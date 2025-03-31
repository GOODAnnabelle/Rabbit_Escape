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

    // �Ŵ�
    public void ScaleUp()
    {
        SetScale(_currentScale + scaleStep);
    }

    // ��С
    public void ScaleDown()
    {
        SetScale(_currentScale - scaleStep);
    }

    private void SetScale(float newScale)
    {
        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        // ����ŵ��������꣨����ǰ��
        Vector3 worldFootPosBefore = footPoint.position;

        // Ӧ��������
        transform.localScale = _initialScale * newScale;

        // ����λ�ò���
        Vector3 worldFootPosAfter = footPoint.position;
        transform.position += worldFootPosBefore - worldFootPosAfter;

        _currentScale = newScale;
    }

    // ���ӻ��ŵ����ģ��༭�������ã�
    void OnDrawGizmosSelected()
    {
        if (footPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(footPoint.position, 0.05f);
        }
    }
}