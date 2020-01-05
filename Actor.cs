using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ActressMas;
public class Actor : TurnBasedAgent
{

    public MazeCell[,] mazeCells;
    public int line, column, steps, terminatedAgents;
    public List<string> direction_History = new List<string> { };
    public List<int[]> position_History = new List<int[]> { };
    public Actor(MazeCell[,]  maze, int lin, int col, int finished,List<string> s) : base()
    {
        direction_History = s;
        line = lin;
        column = col;
        mazeCells = maze;
        steps = 0;
        terminatedAgents = finished;
    }
    public override void Setup()
    {
        Debug.Log("Starting " + Name);
    }
    public override void Act(Queue<Message> messages)
    {
        while (messages.Count > 0)
        {
            Message message = messages.Dequeue();
        }
        Debug.Log(Name + " - Steps - " + steps);

        if (steps < 20)
        {
           steps++;
            int i= -1;
            move(i);
        }
        else
        {

            Debug.Log("Terminated " + terminatedAgents);
            Stop();
           
        }
    }
    public void move(int direction)
    {
        string result = chooseDirection(direction);
        switch(result)
        {
            case "up":
            {
                line -= 1;
                break;
            }
            case "left":
            {
                column -= 1;
                break;
            }
            case "right":
            {
                column += 1;
                break;
            }
            case "down":
            {
                line += 1;
                break;
            }
        }
        direction_History.Add(result);
        position_History.Add(new int[] { line, column });
        Debug.Log(Name + " - Moving " + result);

    }
    public string chooseDirection(int direction)
    {
        System.Random rand = new System.Random();
        if (direction == -1)
        {
            direction = rand.Next(4);
        }
        while(!isValid(direction))
        {
            direction = rand.Next(4);
           // Debug.Log(Name + " stuck: " + direction + " " + line + " - " + column);

        }
        if (isValid(direction))
        {
            switch (direction)
            {
                case 0: return "up";
                case 1: return "right";
                case 2: return "down";
                case 3: return "left";
                default: return "blocked";
            }
        }
        else
            return "blocked";
    }
    public bool isValid(int direction)
    {
        if(direction == 0)
        {
            if (mazeCells[line, column].northWall == null || mazeCells[line, column].northWall.Equals(null))
                return true;
            else
                return false;
        } 
        else
        if (direction == 1)
        {
            if (mazeCells[line, column].eastWall == null || mazeCells[line, column].eastWall.Equals(null))
                return true;
            else
                return false;
        }
        else
        if (direction == 2)
        {
            if (mazeCells[line, column].southWall == null || mazeCells[line, column].southWall.Equals(null))
                return true;
            else
                return false;
        }
        else
        if (direction == 3)
        {
            if (mazeCells[line, column].westWall == null || mazeCells[line, column].westWall.Equals(null))
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
    

}
