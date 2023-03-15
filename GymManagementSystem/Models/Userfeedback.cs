using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models;

public partial class Userfeedback
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? Sub { get; set; }

    public string? Feedback { get; set; }

    public bool? Seen { get; set; }

    public virtual User? User { get; set; }
}
