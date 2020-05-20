using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSeek : MonoBehaviour
{
    public Transform target1, target2, target3;
    public float force = 5f;

    ParticleSystem ps;

    void Start()
    {
      ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
      ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
      ps.GetParticles(particles);

      for (int i = 0; i < particles.Length; i++)
      {
        ParticleSystem.Particle p = particles[i];
        Vector3 direction1 = (target1.position - p.position).normalized;
        Vector3 direction2 = (target2.position - p.position).normalized;
        Vector3 direction3 = (target3.position - p.position).normalized;
        Vector3 seekForce1 = direction1 * force * Time.deltaTime;
        Vector3 seekForce2 = direction2 * force * Time.deltaTime;
        Vector3 seekForce3 = direction3 * force * Time.deltaTime;
        p.velocity = seekForce1;
        particles[i] = p;
      }

      ps.SetParticles(particles, particles.Length);
    }
}
