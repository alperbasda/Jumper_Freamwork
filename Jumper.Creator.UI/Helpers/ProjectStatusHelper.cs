using Jumper.Domain.Enums;

namespace Jumper.Creator.UI.Helpers
{
    public static class ProjectStatusHelper
    {
        public static string GetMetronicColor(this ProjectStatus status)
        {
            switch (status) {
                case ProjectStatus.Preparing:
                    return "info";
                case ProjectStatus.WaitingGenerate:
                    return "danger";
                case ProjectStatus.Generating:
                    return "warning";
                case ProjectStatus.Downloadable:
                    return "success";
                default:
                    return "danger";
            }

        }
    }
}
