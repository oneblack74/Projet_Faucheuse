//Script de Clément

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe pour le path des ennemies
public class EnnemyPath : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] path;
    [SerializeField] private float damageOnPlayerCollision = 10;
    [SerializeField] private float timeBetweenHit = 1;
    [SerializeField] private Sprite[] sprite;
    private SpriteRenderer image;
    private bool hasDmgPlayer = false;

    private Transform target;
    private int dest = 0;

    void Start()
    {
        target = path[0];
        image = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            Vector3 direction = target.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            //Si on atteint quasiment la dest, on change de target
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                dest = (dest + 1) % path.Length;
                target = path[dest];
            }
            
            // modifier l'image (droite ou gauche)
            if (target.position.x >= transform.position.x)
            {
                image.sprite = sprite[0];
            }
            else
            {
                image.sprite = sprite[1];
            }
        }
    }

    //Méthode pour les collision entre le joueur et l'ennemi (on met des dégâts au joueur et on rentre dans une sorte d'invibilité seulement avec cet ennemie)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !(hasDmgPlayer))
        {
            PlayerHealth life = collision.transform.GetComponent<PlayerHealth>();
            life.removeHealth(damageOnPlayerCollision);
            hasDmgPlayer = true;
            StartCoroutine(cantDmgPlayer());
        }
    }

    //Le joueur ne peut pas se faire retoucher pendant timeBetweenHit secondes par le meme ennemie
    public IEnumerator cantDmgPlayer()
    {
        yield return new WaitForSeconds(timeBetweenHit);
        hasDmgPlayer = false;
    }

}
