using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models;

public partial class EquipmentRequest
{
    public int Id { get; set; }

    public string? EquipmentName { get; set; }

    public int? Quantity { get; set; }

    public string? RequestStatus { get; set; }

    public int? TrainerId { get; set; }

    public string? Reason { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
