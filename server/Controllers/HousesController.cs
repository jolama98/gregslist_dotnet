namespace gregslist_dotnet.Controllers;
[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
    private readonly HousesService _housesService;

    public HousesController(HousesService housesService)
    {
        _housesService = housesService;
    }

    [HttpGet]
    public ActionResult<List<House>> GetAllHouses()
    {
        try
        {
            List<House> houses = _housesService.GetAllHouses();
            return Ok(houses);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }


    [HttpGet("{houseId}")]
    public ActionResult<House> GetHousesById(int houseId)
    {
        try
        {
            House houses = _housesService.GetHousesById(houseId);
            return Ok(houses);
        }
        catch (Exception exception)
        {

            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{houseId}")]
    [Authorize]
    public async Task<ActionResult<string>> DestroyHouse(int houseId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _housesService.DestroyHouse(houseId userInfo.Id);
            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
