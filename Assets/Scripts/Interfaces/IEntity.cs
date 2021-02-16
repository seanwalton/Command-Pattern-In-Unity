using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity 
{
    //Defines the methods and properties each of our Entities should have

    Transform transform { get; }
}
