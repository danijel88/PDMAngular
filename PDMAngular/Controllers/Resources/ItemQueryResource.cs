using PDMAngular.Core.Models;

namespace PDMAngular.Controllers.Resources
{
    public class ItemQueryResource
    {
        public int? ItemTypeId { get; set; }

        public int? MachineTypeId { get; set; }

        public string InternalCode { get; set; }

        public Status? Status { get; set; }

        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }
    }
}
