using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _spikeLayerMask;
    [SerializeField] private LayerMask _coinLayerMask;
    [SerializeField] private LayerMask _exitLayerMask;


    [SerializeField] private PlayerStatusController _playerStatusController;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_spikeLayerMask.ExistLayerByLayerMask(other.gameObject.layer))
        {
            _playerStatusController.DamagePlayer(5);
        }

        if (_coinLayerMask.ExistLayerByLayerMask(other.gameObject.layer))
        {
            _playerStatusController.AddScore(1);
            Destroy(other.gameObject);
        }

        if (_exitLayerMask.ExistLayerByLayerMask(other.gameObject.layer))
        {
            GameController.Instance.ChangeLevel();
        }
    }
}
