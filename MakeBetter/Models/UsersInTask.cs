//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MakeBetter.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersInTask
    {
        public long UsersInTaskId { get; set; }
        public Nullable<System.Guid> TaskId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<bool> AllowedByOwner { get; set; }
        public Nullable<byte> Rating { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> FinalHelperAgreement { get; set; }
    
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
