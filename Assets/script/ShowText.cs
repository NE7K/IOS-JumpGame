using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Text text; // 화면에 첫 번째로 표시될 텍스트
    public Text text2; // 특정 조건에서 화면에 표시될 두 번째 텍스트
    public Transform targetTransform; // 텍스트가 나타날 위치를 판단하기 위한 대상 오브젝트의 Transform

    // 텍스트2를 표시할 위치를 저장하는 벡터
    private Vector3 triggerPosition = new Vector3(11, 5, -58);

    void Start()
    {
        // 게임 시작 시 첫 번째 텍스트를 활성화하고 4초 후 비활성화
        text.gameObject.SetActive(true);
        Invoke("HideText", 4);

        // 두 번째 텍스트는 게임 시작 시 비활성화 상태로 설정
        text2.gameObject.SetActive(false);
    }

    void Update()
    {
        // 매 프레임마다 targetTransform의 위치를 확인하여 특정 범위 내에 있으면 텍스트2를 활성화
        if (Vector3.Distance(targetTransform.position, triggerPosition) < 3.0f) // 3 이내에 위치해야 함
        {
            // 텍스트2가 현재 비활성화 상태인 경우만 활성화하고 3초 후 다시 비활성화
            if (!text2.gameObject.activeInHierarchy)
            {
                text2.gameObject.SetActive(true);
                Invoke("HideText2", 3);
            }
        }
    }

    void HideText()
    {
        text.gameObject.SetActive(false);
    }

    void HideText2()
    {
        text2.gameObject.SetActive(false);
    }
}
