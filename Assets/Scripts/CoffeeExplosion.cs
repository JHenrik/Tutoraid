/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeExplosion : MonoBehaviour 
{
	public LayerMask m_CharacterMask;
	public float m_MaxDamage = 100f;
	public float m_ExplosionForce = 100f;
	public float m_MaxLifeTime = 3f;
	public float m_ExplosionRadius = 5f;

	private void start()
	{
		Destroy (gameObject, m_MaxLifeTime);
	}

	private void OnTriggerEnter(Collider2D other)
	{
		Collider[] colliders = Physics.OverlapCapsule (transform.position, m_ExplosionRadius, m_CharacterMask);

		for(int i = 0; i < colliders.Length; i++)
		{
			Rigidbody2D targetRigidbody2D = colliders [i].GetComponent<Rigidbody2D> ();

			if (!targetRigidbody2D)
				continue;

			//targetRigidbody2D.AddExplosionForce (m_ExplosionForce, transform.position, m_ExplosionRadius);
			EnemyHealth targetHealth = targetRigidbody2D.GetComponent<EnemyHealth> ();

			if(!targetHealth)
				continue;
			float damage = CalculateDamage(targetRigidbody2D.position);

			targetHealth .TakeDamage(damage);
		}
	}

	private float CalculateDamage(Vector2 targetPosition)
	{
		Vector3 explosionToTarget = targetPosition - transform.position;
		float explosionDistance = explosionToTarget.magnitude;
		float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;
		float damage = relativeDistance * m_MaxDamage;
		return damage;
	}
}
*/