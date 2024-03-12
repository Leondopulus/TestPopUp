using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] private Shape[] shapes;

    public Shape[] GetShapes => shapes;
}
