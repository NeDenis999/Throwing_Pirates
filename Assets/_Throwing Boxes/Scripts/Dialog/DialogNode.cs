using System;
using System.Collections;
using System.Collections.Generic;

namespace Throwing_Boxes
{
    [Serializable]
    public class DialogNode
    {
        public string Name;
        public List<int> NextIds { get; set; }
    }
}