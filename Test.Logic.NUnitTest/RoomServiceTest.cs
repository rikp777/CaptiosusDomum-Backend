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
using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Test.Logic.NUnitTest
{
    public class RoomServiceTest
    {

        RoomService _roomService;
        IUserContext _userContext;

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

            _roomService = new RoomService(_userContext);

            //hier een regel voor het leeggooien van memory database
        }

        [Test]
        public async Task<Room> AddDeviceToRoomAsyncSucceed()
        {
            //arrange
            //Moet al een woonkamer aanwezig zijn in db
            string roomName = "Woonkamer";
            //Ben uitgegaan van dat er maar 1 tegelijk kan worden toegevoegd anders
            //gewoon de functie in een for loop aanroepen in de controller.
            string deviceid = "1234";
            string softwareversion = "V3.5.32";
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //eerste is deviceid, tweede is softwareversion, derde is, bouwjaar
            Device device = new Device(deviceid, softwareversion, date1);

            //date is voor nu nog datetime kan met DateTime.Date in de code alleen de datum pakken
            DateTime date2 = new DateTime(2008, 5, 1, 8, 30, 52);
            Room result;
            var expected = new Room(roomName, deviceid, softwareversion, date2);

            //act
            result = await _roomService.AddDeviceToRoom(device);

            //assert
            Assert.AreEqual(expected.deviceid, result.deviceid);
            Assert.AreEqual(expected.softwareversion, result.softwareversion);
            Assert.AreEqual(expected.Date, result.Date);
        }

        //hier moeten waardes komen voor als een field empty is.
        [Test]
        public async Task<Room> AddDeviceToRoomAsyncFieldEmpty()
        {
            //arrange
            //Moet al een woonkamer aanwezig zijn in db
            string roomName = "Woonkamer";
            //Ben uitgegaan van dat er maar 1 tegelijk kan worden toegevoegd anders
            //gewoon de functie in een for loop aanroepen in de controller.
            string deviceid = "1234";
            string softwareversion = "";
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //eerste is deviceid, tweede is softwareversion, derde is, bouwjaar
            Device device = new Device(deviceid, softwareversion, date1);

            //date is voor nu nog datetime kan met DateTime.Date in de code alleen de datum pakken
            DateTime date2 = new DateTime(2008, 5, 1, 8, 30, 52);
            Room result;
            var expected = new Room(roomName, deviceid, softwareversion, date2);

            //act
            result = await _roomService.AddDeviceToRoom(device);

            //assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task<Room> RemoveDeviceFromRoomAsyncSucceed()
        {
            //arrange
            //er wordt hier uitgegaan dat het element uit de lijst van devices wordt gehaald
            //dmv het device object niet door index van het form
            string deviceid = "1234";
            string softwareversion = "";
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //eerste is deviceid, tweede is softwareversion, derde is, bouwjaar
            Device removabledevice = new Device(deviceid, softwareversion, date1);

            List<Device> devicelist = new List<Device>();


            DateTime date2 = new DateTime(2009, 5, 1, 8, 30, 52);
            DateTime date3 = new DateTime(2007, 5, 1, 8, 30, 52);
            DateTime date4 = new DateTime(2006, 5, 1, 8, 30, 52);
            DateTime date5 = new DateTime(2005, 5, 1, 8, 30, 52);

            Device device1 = new Device("3456", "v2.11.14", date2);
            Device device2 = new Device("6753", "v5.15.34", date2);
            Device device3 = new Device("5166", "v1.1.2", date2);
            Device device4 = new Device("9845", "v3.1.3", date2);

            devicelist.add(removabledevice);
            devicelist.add(device1);
            devicelist.add(device2);
            devicelist.add(device3);
            devicelist.add(device4);

            List<Device> expectedlist = new List<Device>();
            expectedlist.add(device1);
            expectedlist.add(device2);
            expectedlist.add(device3);
            expectedlist.add(device4);


            string roomName = "Woonkamer";

            Room result;
            var expected = new Room(roomName, expectedlist);

            //act
            result = await _roomService.RemoveDeviceFromRoom(roomName, devicelist, removabledevice);

            //assert
            //Nog even met gijs naar kijken. Een lijst met daarin objecten is een lastige assert.
            Assert.Fail();
        }


        [Test]
        public async Task<Room> UpdateDeviceInRoomTestSucceed()
        {
            //arrange
            //Moet al een woonkamer aanwezig zijn in db
            string roomName = "Woonkamer";
            //Ben uitgegaan van dat er maar 1 tegelijk kan worden toegevoegd anders
            //gewoon de functie in een for loop aanroepen in de controller.
            string deviceid = "1234";
            string softwareversion = "V3.5.32";
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //eerste is deviceid, tweede is softwareversion, derde is, bouwjaar
            Device device = new Device(deviceid, softwareversion, date1);

            //date is voor nu nog datetime kan met DateTime.Date in de code alleen de datum pakken

            string softwareversionupdate = "v3.5.33";
            Device deviceupdate = new Device(device.deviceid, softwareversionupdate, device.date);


            Room result;
            var expected = new Room(roomName, deviceupdate);

            //act
            result = await _roomService.UpdateDeviceInRoom(roomName, device, deviceupdate);

            //assert
            Assert.AreEqual(expected.deviceid, result.deviceid);
            Assert.AreEqual(expected.softwareversion, result.softwareversion);
            Assert.AreEqual(expected.Date, result.Date);
        }

        [Test]
        public async Task<Room> UpdateDeviceInRoomTestFieldEmpty()
        {
            //arrange
            //Moet al een woonkamer aanwezig zijn in db
            string roomName = "Woonkamer";
            //Ben uitgegaan van dat er maar 1 tegelijk kan worden toegevoegd anders
            //gewoon de functie in een for loop aanroepen in de controller.
            string deviceid = "1234";
            string softwareversion = "V3.5.32";
            DateTime date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            //eerste is deviceid, tweede is softwareversion, derde is, bouwjaar
            Device device = new Device(deviceid, softwareversion, date1);

            //date is voor nu nog datetime kan met DateTime.Date in de code alleen de datum pakken

            string softwareversionupdate = "";
            Device deviceupdate = new Device(device.deviceid, softwareversionupdate, device.date);


            Room result;
            var expected = new Room(roomName, deviceupdate);

            //act
            result = await _roomService.UpdateDeviceInRoom(roomName, device, deviceupdate);

            //assert
            Assert.IsNull(result);
        }
    }
}
