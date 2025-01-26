using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public float sensitivity = 500f; // 마우스 민감도
    public bool isJumping = false; // 점프 중인지 상태 플래그

    void Update()
    {
        // 마우스 입력이 화면의 상단 절반에서만 받도록 조건 수정
        if (Input.GetMouseButton(0) && Input.mousePosition.y > Screen.height / 2 && !isJumping)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // 마우스 X축 입력에 따른 회전 속도 계산
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; // 마우스 Y축 입력에 따른 회전 속도 계산

            transform.Rotate(Vector3.up, mouseX); // Y축을 기준으로 좌우 회전
            float rotationX = transform.localEulerAngles.x - mouseY; // X축 회전 계산
            rotationX = Mathf.Clamp(rotationX < 180 ? rotationX : rotationX - 360, -30f, 35f); // X축 회전을 -30도에서 35도 사이로 제한
            transform.localEulerAngles = new Vector3(rotationX, transform.localEulerAngles.y, 0); // 제한된 각도로 회전 적용
        }
    }

    // 외부에서 호출하여 점프 상태를 설정할 수 있는 메서드
    public void SetJumping(bool state)
    {
        isJumping = state; // 점프 상태를 설정
    }
}
