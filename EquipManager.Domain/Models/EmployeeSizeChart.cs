﻿namespace EquipManager.Domain.Models;

public class EmployeeSizeChart : IDomainModel
{
    public int Id { get; set; }

    public int Cloth { get; set; }
    public int Headdress { get; set; }
    public int GazMask { get; set; }
    public int Respirator { get; set; }
    public int Sleeve { get; set; }
    public int Glove { get; set; }
    public int Shoes { get; set; }
}