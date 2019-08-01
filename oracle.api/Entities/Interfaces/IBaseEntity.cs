using System;

namespace oracle.api.Entities.Interfaces
{
    public interface IBaseEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        string UpdateBy { get; set; }
        DateTime? UpdateOn { get; set; }
        bool IsDelete { get; set; }
    }
}