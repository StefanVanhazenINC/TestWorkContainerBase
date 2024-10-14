
using System;
using UnityEngine;

public interface ILevel : IObject
{
    string Description { get; }
    Sprite Icon { get; }
}
