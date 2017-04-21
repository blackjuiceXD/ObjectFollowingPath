using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementPath : MonoBehaviour
{

    public PathTypes PathType; //Indicates type of path (Linear or Looping)
   // public int movementDirection = 1; //1 clockwise/forward || -1 counter clockwise/backwards
   // public int movingTo = 0; //used to identify point in PathSequence we are moving to
    public Transform[] PathSequence; //Array of all points in path

    //types of movement paths..
    public enum PathTypes
    {
        Linear,
        Loop
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //OnDraw will draw lines between our points in the Unity Editor
    //these lines will allow us to easily see path that our moving object will follow in the game
    public void OnDrawGizmos()
    {
        //Make sure that your sequence has points in it 
        //and that there are at least two points to constitute a path
        if (PathSequence == null || PathSequence.Length < 2)
        {
            return; //Exits OnDrawGizmos if no lines is needed
        }

        //Loop though all of the points in the sequence of points
        for (var i = 1; i < PathSequence.Length; i++)
        {
            //draw a line between the points
            Gizmos.DrawLine(PathSequence[i -1].position, PathSequence[i].position);
        }

        //if your path loops back to the begining when it reaches the end
        if (PathType == PathTypes.Loop)
        {
            //draw a line from last point to the first point in the sequence
            Gizmos.DrawLine(PathSequence[0].position, PathSequence[PathSequence.Length -1].position);
        }
    }

    //GetNextPathPoint() returns the transform componet of the next point in our path
    //FollowPath.cs script will inturn move the object it is on to that point in the game
    //public IEnumerator<Transform> GetNextPathPoint()
    //{
    //    //makes sure that your sequence has points in it
    //    //and that there at least two points to constitute a path

    //    if (PathSequence == null || PathSequence.Length < 1)
    //    {
    //        yield break; //exits the coroutine sequence length check fails
    //    }

    //    while (true) //does not infinite loop due to yield return!!
    //    {
    //        //Return the current point in PathSequence
    //        //and wait for the next cell of enumerator (prevents infinite loop)
    //        yield return PathSequence[movingTo];

    //        //If Linear path move from start to end then end to start then repeat
    //        if (PathType == PathTypes.Linear)
    //        {
    //           //If you are at the begining of the path
    //            if (movingTo <= 0)
    //            {
    //                movementDirection = 1; //set to 1 to move forward
    //            }

    //            else if (movingTo >= PathSequence.Length - 1)
    //            {
    //                movementDirection = -1; //set to -1 to move backwards
    //            }
    //        }

    //        movingTo = movingTo + movementDirection;
    //        //movementDirection should always be either 1 or -1
    //        //We add direction to the index to move us to the 
    //        //next point in the sequence of points in our path

    //        //For Looping path you must move the index when you reach
    //        //the begíning or end of the PathSequence to loop the path
    //        if(PathType == PathTypes.Loop)
    //        {
    //           //If you just moved past the last point(moving forward)
    //            if (movingTo >= PathSequence.Length)
    //            {
    //                movingTo = 0;
    //            }  
    //            //If you just moved past the first point(moving backwards)
    //            if (movingTo < 0)
    //            {
    //                //Set the next point to move to as the last point in sequence
    //                movingTo = PathSequence.Length - 1;
    //            }
    //        }
    //    }
    //}

}
