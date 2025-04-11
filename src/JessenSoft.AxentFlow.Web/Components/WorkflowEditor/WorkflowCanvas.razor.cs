using JessenSoft.AxentFlow.Web.Components.WorkflowEditor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace JessenSoft.AxentFlow.Web.Components.WorkflowEditor
{
    /// <summary>
    /// Code-Behind für die WorkflowCanvas-Komponente.
    /// Beinhaltet Drag & Drop, Selektion, Platzierung & Properties.
    /// </summary>
    public partial class WorkflowCanvas : ComponentBase
    {
        [Inject]
        private WorkflowCanvasViewModel Vm { get; set; } = default!;

        private NodeDefinition? _draggedNode;
        private double _offsetX;
        private double _offsetY;

        private string? _pendingNodeType;
        protected string? PendingNodeType => _pendingNodeType;

        /// <summary>
        /// Wird beim Klicken auf „Hinzufügen“ in der Palette aufgerufen.
        /// </summary>
        protected void SetPendingNodeType(string type)
        {
            _pendingNodeType = type;
            Vm.ClearSelection();
        }

        /// <summary>
        /// Wird beim Klick auf das Canvas ausgelöst.
        /// Fügt ggf. einen neuen Knoten des gewählten Typs hinzu.
        /// </summary>
        protected void CanvasClick(MouseEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_pendingNodeType)) return;

            Vm.Nodes.Add(new NodeDefinition
            {
                Id = Guid.NewGuid().ToString(),
                Type = _pendingNodeType,
                Label = _pendingNodeType,
                PositionX = e.ClientX - _offsetX,
                PositionY = e.ClientY - _offsetY
            });

            _pendingNodeType = null;
        }

        /// <summary>
        /// Startet das Verschieben eines Knotens.
        /// </summary>
        protected void StartDrag(MouseEventArgs e, NodeDefinition node)
        {
            _draggedNode = node;
            _offsetX = e.ClientX - node.PositionX;
            _offsetY = e.ClientY - node.PositionY;
        }

        /// <summary>
        /// Bewegt den Knoten mit der Maus.
        /// </summary>
        protected void DragNode(MouseEventArgs e)
        {
            if (_draggedNode is null) return;

            Vm.UpdateNodePosition(_draggedNode, e.ClientX - _offsetX, e.ClientY - _offsetY);
            StateHasChanged();
        }

        /// <summary>
        /// Beendet das Verschieben.
        /// </summary>
        protected void EndDrag(MouseEventArgs e)
        {
            _draggedNode = null;
        }
    }
}
