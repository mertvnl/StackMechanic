using CustomEventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stacker : MonoBehaviour, IStacker
{
    [field: SerializeField] public Transform StackHolder { get; set; }
    [field: SerializeField] public Transform FollowTarget { get; set; }
    public List<IStackable> Stacks { get; set; } = new List<IStackable>();

    private const float Z_OFFSET = 1f;

    private void OnEnable()
    {
        Events.OnObstacleCollision.AddListener(Unstack);
    }

    private void OnDisable()
    {
        Events.OnObstacleCollision.RemoveListener(Unstack);
    }

    private void Update()
    {
        HandleStackMovement();
    }

    public void Stack(IStackable stackable)
    {
        if (Stacks.Contains(stackable)) return;

        Stacks.Add(stackable);
        stackable.transform.SetParent(StackHolder);

        HandleStackScale();
    }

    public void Unstack(IStackable stackable)
    {
        if (!Stacks.Contains(stackable)) return;

        int stackIndex = GetStackIndex(stackable);

        for (int i = stackIndex; i < Stacks.Count; i++)
        {
            Stacks[i].OnUnstacked();
            Stacks.Remove(Stacks[i]);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        IStackable stackable = other.GetComponent<IStackable>();

        if (stackable != null)
        {
            Stack(stackable);
        }
    }

    private int GetStackIndex(IStackable stack)
    {
        int index = -1;

        for (int i = 0; i < Stacks.Count; i++)
        {
            if (Stacks[i] == stack)
            {
                index = i;
                break;
            }
        }

        return index;
    }

    public void HandleStackMovement()
    {
        if (Stacks.Count <= 0) return;

        for (int i = 0; i < Stacks.Count; i++)
        {
            if (i - 1 < 0)
                Stacks[i].transform.position = Vector3.Lerp(Stacks[i].transform.position, FollowTarget.position, Time.deltaTime * 15);
            else
                Stacks[i].transform.position = Vector3.Lerp(Stacks[i].transform.position, Stacks[i - 1].transform.position + Vector3.forward * Z_OFFSET, Time.deltaTime * 15);
        }
    }

    private void HandleStackScale()
    {
        StartCoroutine(HandleStackScaleCo());
    }

    private IEnumerator HandleStackScaleCo()
    {
        //Copying list here to avoid out of range issues on obstacle collisions
        IStackable[] tempArray = Stacks.ToArray();

        for (int i = tempArray.Length - 1; i >= 0; i--)
        {
            tempArray[i].OnStacked();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
