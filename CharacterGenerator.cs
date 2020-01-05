using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActressMas;
using UnityStandardAssets.Characters.ThirdPerson;
using Unity.Jobs;
using System.Threading;

public class Env
{
    public MazeGenerator mazeRef;
    public Env(MazeGenerator maze) : base()
    {
        mazeRef = maze;
    }
    public TurnBasedEnvironment env = new TurnBasedEnvironment(0, 10);
    public void envstart()
    {
        int finished = 0;
        System.Random rand = new System.Random();
        List<string> history = new List<string> { };
        for (int i = 0; i < 5; i++)
        {
            int line = rand.Next(mazeRef.mazeRows);
            int col = rand.Next(mazeRef.mazeCols);

            var explorerAgent = new Actor(mazeRef.mazeCells,line,col, finished, history);

            env.Add(explorerAgent, "A" + i);

        }
        Debug.Log("Starting environment.");
        env.Start();
        Debug.Log("History - " + history.Count);
    }
  
}
public class CharacterGenerator : MonoBehaviour
{
    public MazeGenerator maze;

    public List<GameObject> avatars;

    public GameObject model;

    private Thread thr;


    // Start is called before the first frame update
    void Start()
    {

        // Creating object of ExThread class 
        Env obj = new Env(maze);

        // Creating thread 
        // Using thread class 
        obj.envstart();
        for (int i = 0; i < 1   ; i++)
        {

            avatars.Add(Instantiate(model, new Vector3(9    , -2, 0), Quaternion.identity));
            avatars[i].transform.localScale = new Vector3(4, 4, 4);
            //  avatars[i] = gameObject.AddComponent(typeof(AICharacterControl)) as AICharacterControl;
            //  avatars[i].transform.position.Set(0, 9 + i, 0);
        }
        Debug.Log("It works.");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
