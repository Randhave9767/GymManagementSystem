using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models;

public partial class Trainer
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? JoiningDate { get; set; }

    public string? Salary { get; set; }

    public virtual ICollection<Member> Members { get; } = new List<Member>();

    public virtual User? User { get; set; }
}
