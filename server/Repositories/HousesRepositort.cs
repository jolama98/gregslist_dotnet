namespace gregslist_dotnet.Repositories;
public class HousesRepository
{
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
        _db = db;
    }

    public List<House> GetAllHouses()
    {
        string sql = "SELECT * FROM houses;";

        List<House> houses = _db.Query<House>(sql).ToList();
        return houses;
    }

    public House GetHousesById(int houseId)
    {
        string sql = @"
        SELECT
        houses.*,
        accounts.*
        FROM houses
        JOIN accounts ON accounts.id = houses.creatorId
        WHERE houses.id = @houseId;";

        House house = _db.Query<House, Profile, House>(sql, (house, account) =>
        {
            house.Creator = account;
            return house;
        }, new { houseId }).FirstOrDefault();
        return house;
    }

    public House CreateHouse(House houseData)
    {
        string sql = @"
INSERT INTO
house(sqft, bedrooms, bathrooms, imgUrl, price, description, isFixerUp, creatorId)
VALUES(@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Drice, @Description, @IsFixerUp, @CreatorId);

SELECT houses.*, accounts.*
 FROM houses
 JOIN accounts ON accounts.id = houses.creatorId
  WHERE houses.id = LAST_INSERT_ID();";

        House house = _db.Query<House, Profile, House>(sql, (house, account) =>
        {
            house.Creator = account;
            return house;
        }, houseData).FirstOrDefault();
        return house;
    }

    // public void DestroyHouse(int houseId)
    // {
    //     string sql = "DELETE FROM house WHERE id @houseId LIMIT 1;";

    //     int rowsAffected = _db.Execute(sql, new { houseId });

    //     if (rowsAffected == 0) throw new Exception("DELETE FAILED");
    //     if (rowsAffected > 1) throw new Exception("DELETE WAS OVERED POWERED");
    // }


}