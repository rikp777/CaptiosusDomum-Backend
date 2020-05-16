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
using System.Threading.Tasks;

namespace Test.Logic.NUnitTest
{
    public class Tests
    {

        private AppSettings _appSettings;
        UserService _userService;
        IUserContext _userContext;
        IOptions<AppSettings> appSettings;

        RepositoryContext(DbContextOptionsBuilder<RepositoryContext>) builder;

        [SetUp]
        public void Setup()
        {
            builder = new RepositoryContext(DbContextOptionsBuilder<RepositoryContext>());
            builder.UseInMemoryDatabase(databaseName: "RepositoryDBInMemory");

            var dbContextOptions = builder.Options;

            //dit is opbouw van database waar ik niet uit kom. Hier moet iig de builder
            //context worden meegegeven
            _userContext = new UserContext(builder);
            //snap niet waarom dit niet werkt
            _appSettings = appSettings.Value;
            _userService = new UserService(_appSettings, _userContext);

            //hier een regel voor het leeggooien van memory database
        }

        [Test]
        public async Task<User> RegisterTestAsyncSucceed()
        {
            //arrange
            string email = "test@gmail.com";
            string password = "password1";


            User result;
            var expected = new User(email, password, email);
            //act

            result = await _userService.Register(email, password);

            //assert
            Assert.AreEqual(expected.email, result.email);
            Assert.AreEqual(expected.password, result.password);
            Assert.AreEqual(expected.username, result.username);
        }

        [Test]
        public async Task<User> RegisterTestAsyncAlreadyExisting()
        {
            //arrange
            string email = "test@gmail.com";
            string password = "password1";


            User result;
            var expected = new User(email, password, email);
            //act

            result = await _userService.Register(email, password);

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task<User> AuthenticateTestAsyncSucceed()
        {
            //arrange
            string username = "test@gmail.com";
            string password = "password1";

            User result;
            //blah blah veranderen hier naar de waarde die het token maakt.
            //weet niet zo goed hoe een token eruit ziet en of deze altijd verschilt
            var expected = new User(username, "blah blah");

            //act
            result = await _userService.Authenticate(username, password);

            //assert
            Assert.AreEqual(expected.username, result.username);
            Assert.AreEqual(expected.Token, result.Token);
        }

        [Test]
        public async Task<User> AuthenticateTestAsyncUserNotFound()
        {
            //arrange
            string username = "testnietaanwezig@gmail.com";
            string password = "password1";

            User result;
            //blah blah veranderen hier naar de waarde die het token maakt.
            //weet niet zo goed hoe een token eruit ziet en of deze altijd verschilt
            var expected = new User(username, "blah blah");

            //act
            result = await _userService.Authenticate(username, password);

            //assert
            Assert.IsNull(result);
        }


        [Test]
        public async Task<User> AuthenticateTestAsyncIncorrectPassword()
        {
            //arrange
            string username = "test@gmail.com";
            string password = "passwordwrong";

            User result;
            //blah blah veranderen hier naar de waarde die het token maakt.
            //weet niet zo goed hoe een token eruit ziet en of deze altijd verschilt
            var expected = new User(username, "blah blah");

            //act
            result = await _userService.Authenticate(username, password);

            //assert
            Assert.IsNull(result);
        }
    }
}
