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
            var listStation = await _dbContext.Stations
                .Include(station => station.BikeInStations).ThenInclude(bikeInStation =>  bikeInStation.Bike )
                .Include(station => station.Address)
                .ToListAsync();
            var listStationResponse = new List<StationResponse>();
            foreach (var station in listStation)
            {
                var stationResponse = _mapper.Map<StationResponse>(station);
                stationResponse.Address = _mapper.Map<AddressResponse>(station.Address);
                var listBike = new List<BikeResponse>();
                foreach (var bikeInStation in station.BikeInStations)
                {
                    listBike.Add(_mapper.Map<BikeResponse>(bikeInStation.Bike));
                }

                stationResponse.ListBike = listBike;
                listStationResponse.Add(stationResponse);
            }
            return Ok(listStationResponse);
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
        public async Task<ActionResult<BikeResponse>> GetBike(int bikeId)
        {
            var bike = await _dbContext.Bikes.FindAsync(bikeId);
            if (bike != null)
            {
                return _mapper.Map<BikeResponse>(bike);
            }
            else
            {
                return NotFound($"Not found bike {bikeId}");
            }
        }

        [HttpGet("get-payment-method")]
        public async Task<ActionResult> GetCard(string deviceCode)
        {
            var renter = await _dbContext.FindRenter(deviceCode);
            
            return Ok(new CardResponse());
        }

        [HttpGet("get-rental-info")]
        public async Task<ActionResult> GetRentalInfoBikeById(string deviceCode)
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
        public async Task<ActionResult> RentBike(string deviceCode, int bikeId)
        {
            var renter = await _dbContext.FindRenter(deviceCode);
            if (renter == null)
            {
                return NotFound($"The Renter with device Code {deviceCode} Not Found");
            }

            var bike = await _dbContext.Bikes.FindAsync(bikeId);
            if (bike == null)
            {
                return NotFound($"The BikeId {bikeId} Not Found");
            }

            if (await HasRentBike(renter.RenterId, bikeId))
            {
                return BadRequest($"UserID {renter.RenterId} has rent another bike");
            }

            var bikeInStations
                = from bikeInStation in _dbContext.BikeInStations
                where bikeInStation.BikeId == bikeId
                select bikeInStation;
            _dbContext.RemoveRange(bikeInStations);
            var newRental = new Rental()
            {
                Bike = bike,
                Renter = renter
            };
            var transaction = new Transaction()
            {
                Rental = newRental,
                PaymentStatus = PaymentStatus.Deposit,
                BookedStartDateTime = DateTime.Now
            };
            _dbContext.Add(newRental);
            _dbContext.Add(transaction);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        private async Task<bool> HasRentBike(int userId, int bikeId)
        {
            var oldRentals = await (from rental in _dbContext.Rentals
                where rental.BikeId == bikeId && rental.RenterId == userId
                select rental).ToListAsync();
            var hasRent = oldRentals.Any(rental =>
                rental.Transaction.BookedEndDateTime == DateTime.MinValue ||
                rental.Transaction.BookedEndDateTime >= DateTime.Now);
            return hasRent;
        }

        [HttpPost("return-bike")]
        public async Task<ActionResult> ReturnBike(int stationId, int bikeId)
        {
            var bikeInStation = await BikeInStation(bikeId, stationId);
            if (bikeInStation)
            {
                return BadRequest($"The Bike {bikeId} Was In StationId {stationId}");
            }

            var bike = await _dbContext.Bikes.FindAsync(bikeId);
            if (bike == null)
            {
                return NotFound($"The BikeId {bikeId} Not Found");
            }

            var station = await _dbContext.Stations.FindAsync(stationId);
            if (station == null)
            {
                return NotFound($"The Station {stationId} Not Found");
            }

            var bikeStation = new BikeInStation()
            {
                Bike = bike,
                Station = station,
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
                = await (from bikeInStation in _dbContext.BikeInStations
                    where bikeInStation.BikeId == bikeId
                          && bikeInStation.StationId == stationId
                    select bikeInStation).ToListAsync();
            return bikeInStations.Count != 0;
        }
    }
}