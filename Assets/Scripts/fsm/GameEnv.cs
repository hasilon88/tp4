using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameEnv
{

    // Singleton instance unique de la classe
    private static GameEnv instance;

    // Liste contenant tous les checkpoints du jeu
    private List<GameObject> checkpoints = new List<GameObject>();

    // Propri�t� publique pour acc�der aux checkpoints
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    // Propri�t� Singleton pour acc�der � l'instance unique de GameEnvironment
    public static GameEnv Singleton
    {

        get
        {

            // Si l'instance n'existe pas, on la cr�e
            if (instance == null)
            {

                // Initialisation de l'instance
                instance = new GameEnv();

                // R�cup�re tous les objets avec le tag "Checkpoint" et les ajoute � la liste checkpoints
                instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                // Trie la liste des checkpoints par nom pour garantir un ordre constant
                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList();
            }

            // Retourne l'instance unique de GameEnvironment
            return instance;
        }
    }
}