using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TKXDPM_API.Model;

namespace TKXDPM_API.Controllers
{
    [Route("api")]
    [ApiController]
    public class EcoBikeRentalController : ControllerBase
    {
        private readonly ILogger<EcoBikeRentalController> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public EcoBikeRentalController(ILogger<EcoBikeRentalController> logger, IMapper mapper,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet("get-list-stations")]
        public async Task<ActionResult> GetListStations()
        {
            var listStation = new List<StationResponse>
            {
                new StationResponse(),
                new StationResponse()
            };
            return Ok(listStation);
        }

        [HttpGet("get-station")]
        public async Task<ActionResult> GetStation(int id)
        {
            return Ok(new StationResponse());
        }

        [HttpGet("get-list-bike")]
        public async Task<ActionResult> GetListBike(int stationId, BikeType type)
        {
            return Ok(new List<BikeResponse>
            {
                new BikeResponse(),
                new BikeResponse(),
                new BikeResponse(),
                new BikeResponse(),
                new BikeResponse(),
                new BikeResponse()
            });
        }

        [HttpGet("get-bike")]
        public async Task<ActionResult> GetListBike(int bikeId)
        {
            return Ok(new BikeResponse());
        }

        [HttpGet("get-payment-method")]
        public async Task<ActionResult> GetCard(string userId)
        {
            return Ok(new CardResponse());
        }

        [HttpGet("get-rental-info")]
        public async Task<ActionResult> GetRentalInfoBikeById(string userId)
        {
            return Ok(new RentalResponse());
        }

        [HttpPost("add-payment-method")]
        public async Task<ActionResult> AddPaymentMethod([FromBody] CardRequest request)
        {
            var card = _mapper.Map<Card>(request);
            _dbContext.Cards.Add(card);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("rent-bike")]
        public async Task<ActionResult> RentBike(string userId, int bikeId, int stationId)
        {
            if (await HasRentBike(userId, bikeId))
            {
                return BadRequest($"UserID {userId} has rent another bike");
            }

            var bikeInStations
                = from bikeInStation in _dbContext.BikeInStation
                where bikeInStation.BikeId == bikeId && bikeInStation.StationId == stationId
                select bikeInStation;
            _dbContext.RemoveRange(bikeInStations);
            var newRental = new Rental()
            {
                BikeId = bikeId,
                RenterId = userId
            };
            var transaction = new Transaction()
            {
                Rental = newRental,
                PaymentStatus = false,
                BookedStartDateTime = DateTime.Now
            };
            _dbContext.Add(newRental);
            _dbContext.Add(transaction);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        private async Task<bool> HasRentBike(string userId, int bikeId)
        {
            var oldRentals = await (from rental in _dbContext.Rentals
                where rental.BikeId == bikeId && rental.RenterId == userId
                select rental).ToListAsync();
            var hasRent = oldRentals.Any(rental => rental.Transaction.BookedEndDateTime == DateTime.MinValue || rental.Transaction.BookedEndDateTime >= DateTime.Now);
            return hasRent;
        }

        [HttpPost("return-bike")]
        public async Task<ActionResult> ReturnBike(int stationId, int bikeId)
        {
            if (await BikeInStation(bikeId, stationId))
            {
                return BadRequest();
            }
            
            var bikeStation = new BikeInStation()
            {
                BikeId = bikeId,
                StationId = stationId,
                DateTimeIn = DateTime.Now
            };
            _dbContext.Add(bikeStation);
            await _dbContext.SaveChangesAsync();
            return Ok(new
            {
                returnMoney = 100000
            });
        }

        private async Task<bool> BikeInStation(int bikeId, int stationId)
        {
            var bikeInStations
                = await (from bikeInStation in _dbContext.BikeInStation
                    where bikeInStation.BikeId == bikeId
                          && bikeInStation.StationId == stationId
                    select bikeInStation).ToListAsync();
            return bikeInStations.Count != 0;
        }
    }
}