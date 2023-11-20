﻿using Back_TechGuardians.Models;

namespace Back_TechGuardians.Repositorios.Interfaces
{
    public interface IEquipamentRepositorio
    {
        Task<List<EquipamentModel>> GetAll();
        Task<EquipamentModel> GetId(int id);
        Task<EquipamentModel> Add(EquipamentModel user);
        Task<EquipamentModel> Update(EquipamentModel user, int id);
        Task<bool> Delete(int id);
    }
}
