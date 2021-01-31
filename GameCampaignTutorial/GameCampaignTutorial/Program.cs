using GameCampaignTutorial.Model.Concrete;
using GameCampaignTutorial.Model.Enum;
using GameCampaignTutorial.Service.Abstract;
using GameCampaignTutorial.Service.Concrete;
using System;
using System.Linq;

namespace GameCampaignTutorial
{
    internal class Program
    {
        private static readonly IService<GameOrder> _gameOrderService = new GameOrderService();
        private static readonly IService<Game> _gameService = new GameService();
        private static readonly IService<Campaign> _campaignService = new CampaignService();
        private static readonly IService<Gamer> _gamerService = new GamerService(new MernisValidationService<Gamer>());
        private static readonly Random _random = new Random();

        private static void Main(string[] args)
        {
            GenerateCampaigns();
            GenerateGames();
            GenerateGamers();
            var gameList = _gameService.GetAll();
            var randomGame = gameList.ElementAt(_random.Next(gameList.Count() - 1));
            var gameCampaign = _campaignService.Get(randomGame.CampaignId);
            var gamers = _gamerService.GetAll();
            var randomGamer = gamers.ElementAt(_random.Next(gamers.Count() - 1));

            _gameOrderService.Add(new GameOrder
            {
                Id = Guid.NewGuid(),
                AmountPaid = randomGame.Price - (randomGame.Price * gameCampaign.Discount),
                Game = randomGame,
                Gamer = randomGamer,
                IsDeleted = false,
                PurchaseDate = DateTime.Now
            }).Wait();

            ListOrders();

            Console.ReadKey();
        }

        private static void ListOrders()
        {
            var gameOrdersList = _gameOrderService.GetAll();
            Console.WriteLine("Oyun siparişleri:\n");
            foreach (var gameOrder in gameOrdersList)
            {
                Console.WriteLine($"Id: {gameOrder.Id,50}");
                Console.WriteLine($"Tutar: {gameOrder.AmountPaid,15}");
                Console.WriteLine($"Satınalma Tarihi: {gameOrder.PurchaseDate,3}");
                Console.WriteLine($"Oyuncu: {gameOrder.Gamer.Name,20} {gameOrder.Gamer.Surname}");
                Console.WriteLine($"Oyun: {gameOrder.Game.Name,17}");
            }
        }

        private static void GenerateCampaigns()
        {
            for (int i = 1; i < 6; i++)
            {
                _campaignService.Add(new Campaign
                {
                    Id = Guid.NewGuid(),
                    Description = $"Campaign {i}",
                    Discount = (double)i / 10,
                    IsDeleted = false
                }).Wait();
            }
        }

        private static void GenerateGames()
        {
            var campaigns = _campaignService.GetAll();
            for (int i = 1; i < 20; i++)
            {
                _gameService.Add(new Game
                {
                    Id = Guid.NewGuid(),
                    Developer = $"Developer{i}",
                    IsDeleted = false,
                    Name = $"Oyun{i}",
                    Price = i * 5.5,
                    Rating = i % 5 + 1,
                    ReleaseDate = DateTime.Now.AddMonths(i),
                    CampaignId = campaigns.ElementAt(_random.Next(campaigns.Count() - 1)).Id
                }).Wait();
            }
        }

        private static void GenerateGamers()
        {
            _gamerService.Add(
                new Gamer
                {
                    Id = Guid.NewGuid(),
                    Name = "isim",
                    Surname = "soyisim",
                    BirthDate = new DateTime(2021, 02, 01),
                    IdentityNumber = "tc no buraya gelecek",
                    Email = "email",
                    Genre = Genre.Male,
                    IsDeleted = false
                }).Wait();
        }
    }
}