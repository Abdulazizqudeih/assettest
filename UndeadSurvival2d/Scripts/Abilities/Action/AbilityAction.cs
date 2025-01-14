﻿using UnityEngine;
using Eincode.UndeadSurvival2d.Character;
using Eincode.UndeadSurvival2d.Manager;
using Eincode.UndeadSurvival2d.Abilities.Scriptable;

namespace Eincode.UndeadSurvival2d.Abilities.Action
{
    public class AbilityAction : MonoBehaviour
    {
        public AbilitySO abilitySO;

        private SpriteRenderer _sprite;
        private Collider2D _collider;

        private void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            _sprite.flipX = GameManager.Instance.GetPlayer().GetFlipX();
        }

        // Reacts to animation event
        public void OnAbilityActivation()
        {
            _collider.enabled = true;
        }

        // Reacts to animation event
        public void OnAbilityDeActivation()
        {
            _collider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if ((abilitySO.CollideWith.value & 1 << collision.transform.gameObject.layer) > 0)
            {
                if (collision.TryGetComponent<Damageable>(out var damageable))
                {
                    damageable.TakeDamage(abilitySO.Damage);
                }
            }
        }
    }
}


