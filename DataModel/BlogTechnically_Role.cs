//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogTechnically_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BlogTechnically_Role()
        {
            this.BlogTechnically_User = new HashSet<BlogTechnically_User>();
        }
    
        public int RoleId_PK { get; set; }
        public string RoleType { get; set; }
        public int PermissionId_FK { get; set; }
    
        public virtual BlogTechnically_Permission BlogTechnically_Permission { get; set; }
        public virtual BlogTechnically_Role BlogTechnically_Role1 { get; set; }
        public virtual BlogTechnically_Role BlogTechnically_Role2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogTechnically_User> BlogTechnically_User { get; set; }
    }
}
