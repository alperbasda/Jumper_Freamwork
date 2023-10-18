using Jumper.Domain.Enums;

namespace Jumper.CodeGenerator.BuilderBase.Helpers
{
    public static class EntityActionHelpers
    {
        public static string GetCqrsRequestFileName(this EntityAction action)
        {
            switch (action)
            {
                case EntityAction.Delete:
                case EntityAction.Update:
                case EntityAction.Create:
                    return "Command";
                default:
                    return "Query";
            }
        }

        public static string GetCqrsResponseFileName(this EntityAction action)
        {
            switch (action)
            {
                case EntityAction.Delete:
                case EntityAction.Update:
                case EntityAction.Create:
                    return "CommandResponse";
                default:
                    return "QueryResponse";
            }
        }
    }
}
