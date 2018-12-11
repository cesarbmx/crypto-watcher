﻿using CryptoWatcher.Api.Requests;


namespace CryptoWatcher.Api.FakeRequests
{
    public static class AddIndicatorFakeRequest
    {
        public static AddIndicatorRequest GetFake_1()
        {
            return new AddIndicatorRequest
            {
                UserId = "johny.melavo",
                Name = "Hype",
                Description = "It identifies inmediate hypes within 24 Hrs in your portfolio",
                Formula = "C# formula"
            };
        }       
    }
}