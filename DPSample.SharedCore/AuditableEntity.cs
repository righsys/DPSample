using DPSample.SharedCore.Interfaces;

namespace DPSample.SharedCore
{
    public class AuditableEntity : EntityBase<int>, IAggregateRoot
    {
        public string CreatedBy { get; set; }
        public DateTime? CreationTime { get; set; }
        public string LastModifiedBy { get; set; } = String.Empty;
        public DateTime? LastModificationTime { get; set; } = null;
    }
}