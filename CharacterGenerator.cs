using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActressMas;
using UnityStandardAssets.Characters.ThirdPerson;
using Unity.Jobs;
using System.Threading;

public struct Env : IJob
{
    public TurnBasedEnvironment env;


    public void Execute()
    {
        env = new TurnBasedEnvironment(0, 100);
        for (int i = 0; i < 5; i++)
        {
            var explorerAgent = new Actor();
            env.Add(explorerAgent, "A" + i);
            
        }
        Debug.Log("Starting environment.");
        env.Start();
    }
}

public class EnvThread
{
    public TurnBasedEnvironment env = new TurnBasedEnvironment(0, 100);
    public void envstart()
    {
        for (int i = 0; i < 5; i++)
        {
            var explorerAgent = new Actor();
            env.Add(explorerAgent, "A" + i);

        }
        Debug.Log("Starting environment.");
        env.Start();
    }
}
public class CharacterGenerator : MonoBehaviour
{
    public List<GameObject> avatars;

    public GameObject model;

    // Start is called before the first frame update
    void Start()
    {
        //Env env = new Env();

        // Creating object of ExThread class 
        EnvThread obj = new EnvThread();

        // Creating thread 
        // Using thread class 
        Thread thr = new Thread(new ThreadStart(obj.envstart));
        thr.Start();
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
