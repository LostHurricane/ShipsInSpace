using UnityEngine;

namespace ShipsInSpace
{
    public interface ISpriteRenderer: IView
    {
        SpriteRenderer SpriteRenderer { get; }

    }
}
