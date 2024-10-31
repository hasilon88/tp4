using UnityEngine;
using UnityEngine.AI;

// Classe AI pour g�rer le comportement du NPC avec un syst�me d'�tats
public class AI : MonoBehaviour
{

    // Composants NavMeshAgent et Animator pour le mouvement et l'animation
    NavMeshAgent agent;      // R�f�rence � l'agent de navigation
    Animator anim;           // R�f�rence � l'animateur pour les animations du NPC
    State currentState;      // �tat actuel du NPC

    public Transform player; // R�f�rence au joueur pour interagir avec le NPC

    // Initialisation au d�marrage de la sc�ne
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();    // Initialisation de l'agent de navigation
        anim = GetComponent<Animator>();         // Initialisation de l'animateur
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = new Idle(gameObject, agent, anim, player); // Le NPC commence en �tat "Idle"
    }

    // Mise � jour � chaque frame pour traiter l'�tat actuel
    void Update()
    {
        currentState = currentState.Process(); // Mise � jour de l'�tat actuel du NPC
    }
}