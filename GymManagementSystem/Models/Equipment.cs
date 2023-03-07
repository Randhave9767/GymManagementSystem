using System;
using System.Collections.Generic;

namespace GymManagementSystem.Models;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string? EquipmentName { get; set; }

    public int? Quantity { get; set; }
}
