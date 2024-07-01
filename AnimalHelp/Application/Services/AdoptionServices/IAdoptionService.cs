﻿using AnimalHelp.Domain.Model;
using System.Collections.Generic;

namespace AnimalHelp.Application.Services.AdoptionServices;

public interface IAdoptionService
{
    public List<Adoption> GetAll();

    public Adoption? GetById(string id);

    public Adoption AddAdoption(AdoptionType type, bool isActive, Domain.Model.Post? post, string userId);

    public Adoption UpdateAdoption(Adoption adoption);

    public void DeleteAdoption(string id);
    public List<Adoption> GetByUserId(string id);
    public List<Adoption> GetByPostId(string id);
    public List<Adoption> GetByType(AdoptionType type);
    public List<Adoption> GetActive();

    public void RateAnimal(string id, int rating);
    public void RateMember(string id, int rating);
}