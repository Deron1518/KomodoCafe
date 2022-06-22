

public class MenuRepo
{
    private readonly List<MenuData> _mrepo = new List<MenuData>();
    private int _count;

    public bool AddFoodToMenu(MenuData food)
    {
        if(food != null)
        {
            _count++;
            food.ID = _count;
            _mrepo.Add(food);
            return true;
        }
        return false;
    }

    public List<MenuData> ViewAllFood()
    {
        return _mrepo;
    }

    public bool DeleteMenuItem (MenuData food)
    {
        bool deleteResult = _mrepo.Remove(food);
        return deleteResult;
    }

}
