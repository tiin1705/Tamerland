using UnityEngine;

public class PlayerStateRestorer : MonoBehaviour
{
    void Start()
    {
        // Lấy vị trí mới từ PlayerScript
        Vector3 newPosition = PlayerScript.Instance.GetNewPosition();

        // Đặt vị trí của nhân vật sau khi chuyển scene thành vị trí mới.
        transform.position = newPosition;
    }
}
