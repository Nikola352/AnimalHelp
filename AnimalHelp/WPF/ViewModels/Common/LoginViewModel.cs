﻿using AnimalHelp.Application.DTO;
using AnimalHelp.Application.Services.AdoptionCentre;
using AnimalHelp.Application.Stores;
using AnimalHelp.Application.UseCases.Authentication;
using AnimalHelp.Application.Utility.Navigation;
using AnimalHelp.Domain.Model;
using AnimalHelp.WPF.MVVM;
using AnimalHelp.WPF.ViewModels.Factories;
using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Input;

namespace AnimalHelp.WPF.ViewModels.Common
{
    public class LoginViewModel : ViewModelBase, INavigableDataContext
    {
        private string? _email;
        private SecureString? _password;
        private string? _errorMessage;

        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;
        public NavigationStore NavigationStore { get; }

        public ICommand LoginCommand { get; }
        public ICommand SwitchToRegisterCommand { get; }
        public ICommand GoBackCommand { get; }
        
        public LoginViewModel(ILoginService loginService, INavigationService navigationService, NavigationStore navigationStore, IAdoptionCentreService adoptionCentreService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
            NavigationStore = navigationStore;
            LoginCommand = new RelayCommand(Login!);
            SwitchToRegisterCommand = new RelayCommand(SwitchToRegister);
            GoBackCommand = new RelayCommand(GoBack);
        }

        public string Email
        {
            get => _email!;
            set => SetField(ref _email, value);
        }

        public SecureString Password
        {
            get => _password!;
            set => SetField(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage!;
            set => SetField(ref _errorMessage, value);
        }

        private void Login(object parameter)
        {
            ErrorMessage = "";
            string email = Email;
            string password = ConvertToUnsecureString(Password);
            LoginResult loginResult = _loginService.LogIn(email, password);

            //LoginFailed
            if (!loginResult.IsValidUser)
            {
                if (!loginResult.IsValidEmail)
                {
                    ErrorMessage = "User doesn't exist";
                }
                else
                {
                    ErrorMessage = "Incorrect password";
                }
            }
            else
            {
                switch (loginResult.UserType)
                {
                    case UserType.Admin:
                        _navigationService.Navigate(ViewType.Admin);
                        break;
                    case UserType.Volunteer:
                        _navigationService.Navigate(ViewType.VolounteerMenu);
                        break;
                    case UserType.Member:
                        _navigationService.Navigate(ViewType.MemberMenu);
                        break;
                    default:
                        throw new ArgumentException("No available window for current user type");
                }
            }
        }

        private void SwitchToRegister(object? parameter)
        {
            _navigationService.Navigate(ViewType.Register);
        }
        
        private void GoBack(object? obj)
        {
            _navigationService.Navigate(ViewType.Main);
        }

        // Helper method to convert SecureString to plain text
        private static string ConvertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
                return string.Empty;

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString)!;
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

    }
}