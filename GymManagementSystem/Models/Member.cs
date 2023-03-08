using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models;

public partial class Member
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? TrainerId { get; set; }

    public int? MembershipId { get; set; }

    public DateTime? JoinDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual MembershipType? Membership { get; set; }

    public virtual Trainer? Trainer { get; set; }

    public virtual User? User { get; set; }
}
