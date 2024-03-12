using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        [SerializeField] private PopUpController popUp;
        [SerializeField] private EnvironmentController environment;
        
        private void Start()
        {
            popUp.Init(environment.GetShapes);
            player.Init(environment.GetShapes);
        }

    }
}