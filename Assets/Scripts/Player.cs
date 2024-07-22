using UnityEngine;

[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
}
