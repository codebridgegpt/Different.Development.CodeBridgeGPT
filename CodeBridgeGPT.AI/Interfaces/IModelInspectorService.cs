namespace CodeBridgePlatform.AI.Core.Interfaces
{
    public interface IModelInspectorService
    {
        public bool ClassExists(string className);
        public List<string> GetClassProperties(string className);
    }
}
