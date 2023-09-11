using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

namespace Throwing_Boxes
{
    [CreateAssetMenu(fileName = "Dialog", menuName = "Configs/Dialog", order = 56)]
    public class Dialog : ScriptableObject, ISerializationCallbackReceiver
    {
        public List<DialogNode> RootNodes { get; private set; }

        [HideInInspector]
        public int NextUniqueId;

        //[HideInInspector]
        //public SimpleTransform2D EditorTransform = new SimpleTransform2D();
        
        [HideInInspector]
        public List<DialogNode> Nodes;
        
        public void OnBeforeSerialize()
        {
            if (Nodes != null)
            {
                foreach (var node in Nodes)
                {
                    if (node.NextIds != null)
                        node.NextIds.Clear();
                    else
                        node.NextIds = new List<int>();

                    /*if (node.Next != null)
                    {
                        foreach (var next in node.Next)
                            node.NextIds.Add(next.UniqueId);
                    }*/
                }
            }
        }

        public void OnAfterDeserialize()
        {
            throw new System.NotImplementedException();
        }
    }
}