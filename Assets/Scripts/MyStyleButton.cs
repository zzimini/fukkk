using UnityEngine;
using UnityEngine.UI;

namespace YourNamespace
{
    public class MyStyleButton : MonoBehaviour
    {
        public Button myStyleButton;
        public GameObject galleryPanel;
        private bool isGalleryVisible = false;

        void Start()
        {
            myStyleButton.onClick.AddListener(ToggleGallery);
        }

        void ToggleGallery()
        {
            if (galleryPanel == null)
            {
                Debug.LogError("Gallery Panel is not assigned.");
                return;
            }

            isGalleryVisible = !isGalleryVisible;
            galleryPanel.SetActive(isGalleryVisible);

            if (isGalleryVisible)
            {
                GalleryManager galleryManager = galleryPanel.GetComponent<GalleryManager>();
                if (galleryManager != null)
                {
                    galleryManager.LoadAndDisplayImages();
                }
            }
        }
    }
}
