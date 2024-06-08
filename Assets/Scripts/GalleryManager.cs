using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

namespace YourNamespace
{
    public class GalleryManager : MonoBehaviour
    {
        public GameObject galleryPanel;
        public GameObject imageItemPrefab;

        void Awake()
        {
            if (galleryPanel == null)
            {
                Debug.LogError("Gallery Panel is not assigned.");
            }
        }

        public void LoadAndDisplayImages()
        {
            if (galleryPanel == null)
            {
                Debug.LogError("Gallery Panel is not assigned.");
                return;
            }

            foreach (Transform child in galleryPanel.transform)
            {
                Destroy(child.gameObject);
            }

            string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "MyStyle_*.png");
            foreach (string filePath in filePaths)
            {
                byte[] imageBytes = File.ReadAllBytes(filePath);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageBytes);

                GameObject newImageItem = Instantiate(imageItemPrefab, galleryPanel.transform);
                newImageItem.GetComponent<RawImage>().texture = texture;
            }
        }
    }
}
