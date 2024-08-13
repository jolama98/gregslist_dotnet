namespace gregslist_dotnet.Services;

public class HousesService
{
    private readonly HousesRepository _housesRepository;

    public HousesService(HousesRepository housesRepository)
    {
        _housesRepository = housesRepository;
    }

    public List<House> GetAllHouses()
    {
        List<House> houses = _housesRepository.GetAllHouses();
        return houses;
    }


    public House GetHousesById(int houseId)
    {
        House house = _housesRepository.GetHousesById(houseId);

        if (house == null)
        {
            throw new Exception($"No house with id {houseId}");
        }

        return house;
    }
}