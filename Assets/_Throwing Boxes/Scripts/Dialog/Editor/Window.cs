using UnityEditor;
using UnityEngine;

namespace DialogEditor
{
    public sealed class Window : EditorWindow
    {
        public const float ConnectionLineThickness = 2f;
        public static readonly Vector2 DragHandleSize = new Vector2(10f, 10f);

        //private readonly Contex m_context = new Contex();

        Texture2D m_nodeTexture;
        Texture2D m_dragHandleTexture;
        GUIStyle m_nodeStyle;
        GUIStyle m_dragHandleStyle;

        void OnGUI()
        {
            if (Application.isPlaying)
            {
                //CenterMessage("Dialog editor is not available in play mode.");
                return;
            }
            
            /*if (m_context.Dialog == null)
            {
                    
                CenterMessage("No dialog selected.");
                return;
            }
            
            HandleEvents();
            
            DrawGrid(m_context.Dialog.EditorTransform, 20.0f, Color.gray.WithAlpha(0.3f));
            DrawGrid(m_context.Dialog.EditorTransform, 100.0f, Color.gray.WithAlpha(0.4f));

            DrawNodes();
            
            foreach (var node in m_context.Dialog.Nodes)
                if (node.Next != null) 
                {
                    foreach (var next in node.Next)
                    {
                        m_context.DrawConnection(node, next);
                        m_context.State.Paint();
                        if (GUI.changed)
                            Repaint();
                    }
                }*/
        }
    }
}