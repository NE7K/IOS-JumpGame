using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public VariableJoystick joy; // 조이스틱 입력을 받는 변수
    public CharacterController characterController; // 캐릭터 컨트롤러 컴포넌트
    public MouseMove mouseMoveScript; // 마우스 이동 스크립트
    public float moveSpeed = 5f; // 이동 속도
    public float jumpSpeed = 8f; // 점프 속도
    public float gravity = 20f; // 중력

    private Vector3 moveDirection = Vector3.zero; // 이동 방향
    private bool jumpPressed = false; // 점프 버튼이 눌렸는지 확인하는 변수

    void Start()
    {
        Application.targetFrameRate = 120; // 프레임 레이트를 120으로 설정
    }

    void Update()
    {
        // 캐릭터가 땅에 있는지 확인
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(joy.Horizontal, 0, joy.Vertical) * moveSpeed; // 조이스틱 입력에 따라 이동 방향 설정
            moveDirection = transform.TransformDirection(moveDirection); // 월드 좌표로 변환

            if (jumpPressed)
            {
                moveDirection.y = jumpSpeed; // 점프 속도 적용
                mouseMoveScript.SetJumping(true); // 마우스 이동 스크립트에 점프 상태 설정
                jumpPressed = false; // 점프 버튼 상태 초기화
            }
        }

        moveDirection.y -= gravity * Time.deltaTime; // 중력 적용
        characterController.Move(moveDirection * Time.deltaTime); // 캐릭터 이동

        if (characterController.isGrounded)
        {
            mouseMoveScript.SetJumping(false); // 땅에 있을 경우 점프 상태 해제
        }

        // 플레이어 Y 좌표 감시 및 재설정
        ResetPosition(); // Y 좌표가 음수일 경우 위치 재설정
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            jumpPressed = true; // 점프 버튼이 눌렸을 때 jumpPressed를 true로 설정
        }
    }

    // Y 좌표가 음수가 되면 위치를 재설정하는 함수
    void ResetPosition()
    {
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(0, 10, 0); // 플레이어 위치를 초기화
        }
    }
}
