using System;
using UnityEngine;

namespace Throwing_Boxes
{
    public class Bullet : MonoBehaviour
    {
        private float _damage;
        private PlayerModel _playerModel;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent<EnemyModel>(out var enemyModel))
            {
                foreach (var skill in _playerModel.DamageSkills)
                {
                    _damage = skill.ActivateResult(_damage, enemyModel, _playerModel);
                }
                
                enemyModel.Damage(_damage);
            }
        }
    }
}