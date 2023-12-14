﻿using Microsoft.EntityFrameworkCore;
using WarThunderParody.DAL.Interfaces;
using WarThunderParody.Domain.Enum;
using WarThunderParody.Domain.Response;
using WarThunderParody.Domain.ViewModel.Nation;
using WarThunderParody.Service.Interfaces;

namespace WarThunderParody.Service.Implementations;

public class NationService : INationService
{
   private readonly IBaseRepository<Nation> _nationRepository;

    public NationService(IBaseRepository<Nation> nationRepository)
    {
        _nationRepository = nationRepository;
    }

    public async Task<IBaseResponse<Nation>> GetNation(int id)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var nation = await _nationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            baseResponse.Data = nation;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = $"[GetNation] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Nation>> Edit(int id, NationDBO model)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var nation = await _nationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            nation.Name = model.Name;
            await _nationRepository.Update(nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = $"[Edit] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<Nation>> GetNationByName(string name)
    {
        var baseResponse = new BaseResponse<Nation>();
        try
        {
            var nation = await _nationRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
            if (nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            baseResponse.Data = nation;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<Nation>()
            {
                Description = $"[GetNationByName] : {e.Message}"
            };
        }
    }

    public async Task<IBaseResponse<bool>> Create(NationDBO model)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var nation = new Nation()
            {
                Name = "dada"
            };
            var result = await _nationRepository.Create(nation);
            if (result == false)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            await _nationRepository.Delete(nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[CreateNation] : {e.Message}"
            };
        }
    }
    
    public async Task<IBaseResponse<bool>> DeleteNation(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var Nation = await _nationRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
            if (Nation is null)
            {
                baseResponse.Description = "Nation not found";
                baseResponse.StatusCode = StatusCode.NationNotFound;
                return baseResponse;
            }

            await _nationRepository.Delete(Nation);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteNation] : {e.Message}"
            };
        }
    }
    public async Task<IBaseResponse<IEnumerable<Nation>>> GetNations()
    {
        var baseResponse = new BaseResponse<IEnumerable<Nation>>();
        try
        {
            var categories = await _nationRepository.GetAll().ToListAsync();
            if (categories.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.NotFound;
                return baseResponse;
            }

            baseResponse.Data = categories;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Nation>>()
            {
                Description = $"[GetNations] : {e.Message}"
            };
        }
    }
}