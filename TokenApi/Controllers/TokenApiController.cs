using System.Web.Mvc;
using TokenApi.Functions;
using Newtonsoft.Json;


namespace TokenApi.Controllers
{
    public class TokenApiController : Controller
    { 
        private readonly TokenApiClass TokenApi;
        // GET: Api

        public TokenApiController()
        {
            TokenApi = new TokenApiClass();

        }

        [HttpPost]
        public JsonResult GetBalance(string address)
        {

            var result = TokenApi.GetBalance(address);

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Transfer(string address, int amount)
        {

            var result = TokenApi.TransferBalance(address, amount);

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult GetSupply()
        {

            var result = TokenApi.GetSupply();

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetAllowance(string addressFrom, string addressTo)
        {

            var result = TokenApi.GetAllowance(addressFrom, addressTo);

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Approve(string addressFrom,string passwordFrom, string addressTo, int amount)
        { 
            var result = TokenApi.Approve(addressFrom, passwordFrom, addressTo, amount);    

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult TransferFrom(string addressFrom, string addressTo, string passwordTo, int amount)
        {
            var result = TokenApi.TransferFrom(addressFrom, addressTo, passwordTo, amount);

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAllBalance()
        {
            var result = TokenApi.GetAllTokenBalance();

            return Json(JsonConvert.SerializeObject(result), JsonRequestBehavior.AllowGet);

        }

    }
}