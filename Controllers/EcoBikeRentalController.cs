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
        public async Task<ActionResult<List<StationResponse>>> GetListStations()
        {
            var listStation = await _dbContext.Stations
                .Include(station => station.BikeInStations).ThenInclude(bikeInStation => bikeInStation.Bike)
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

            return listStationResponse;
        }

        [HttpGet("get-station")]
        public async Task<ActionResult<StationResponse>> GetStation(int id)
        {
            var stationR = await _dbContext.Stations.Where(s => s.StationId == id)
                .Include(s => s.BikeInStations).ThenInclude(bikeInStation => bikeInStation.Bike)
                .Include(s => s.Address)
                .FirstOrDefaultAsync();
            if (stationR == null)
            {
                return NotFound($"Not found station {id}");
            }

            var stationResponse = _mapper.Map<StationResponse>(stationR);
            stationResponse.Address = _mapper.Map<AddressResponse>(stationR.Address);
            var listBike = new List<BikeResponse>();
            foreach (var bikeInStation in stationR.BikeInStations)
            {
                listBike.Add(_mapper.Map<BikeResponse>(bikeInStation.Bike));
            }

            stationResponse.ListBike = listBike;
            return stationResponse;
        }

        [HttpGet("get-list-bike")]
        public async Task<ActionResult<List<BikeResponse>>> GetListBike(int stationId, BikeType type)
        {
            var station = await _dbContext.Stations.Where(s => s.StationId == stationId)
                .Include(s => s.BikeInStations)
                .ThenInclude(bikeInStation => bikeInStation.Bike)
                .Include(s => s.Address)
                .FirstOrDefaultAsync();
            if (station == null)
            {
                return NotFound($"Not found station {stationId}");
            }

            var listBike = (
                    from bikeInStation in station.BikeInStations
                    select bikeInStation.Bike
                    into bike
                    where bike.Type == type
                    select _mapper.Map<BikeResponse>(bike))
                .ToList();

            return listBike;
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
        public async Task<ActionResult<CardResponse>> GetCard(string deviceCode)
        {
            var renter = await _dbContext.Renters.Where(r => r.DeviceCode == deviceCode).Include(r => r.Card)
                .FirstOrDefaultAsync();
            if (renter == null)
            {
                return NotFound($"Not found renter {deviceCode}");
            }

            var card = _mapper.Map<CardResponse>(renter.Card);
            card.Renter = _mapper.Map<RenterResponse>(renter);
            return card;
        }

        [HttpGet("get-rental-info")]
        public async Task<ActionResult> GetRentalInfoBikeById(string deviceCode)
        {
            var renter = await _dbContext.FindRenter(deviceCode);
            var rental = await _dbContext.Rentals
                .Where(r => r.RenterId == renter.RenterId)
                .Include(r => r.Card)
                .Include(r => r.Bike)
                .Include(r => r.Transaction).FirstOrDefaultAsync();
            var rentalResponse = _mapper.Map<RentalResponse>(rental);
            
            return Ok(rentalResponse);
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