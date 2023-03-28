using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models;

public partial class Trainer
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime? JoiningDate { get; set; }

    public string? Salary { get; set; }

    public virtual ICollection<EquipmentRequest> EquipmentRequests { get; } = new List<EquipmentRequest>();

    public virtual ICollection<Member> Members { get; } = new List<Member>();

    public virtual User? User { get; set; }
}
