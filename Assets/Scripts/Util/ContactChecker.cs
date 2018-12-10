using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactChecker : MonoBehaviour {

    private bool m_isContact;
    private List<Collider> m_collisions = new List<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
            m_isContact = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        m_isContact = true;
        if (!m_collisions.Contains(collision.collider))
        {
            m_collisions.Add(collision.collider);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isContact = false; }
    }

    public bool InContact()
    {
        return m_isContact;
    }
}