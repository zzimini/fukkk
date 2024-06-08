using UnityEngine;

namespace YourNamespace
{
    public class AvatarRotation : MonoBehaviour
    {
        public float rotationSpeed = 100f; // ȸ�� �ӵ�
        public GameObject faceModel; // �� ��
        public FaceMapper faceMapper; // FaceMapper ��ũ��Ʈ

        void Update()
        {
            // �¿� ȭ��ǥ Ű �Է� �޾Ƽ� �ƹ�Ÿ ȸ��
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput != 0)
            {
                float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount);

                // �� �� ��ġ�� ȸ�� ������Ʈ
                if (faceMapper != null)
                {
                    faceMapper.UpdateFacePositionAndRotation();
                }
            }
        }
    }
}
