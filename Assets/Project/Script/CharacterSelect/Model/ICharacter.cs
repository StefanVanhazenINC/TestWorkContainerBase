using UnityEngine;

public interface ICharacter : IObject
{
    int Level { get; }
    Sprite Avatar { get; }
}