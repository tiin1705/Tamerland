using UnityEngine;

public class LoopTimeController : MonoBehaviour
{
    public Animator animator; // Tham chiếu đến Animator Controller
    public AnimationClip animationClip; // Tham chiếu đến Animation Clip

    private float currentTime = 0f;
    public float loopTime = 5.0f; // Thời gian mỗi lần loop (giây)

    void Update()
    {
        currentTime += Time.deltaTime; // Tính thời gian đã trôi qua

        if (currentTime >= loopTime)
        {
            // Khi thời gian đã trôi qua vượt quá loopTime, chơi lại animation
            animator.Play(animationClip.name, 0, 0f); // 0f là thời điểm bắt đầu animation
            currentTime = 0f; // Reset currentTime
        }
    }
}