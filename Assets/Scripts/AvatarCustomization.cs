using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro ����� ���� ���ӽ����̽�

namespace YourNamespace
{
    public class AvatarCustomization : MonoBehaviour
    {
        public TMP_Dropdown heightDropdown; // TMP_Dropdown���� ����
        public TMP_Dropdown weightDropdown; // TMP_Dropdown���� ����
        public Button applyButton;

        public Transform avatar; // �ƹ�Ÿ�� Ʈ������
        public FaceMapper faceMapper; // FaceMapper ��ũ��Ʈ

        private float baseHeight = 1.75f; // �⺻ Ű (����: meter)
        private float baseWeight = 70f; // �⺻ ������ (����: kg)

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

            // �ƹ�Ÿ�� Ű ����
            Vector3 newScale = avatar.localScale;
            newScale.y = heightScale;
            avatar.localScale = newScale;

            // �ƹ�Ÿ�� ������ ���� (�� ��ü�� �������� �����ϴ� ����)
            avatar.localScale = new Vector3(weightScale, avatar.localScale.y, weightScale);

            // ���� ��ġ�� ������ ������Ʈ
            faceMapper.UpdateFacePositionAndScale(heightScale, weightScale);
        }
    }
}
