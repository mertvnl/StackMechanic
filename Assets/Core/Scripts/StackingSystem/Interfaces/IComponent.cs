using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComponent
{
    Transform transform { get; }
    GameObject gameObject { get; }
}
