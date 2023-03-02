using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models;

public partial class MembershipType
{
    public int Id { get; set; }

    public string? MembershipName { get; set; }

    public string? Fee { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Member> Members { get; } = new List<Member>();
}
