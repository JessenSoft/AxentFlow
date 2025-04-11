namespace JessenSoft.AxentFlow.Web.Components.WorkflowEditor.Models
{
    public class NodeDefinition
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Type { get; set; } = "HttpRequest";
        public string Label { get; set; } = "Unbenannt";
        public double PositionX { get; set; }
        public double PositionY { get; set; }
    }
}
