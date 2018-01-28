using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingShika : MonoBehaviour
{
	Rigidbody m_Ridid;
	Transform m_Transform;
	GameObject m_Closer;
	Transform m_CloserTransform;
	float m_Time = 10.0f;


	float m_CollideCheckSpan = 0.3f;
	float m_CollideCheckSpanNow = 0.0f;

	// Use this for initialization
	void Start()
	{
		m_Transform = gameObject.transform;
		m_Ridid = this.gameObject.GetComponent<Rigidbody>();
		m_CollideCheckSpanNow = Random.Range( 0.0f,0.3f );
	}

	// Update is called once per frame
	void Update()
	{


		float distance = float.MaxValue;
		GameObject objCloser = null;
		m_CollideCheckSpanNow -= Time.deltaTime;

		if (m_CollideCheckSpanNow < 0.0f)
		{
			m_CollideCheckSpanNow = m_CollideCheckSpan;

			Collider[] colled = Physics.OverlapSphere(m_Transform.position, 30.0f);

			foreach (Collider contact in colled)
			{

				ggj2018.CharcterBehavior charaBehavior = contact.gameObject.GetComponent<ggj2018.CharcterBehavior>();

				if (charaBehavior != null)
				{
					float distanceNow = (m_Transform.position - contact.gameObject.transform.position).magnitude;
					if (distanceNow < distance)
					{
						distance = distanceNow;
						objCloser = contact.gameObject;
					}
				}
			}

			if (distance > 100.0f)
			{
				m_Closer = null;
				m_CloserTransform = null;
			}

			if (objCloser != null)
			{
				m_Closer = objCloser;
				m_CloserTransform = m_Closer.transform;
			}
		}


	}

	void FixedUpdate()
	{
		if (m_Closer != null && m_Time > 0.0f)
		{
			m_Transform.LookAt(m_CloserTransform, new Vector3(0.0f, 1.0f, 0.0f));

			m_Ridid.AddRelativeForce(0.0f, 0.0f, 40.0f);
			m_Time -= Time.deltaTime;

		}
	}


}