using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShipsInSpaceUI
{
    public abstract class BaseUi
    {
        protected GameObject _panel;

        public BaseUi(GameObject panel) => _panel = panel;

        public abstract void Execute();
        public abstract void Cancel();

    }
}
