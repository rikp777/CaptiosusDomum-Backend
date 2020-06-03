using Api.Api.Controllers;
using Api.Api.EntityModels.User;
using Api.Dal;
using Api.Dal.Context;
using Api.Dal.Interface;
using Api.Logic;
using Api.Logic.Interfaces;
using Api.Logic.Services.User;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Logic.NUnitTest
{
    public class HueServiceTest
    {

        IUserContext _userContext;
        ILocalHueClient _client;

        //RepositoryContext(DbContextOptionsBuilder<RepositoryContext>) builder;

        //[SetUp]
        //public void Setup()
        //{
        //    builder = new RepositoryContext(DbContextOptionsBuilder<RepositoryContext>());
        //    builder.UseInMemoryDatabase(databaseName: "RepositoryDBInMemory");

        //    var dbContextOptions = builder.Options;

        //    //dit is opbouw van database waar ik niet uit kom. Hier moet iig de builder
        //    //context worden meegegeven
        //    _userContext = new UserContext(builder);


        //    //hier een regel voor het leeggooien van memory database
        //}

        //[Test]
        //public async Task<string> RegisterHueBridgeTestSucceed()
        //{
        //    //arrange
        //    string hueBridgeIp = "192.168.32.52";
        //    //voor testen handig om bij de code deze stap erbuiten te doen
        //    //idem voor het assignen van de waarde van huebridgeip of iig instantieren
        //    _client = new LocalHueClient(hueBridgeIp)


        //    //act



        //    //assert
        //}
    }
}
