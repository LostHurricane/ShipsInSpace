using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShipsInSpaceUI
{
    [Serializable]
    public struct PanelProperty
    {
        public StateUI Window;
        public GameObject GameObject;
        public UIBehaviour[] Components;
    }
}
