using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
