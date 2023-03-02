using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models;

public partial class Member
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? TrainerId { get; set; }

    public int? MembershipId { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? JoinDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime? ExpiryDate { get; set; }

    public virtual MembershipType? Membership { get; set; }

    public virtual Trainer? Trainer { get; set; }

    public virtual User? User { get; set; }
}
