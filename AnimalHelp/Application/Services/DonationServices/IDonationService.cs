﻿using AnimalHelp.Domain.Model.Donations;

namespace AnimalHelp.Application.Services.DonationServices;

public interface IDonationService
{
    public Donation AddDonation(string description, string from, bool isAnonymous, Domain.Model.Post? post);
}