using AutoMapper;
using Azure;
using Mango.Services.CoupanAPI.Data;
using Mango.Services.CoupanAPI.Models;
using Mango.Services.CoupanAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Mango.Services.CoupanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupanAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ResponseDTO _response;
        private IMapper _mapper;
        public CoupanAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupan> objList = _db.Coupans.ToList();
                _response.Result= _mapper.Map<IEnumerable<CoupanDTO>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                
            }
            return _response;
         }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupan objCoupan = _db.Coupans.First(x=>x.CoupanId==id);
                _response.Result= _mapper.Map<CoupanDTO>(objCoupan);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupan objCoupan = _db.Coupans.First(x => x.CoupanCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CoupanDTO>(objCoupan);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDTO Post([FromBody]CoupanDTO objCoupan)
        {
            try
            {
                Coupan obj = _mapper.Map<Coupan>(objCoupan);
                _db.Coupans.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CoupanDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }

}
