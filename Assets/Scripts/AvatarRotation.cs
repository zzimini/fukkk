using UnityEngine;

namespace YourNamespace
{
    public class AvatarRotation : MonoBehaviour
    {
        public float rotationSpeed = 100f; // 회전 속도
        public GameObject faceModel; // 얼굴 모델
        public FaceMapper faceMapper; // FaceMapper 스크립트

        void Update()
        {
            // 좌우 화살표 키 입력 받아서 아바타 회전
            float horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput != 0)
            {
                float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount);

                // 얼굴 모델 위치와 회전 업데이트
                if (faceMapper != null)
                {
                    faceMapper.UpdateFacePositionAndRotation();
                }
            }
        }
    }
}
