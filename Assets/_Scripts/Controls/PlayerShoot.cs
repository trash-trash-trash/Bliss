using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ParticleSystem part;
    
    void Start()
    {
        PlayerControls.Instance.AnnounceLeftClick += Shoot;
    }

    private void Shoot(bool input)
    {
        if(input)
            part.Play();
        else 
            part.Stop();
    }
    
}
