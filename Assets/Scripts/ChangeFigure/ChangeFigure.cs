using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChangeFigure
{
    public class ChangeFigure : MonoBehaviour
    {
        public void Giraffe()
        {
            SceneManager.LoadScene(2);
        }

        public void Crocodile()
        {
            SceneManager.LoadScene(3);
        }
    }
}
