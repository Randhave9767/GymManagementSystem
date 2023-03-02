using System;
using System.Collections.Generic;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? MobileNo { get; set; }

    public virtual ICollection<Member> Members { get; } = new List<Member>();

    public virtual ICollection<Trainer> Trainers { get; } = new List<Trainer>();
}


