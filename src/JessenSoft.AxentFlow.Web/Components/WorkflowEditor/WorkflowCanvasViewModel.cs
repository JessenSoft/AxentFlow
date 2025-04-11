using JessenSoft.AxentFlow.Web.Components.WorkflowEditor.Models;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;

namespace JessenSoft.AxentFlow.Web.Components.WorkflowEditor
{
    /// <summary>
    /// ViewModel für den WorkflowCanvas, das Zustand und Verhalten der Knoten verwaltet.
    /// </summary>
    public class WorkflowCanvasViewModel : ReactiveObject
    {
        /// <summary>
        /// Liste aller im Canvas enthaltenen Knoten.
        /// </summary>
        [Reactive]
        public List<NodeDefinition> Nodes { get; set; } = new()
        {
            new() { Id = "1", Type = "Start", Label = "Start", PositionX = 100, PositionY = 100 },
            new() { Id = "2", Type = "HttpRequest", Label = "HTTP", PositionX = 300, PositionY = 200 }
        };

        /// <summary>
        /// Der aktuell im Canvas ausgewählte Knoten.
        /// </summary>
        [Reactive]
        public NodeDefinition? SelectedNode { get; set; }

        /// <summary>
        /// Wählt einen bestimmten Knoten aus.
        /// </summary>
        /// <param name="node">Der zu selektierende Knoten.</param>
        public void SelectNode(NodeDefinition node) => SelectedNode = node;

        /// <summary>
        /// Hebt die Knoten-Auswahl auf.
        /// </summary>
        public void ClearSelection() => SelectedNode = null;

        /// <summary>
        /// Aktualisiert die Position eines Knotens im Canvas.
        /// </summary>
        /// <param name="node">Der zu verschiebende Knoten.</param>
        /// <param name="x">Die neue X-Position.</param>
        /// <param name="y">Die neue Y-Position.</param>
        public void UpdateNodePosition(NodeDefinition node, double x, double y)
        {
            node.PositionX = x;
            node.PositionY = y;
        }
    }
}
