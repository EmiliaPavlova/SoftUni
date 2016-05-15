//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1.EFMappings
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsersGame
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersGame()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int CharacterId { get; set; }
        public int Level { get; set; }
        public System.DateTime JoinedOn { get; set; }
        public decimal Cash { get; set; }
    
        public virtual Character Character { get; set; }
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
