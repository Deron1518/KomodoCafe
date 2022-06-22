using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class MenuUI
    {
        private readonly MenuRepo _mrepo = new MenuRepo();

        public void Run()
        {
            SeedData();
            RunApplication();
        }

        private void SeedData()
        {
            MenuData burger = new MenuData("Bonkers Burger", "The Bonkers Burger will knock you off your feet and is so spicy it'll cause sweat to drip from your cheek. Think you can handle the challenge?", "2 pounds ground beef, 2 teaspoons minced garlic, 2 fresh jalapeno peppers, 1 small fresh poblano chile pepper, 1 fresh ghost pepper, 1 teaspoon crushed red pepper flakes, 2 tablespoons chopped fresh cilantro, 1 teaspoon ground cumin", 1, 8.99);

            MenuData tenders = new MenuData("Chicken Tenders", "Something simple and safe for the kiddos and for the picky eaters.", "Boneless skinless chicken breasts sliced into 1/2 strips, 1 1/2 c. Italian seasoned bread crumbs, 4 large eggs, 1/2 c all purpose flour, 1 teaspoon garlic powder, fried in vegatable oil", 2, 6.99);

            MenuData chickenSandwich = new MenuData("Chicken Sandwich", "If you think Popeyes has the best chicken sandwich CLEARLY you haven't tried ours!", "2 boneless skinless chicken breasts, 1 cup of buttermilk, 2 tablespoons of hotsauce, 1 teaspoon sweet paprika, 1 teaspoon garlic powder, 1 teaspoon onion powder, 1 teaspoon freshly ground black pepper, 1 teaspoon kossher salt", 3, 7.99);

            MenuData fries = new MenuData("French Fries", "Fries made fresh to order! Our freshly made seasoned fries will have you coming back for more!", "Russet potatoes, vegetable oil for frying, sea salt", 4, 2.99);

            _mrepo.AddFoodToMenu(burger);
            _mrepo.AddFoodToMenu(tenders);
            _mrepo.AddFoodToMenu(chickenSandwich);
            _mrepo.AddFoodToMenu(fries);

        }

        public void RunApplication()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Welcome to the Komodo Cafe!");
                System.Console.WriteLine(
                    "Please make a selection: \n" +
                    "1. Add Item to Menu \n" +
                    "2. Delete Item from Menu \n" +
                    "3. View Menu \n" +
                    "4. Close Application \n" 
                    );

                    string userInput = Console.ReadLine();

                    switch(userInput.ToLower())
                    {
                        case "1":
                        case "one":
                            AddFoodToMenu();
                            break;
                        case "2":
                        case "two":
                            DeleteMenuItem();
                            break;
                        case "3":
                        case "three":
                            ViewAllFood();
                            break;
                        case "4":
                        case "four":
                            isRunning = false;
                            System.Console.WriteLine("Thank you for coming to Komodo Cafe!");
                            PauseUntilKeyPress();
                            break;
                        default:
                            System.Console.WriteLine("Please enter a valid option.");
                            break;
                    }
            }
        }

        private void PauseUntilKeyPress()
        {
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void AddFoodToMenu()
        {
            Console.Clear();
            MenuData food = new MenuData();
            System.Console.WriteLine("Please enter the name of the menu item you'd like to add: ");
            food.Name = Console.ReadLine();

            System.Console.WriteLine("Please enter a description: ");
            food.Description = Console.ReadLine();

            System.Console.WriteLine("Please enter the price for this menu item: ");
            food.Price = double.Parse(Console.ReadLine());

            System.Console.WriteLine("Please enter the menu number for this item: ");
            food.ID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Please enter the ingredients for this menu item: ");
            food.Ingredients = Console.ReadLine();

            bool isSuccessfull = _mrepo.AddFoodToMenu(food);
            if(isSuccessfull)
            {
                System.Console.WriteLine($"The menu item {food.Name} was added!");
            }
            else
            {
                System.Console.WriteLine("We ran into an issue! Menu item not added :(.");
            }
            
            PauseUntilKeyPress();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            List<MenuData> foodList = _mrepo.ViewAllFood();
            if(foodList.Count() > 0)
            {
                System.Console.WriteLine("Which menu item would you like to remove?");

                int count = 0;
                foreach(var food in foodList)
                {
                    count++;
                    System.Console.WriteLine($"{count}. {food.Name}");
                }

                int targetFoodID = int.Parse(Console.ReadLine());
                int targetIndex = targetFoodID - 1;

                if(targetIndex >= 0 && targetIndex < foodList.Count)
                {
                    MenuData unwantedItem = foodList[targetIndex];
                    if(_mrepo.DeleteMenuItem(unwantedItem))
                    {
                        System.Console.WriteLine($"{unwantedItem.Name} has been successfully deleted");
                    }
                    else
                    {
                        System.Console.WriteLine("Unable to remove item");
                    }
                }
                else
                {
                    System.Console.WriteLine("No menu item was found with that ID");
                }
            }
            PauseUntilKeyPress();
        }

        private void ViewAllFood()
        {
            Console.Clear();
            List<MenuData> ListOfFood = _mrepo.ViewAllFood();
            foreach(MenuData data in ListOfFood)
            {
                DisplayContent(data);
            }
            PauseUntilKeyPress();
        }

        private void DisplayContent(MenuData food)
        {
            System.Console.WriteLine($"Food Name: {food.Name}\n" +
            $"Menu Number: {food.ID}\n" +
            $"Description: {food.Description}\n" +
            $"Price: {food.Price}\n" +
            $"Ingredients: {food.Ingredients}"
            );
        }
    }

    
