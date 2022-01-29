using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackable : IComponent
{
    void OnStacked();

    void OnUnstacked();
}
