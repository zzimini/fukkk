using UnityEngine;

namespace YourNamespace
{
    public class FaceMapper : MonoBehaviour
    {
        public Transform avatarHead;
        public GameObject faceModel;

        private Vector3 originalPositionOffset = new Vector3(0.02f, 1.672f, 0.065f);
        private Quaternion originalRotationOffset = Quaternion.Euler(0, 180, 0);

        void Start()
        {
            MapFaceToAvatar();
        }

        public void MapFaceToAvatar()
        {
            avatarHead.gameObject.SetActive(false);

            UpdateFacePositionAndRotation();
            faceModel.transform.localScale = avatarHead.localScale;
        }

        public void UpdateFacePositionAndScale(float heightScale, float weightScale)
        {
            faceModel.transform.localScale = new Vector3(weightScale, weightScale, weightScale);
            UpdateFacePositionAndRotation();
        }

        public void UpdateFacePositionAndRotation()
        {
            faceModel.transform.position = avatarHead.position + avatarHead.rotation * originalPositionOffset;
            faceModel.transform.rotation = avatarHead.rotation * originalRotationOffset;
        }
    }
}
