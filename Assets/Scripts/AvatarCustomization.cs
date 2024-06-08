using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro 사용을 위한 네임스페이스

namespace YourNamespace
{
    public class AvatarCustomization : MonoBehaviour
    {
        public TMP_Dropdown heightDropdown; // TMP_Dropdown으로 변경
        public TMP_Dropdown weightDropdown; // TMP_Dropdown으로 변경
        public Button applyButton;

        public Transform avatar; // 아바타의 트랜스폼
        public FaceMapper faceMapper; // FaceMapper 스크립트

        private float baseHeight = 1.75f; // 기본 키 (단위: meter)
        private float baseWeight = 70f; // 기본 몸무게 (단위: kg)

        void Start()
        {
            applyButton.onClick.AddListener(ApplyCustomization);
        }

        void ApplyCustomization()
        {
            float height = float.Parse(heightDropdown.options[heightDropdown.value].text) / 100f; // cm to meter
            float weight = float.Parse(weightDropdown.options[weightDropdown.value].text);

            float heightScale = height / baseHeight;
            float weightScale = weight / baseWeight;

            // 아바타의 키 조절
            Vector3 newScale = avatar.localScale;
            newScale.y = heightScale;
            avatar.localScale = newScale;

            // 아바타의 몸무게 조절 (몸 전체의 스케일을 조절하는 예시)
            avatar.localScale = new Vector3(weightScale, avatar.localScale.y, weightScale);

            // 얼굴의 위치와 스케일 업데이트
            faceMapper.UpdateFacePositionAndScale(heightScale, weightScale);
        }
    }
}
