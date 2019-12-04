﻿namespace InvoiceSystem.DAL.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Roling Role { get; set; }
        public int RoleId { get; set; }
    }
}
