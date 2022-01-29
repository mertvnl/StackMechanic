using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStacker
{
    List<IStackable> Stacks { get; set; }
    Transform StackHolder { get; set; }
    Transform FollowTarget { get; set; }

    void Stack(IStackable stackable);

    void Unstack(IStackable stackable);

    void HandleStackMovement();
}
