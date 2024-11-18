using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField] public PlayerManager player;

    [SerializeField] public GameObject crosshair;

    [Range(0f, 50f)]
    [SerializeField] float size = 20f;

    [SerializeField] Color color = Color.white;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }


}
