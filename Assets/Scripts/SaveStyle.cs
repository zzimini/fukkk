using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace YourNamespace
{
    public class SaveStyle : MonoBehaviour
    {
        public Button saveButton;
        public Camera mainCamera;
        public Rect captureRect;

        void Start()
        {
            saveButton.onClick.AddListener(CaptureAndSaveStyle);
        }

        void CaptureAndSaveStyle()
        {
            StartCoroutine(CaptureScreenshot());
        }

        private IEnumerator CaptureScreenshot()
        {
            yield return new WaitForEndOfFrame();

            RenderTexture rt = new RenderTexture((int)captureRect.width, (int)captureRect.height, 24);
            mainCamera.targetTexture = rt;
            Texture2D screenImage = new Texture2D((int)captureRect.width, (int)captureRect.height, TextureFormat.RGB24, false);

            mainCamera.Render();
            RenderTexture.active = rt;
            screenImage.ReadPixels(new Rect(0, 0, captureRect.width, captureRect.height), 0, 0);
            screenImage.Apply();

            mainCamera.targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);

            byte[] imageBytes = screenImage.EncodeToPNG();
            string filePath = Path.Combine(Application.persistentDataPath, "MyStyle_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
            File.WriteAllBytes(filePath, imageBytes);

            Debug.Log("Screenshot saved to: " + filePath);
        }
    }
}
