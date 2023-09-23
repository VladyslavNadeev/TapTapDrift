using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        private const float Delay = 0.5f;
    
        public Image Image;
        public float MoveUpSpeed = 20f;
        public float TimeStep = 0.03f;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            Image.rectTransform.anchoredPosition = Vector2.zero;
            gameObject.SetActive(true);
        }

        public void Hide() =>
            StartCoroutine(GoUp());

        private IEnumerator GoUp()
        {
            yield return new WaitForSeconds(Delay);
            
            while (Image.rectTransform.anchoredPosition.y < Image.rectTransform.rect.height)
            {
                MoveImageUp();
                yield return new WaitForSeconds(TimeStep);
            }

            gameObject.SetActive(false);
        }

        private void MoveImageUp()
        {
            RectTransform imageTransform = Image.rectTransform;
            Vector2 anchoredPosition = imageTransform.anchoredPosition;

            anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y + MoveUpSpeed);

            imageTransform.anchoredPosition = anchoredPosition;
        }
    }
}