using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField, NotNull] private SceneContext _defaultSceneContext;

        private void Awake()
        {
            if (!FindObjectOfType<SceneContext>())
                Instantiate(_defaultSceneContext);

            Destroy(gameObject);
        }
    }
}