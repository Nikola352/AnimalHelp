﻿using AnimalHelp.Domain.RepositoryInterfaces;
using AnimalHelp.Repositories;
using AnimalHelp.Repositories.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnimalHelp.HostBuilders;

public static class AddRepositoriesHostBuilderExtensions
{
    public static IHostBuilder AddRepositories(this IHostBuilder host)
    {
        host.ConfigureServices(services =>
        {
            services.AddSingleton<IMemberRepository, MemberRepository>(_ =>
                new MemberRepository(Constants.MemberFilePath, Constants.UserIdFilePath));
            services.AddSingleton<IVolunteerRepository, VolunteerRepository>(_ =>
                new VolunteerRepository(Constants.VolunteerFilePath, Constants.UserIdFilePath));
            services.AddSingleton<IAdminRepository, AdminRepository>(_ =>
                new AdminRepository(Constants.AdminFilePath, Constants.AdminIdFilePath));
            services.AddSingleton<IPostRepository, PostRepository>(_ =>
                new PostRepository(Constants.PostFilePath, Constants.PostIdFilePath));
            services.AddSingleton<IDonationRepository, DonationRepository>(_ =>
                new DonationRepository(Constants.DonationFilePath, Constants.DonationIdFilePath));
            services.AddSingleton<IAdoptionCentreRepository, AdoptionCentreRepository>(_ =>
                new AdoptionCentreRepository(Constants.AdoptionCentreFilePath, Constants.AdoptionCentreIdFilePath));
            services.AddSingleton<IAdoptionRepository, AdoptionRepository>(_ =>
                new AdoptionRepository(Constants.AdoptionFilePath, Constants.AdoptionIdFilePath));
            services.AddSingleton<IAdoptionRequestRepository, AdoptionRequestRepository>(_ =>
                new AdoptionRequestRepository(Constants.AdoptionRequestFilePath, Constants.AdoptionRequestIdFilePath));
            services.AddSingleton<IAnimalRepository, AnimalRepository>(_ =>
                new AnimalRepository(Constants.AnimalsFilePath, Constants.AnimalsIdFilePath));
            services.AddSingleton<IVolunteeringApplicationRepository, VolunteeringApplicationRepository>(_ =>
                new VolunteeringApplicationRepository(Constants.VolunteeringApplicationFilePath, Constants.VolunteeringApplicationIdFilePath));
            services.AddSingleton<IVoteRepository, VoteRepository>(_ =>
                new VoteRepository(Constants.VoteFilePath, Constants.VoteIdFilePath));
            services.AddSingleton<ITransactionRepository, TransactionRepository>(_ =>
                new TransactionRepository(Constants.TransactionFilePath));
            services.AddSingleton<IBlackListProposalRepository, BlackListProposalRepository>(_ =>
                new BlackListProposalRepository(Constants.BlackListProposalFilePath, Constants.BlackListProposalIdFilePath));
        });

        return host;
    }
}