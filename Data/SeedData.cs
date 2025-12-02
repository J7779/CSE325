using GroupProject.Models;

namespace GroupProject.Data;

// seed data to populate the app with some yummy recipes
public static class SeedData
{
    public static List<Recipe> GetSampleRecipes()
    {
        return new List<Recipe>
        {
            new Recipe
            {
                Id = 1,
                Title = "Classic Spaghetti Carbonara",
                Description = "Authentic Italian pasta with creamy egg sauce, crispy pancetta, and pecorino cheese. This Roman classic is comfort food at its finest.",
                Ingredients = "400g spaghetti\n200g pancetta or guanciale\n4 large egg yolks\n2 whole eggs\n100g pecorino romano\n50g parmesan\nFreshly ground black pepper\nSalt for pasta water",
                Instructions = "1. Bring a large pot of salted water to boil\n2. Cut pancetta into small cubes and cook until crispy\n3. Whisk eggs and yolks with grated cheeses\n4. Cook pasta until al dente\n5. Reserve 1 cup pasta water before draining\n6. Toss hot pasta with pancetta off heat\n7. Add egg mixture quickly, tossing constantly\n8. Add pasta water as needed for creamy consistency\n9. Season with black pepper and serve immediately",
                PrepTimeMinutes = 10,
                CookTimeMinutes = 20,
                Servings = 4,
                ImageUrl = "https://images.unsplash.com/photo-1612874742237-6526221588e3?w=800",
                Category = "Pasta",
                Cuisine = "Italian",
                Difficulty = DifficultyLevel.Medium,
                AuthorId = "user1",
                AuthorName = "Chef Marco",
                LikeCount = 234,
                IsFeatured = true,
                Tags = "italian,pasta,quick,comfort food"
            },
            new Recipe
            {
                Id = 2,
                Title = "Thai Green Curry",
                Description = "Aromatic and spicy Thai green curry with tender chicken, bamboo shoots, and Thai basil. Restaurant quality right at home!",
                Ingredients = "500g chicken breast\n400ml coconut milk\n3 tbsp green curry paste\n150g bamboo shoots\n100g Thai eggplant\n2 tbsp fish sauce\n1 tbsp palm sugar\nThai basil leaves\nKaffir lime leaves\n2 red chilies",
                Instructions = "1. Slice chicken into bite-sized pieces\n2. Heat thick coconut cream in a wok until oil separates\n3. Fry curry paste until fragrant (2-3 mins)\n4. Add chicken and cook until sealed\n5. Pour in remaining coconut milk\n6. Add bamboo shoots and eggplant\n7. Season with fish sauce and sugar\n8. Simmer for 10 minutes\n9. Add torn lime leaves and Thai basil\n10. Serve with jasmine rice",
                PrepTimeMinutes = 15,
                CookTimeMinutes = 25,
                Servings = 4,
                ImageUrl = "https://images.unsplash.com/photo-1455619452474-d2be8b1e70cd?w=800",
                Category = "Curry",
                Cuisine = "Thai",
                Difficulty = DifficultyLevel.Medium,
                AuthorId = "user2",
                AuthorName = "Bangkok Kitchen",
                LikeCount = 189,
                IsFeatured = true,
                Tags = "thai,spicy,curry,chicken"
            },
            new Recipe
            {
                Id = 3,
                Title = "Fluffy Japanese Pancakes",
                Description = "Extra thick and jiggly Japanese soufflé pancakes that are light as a cloud. Perfect for a special weekend breakfast!",
                Ingredients = "2 egg yolks\n3 tbsp milk\n1 tsp vanilla extract\n1/4 cup cake flour\n1/2 tsp baking powder\n3 egg whites\n2 tbsp sugar\n1/4 tsp cream of tartar\nButter for cooking\nMaple syrup\nFresh berries",
                Instructions = "1. Mix egg yolks, milk, and vanilla\n2. Sift in flour and baking powder, mix until smooth\n3. Beat egg whites with cream of tartar until foamy\n4. Gradually add sugar, beat to stiff peaks\n5. Fold 1/3 of meringue into batter, then fold in rest gently\n6. Grease ring molds in a non-stick pan on low heat\n7. Fill molds 2/3 full, add 1 tbsp water to pan\n8. Cover and cook 6-8 minutes per side\n9. Remove molds carefully\n10. Stack and top with butter, syrup, and berries",
                PrepTimeMinutes = 20,
                CookTimeMinutes = 20,
                Servings = 2,
                ImageUrl = "https://images.unsplash.com/photo-1567620905732-2d1ec7ab7445?w=800",
                Category = "Breakfast",
                Cuisine = "Japanese",
                Difficulty = DifficultyLevel.Hard,
                AuthorId = "user3",
                AuthorName = "Tokyo Treats",
                LikeCount = 456,
                IsFeatured = true,
                Tags = "breakfast,pancakes,japanese,fluffy"
            },
            new Recipe
            {
                Id = 4,
                Title = "Classic Beef Tacos",
                Description = "Authentic Mexican street-style tacos with perfectly seasoned ground beef, fresh toppings, and homemade salsa.",
                Ingredients = "500g ground beef\n1 onion, diced\n3 cloves garlic\n2 tbsp taco seasoning\n8 corn tortillas\nFresh cilantro\n1 lime\nDiced onion for topping\nSalsa verde\nSour cream\nShredded lettuce\nDiced tomatoes",
                Instructions = "1. Brown ground beef in a large skillet\n2. Add diced onion and garlic, cook until soft\n3. Add taco seasoning and 1/4 cup water\n4. Simmer until sauce thickens\n5. Warm tortillas on a dry skillet\n6. Fill tortillas with seasoned beef\n7. Top with cilantro, onion, and lime juice\n8. Add salsa, sour cream, and veggies as desired\n9. Serve immediately with extra lime wedges",
                PrepTimeMinutes = 15,
                CookTimeMinutes = 15,
                Servings = 4,
                ImageUrl = "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?w=800",
                Category = "Mexican",
                Cuisine = "Mexican",
                Difficulty = DifficultyLevel.Easy,
                AuthorId = "user1",
                AuthorName = "Chef Marco",
                LikeCount = 312,
                IsFeatured = false,
                Tags = "mexican,tacos,beef,quick"
            },
            new Recipe
            {
                Id = 5,
                Title = "Honey Garlic Salmon",
                Description = "Pan-seared salmon with a sticky honey garlic glaze. Ready in 20 minutes and fancy enough for date night!",
                Ingredients = "4 salmon fillets\n4 tbsp honey\n3 tbsp soy sauce\n4 cloves garlic, minced\n1 tbsp olive oil\n1 tbsp butter\nSesame seeds\nGreen onions\nLemon wedges",
                Instructions = "1. Pat salmon dry and season with salt and pepper\n2. Mix honey, soy sauce, and garlic in a bowl\n3. Heat oil and butter in a skillet over medium-high\n4. Sear salmon skin-side up for 4 minutes\n5. Flip and cook for 2 more minutes\n6. Pour honey garlic sauce over salmon\n7. Baste and cook until sauce thickens (2-3 mins)\n8. Garnish with sesame seeds and green onions\n9. Serve with lemon wedges",
                PrepTimeMinutes = 5,
                CookTimeMinutes = 15,
                Servings = 4,
                ImageUrl = "https://images.unsplash.com/photo-1467003909585-2f8a72700288?w=800",
                Category = "Seafood",
                Cuisine = "Asian Fusion",
                Difficulty = DifficultyLevel.Easy,
                AuthorId = "user2",
                AuthorName = "Bangkok Kitchen",
                LikeCount = 278,
                IsFeatured = true,
                Tags = "salmon,seafood,quick,healthy,date night"
            },
            new Recipe
            {
                Id = 6,
                Title = "Chocolate Lava Cake",
                Description = "Decadent individual chocolate cakes with a molten center. The ultimate dessert for chocolate lovers!",
                Ingredients = "200g dark chocolate\n100g butter\n2 whole eggs\n2 egg yolks\n50g sugar\n30g flour\nPinch of salt\nButter and cocoa for ramekins\nVanilla ice cream\nFresh raspberries",
                Instructions = "1. Preheat oven to 425°F (220°C)\n2. Butter 4 ramekins and dust with cocoa powder\n3. Melt chocolate and butter together gently\n4. Whisk eggs, yolks, and sugar until thick and pale\n5. Fold chocolate mixture into eggs\n6. Sift in flour and salt, fold gently\n7. Divide batter among ramekins\n8. Bake for 12-14 minutes (edges set, center soft)\n9. Let rest 1 minute, then invert onto plates\n10. Serve immediately with ice cream and berries",
                PrepTimeMinutes = 15,
                CookTimeMinutes = 14,
                Servings = 4,
                ImageUrl = "https://images.unsplash.com/photo-1624353365286-3f8d62daad51?w=800",
                Category = "Dessert",
                Cuisine = "French",
                Difficulty = DifficultyLevel.Medium,
                AuthorId = "user3",
                AuthorName = "Tokyo Treats",
                LikeCount = 521,
                IsFeatured = true,
                Tags = "chocolate,dessert,french,impressive"
            },
            new Recipe
            {
                Id = 7,
                Title = "Avocado Toast Supreme",
                Description = "Elevated avocado toast with poached eggs, everything bagel seasoning, and microgreens. Brunch goals achieved!",
                Ingredients = "2 slices sourdough bread\n1 ripe avocado\n2 eggs\n1 tbsp white vinegar\nEverything bagel seasoning\nMicrogreens\nChili flakes\nFlaky sea salt\nLemon juice\nOlive oil drizzle",
                Instructions = "1. Toast sourdough until golden and crispy\n2. Bring water to a gentle simmer with vinegar\n3. Crack eggs into water and poach for 3-4 minutes\n4. Mash avocado with lemon juice and salt\n5. Spread avocado generously on toast\n6. Top with poached eggs\n7. Sprinkle with everything bagel seasoning\n8. Add chili flakes and flaky salt\n9. Top with microgreens and olive oil drizzle",
                PrepTimeMinutes = 5,
                CookTimeMinutes = 10,
                Servings = 2,
                ImageUrl = "https://images.unsplash.com/photo-1541519227354-08fa5d50c44d?w=800",
                Category = "Breakfast",
                Cuisine = "American",
                Difficulty = DifficultyLevel.Easy,
                AuthorId = "user1",
                AuthorName = "Chef Marco",
                LikeCount = 145,
                IsFeatured = false,
                Tags = "breakfast,brunch,healthy,avocado,trendy"
            },
            new Recipe
            {
                Id = 8,
                Title = "Korean Fried Chicken",
                Description = "Ultra crispy double-fried Korean chicken wings coated in a sweet and spicy gochujang glaze. Better than takeout!",
                Ingredients = "1kg chicken wings\n1 cup potato starch\n1/2 cup flour\n1 tsp baking powder\nSalt and pepper\nOil for frying\n\nFor sauce:\n4 tbsp gochujang\n3 tbsp honey\n2 tbsp soy sauce\n1 tbsp rice vinegar\n3 cloves garlic\n1 tbsp ginger\nSesame seeds",
                Instructions = "1. Pat wings completely dry with paper towels\n2. Mix potato starch, flour, baking powder, salt\n3. Coat wings thoroughly in starch mixture\n4. Fry at 350°F for 10 minutes, remove and rest\n5. Heat oil to 375°F and fry again for 8-10 minutes until super crispy\n6. Mix all sauce ingredients in a pan over medium heat\n7. Simmer until sauce thickens slightly\n8. Toss crispy wings in sauce\n9. Garnish with sesame seeds and green onions\n10. Serve immediately while crispy",
                PrepTimeMinutes = 20,
                CookTimeMinutes = 30,
                Servings = 4,
                ImageUrl = "https://images.unsplash.com/photo-1575932444877-5106bee2a599?w=800",
                Category = "Appetizer",
                Cuisine = "Korean",
                Difficulty = DifficultyLevel.Medium,
                AuthorId = "user2",
                AuthorName = "Bangkok Kitchen",
                LikeCount = 398,
                IsFeatured = true,
                Tags = "korean,fried chicken,spicy,crispy,wings"
            }
        };
    }

    public static List<User> GetSampleUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                Username = "chefmarco",
                Email = "marco@recipes.com",
                PasswordHash = "hashedpassword123",
                DisplayName = "Chef Marco",
                Bio = "Italian chef with 15 years of experience. Love sharing authentic recipes!",
                RecipeCount = 3,
                FollowerCount = 1250
            },
            new User
            {
                Id = 2,
                Username = "bangkokkitchen",
                Email = "bangkok@recipes.com",
                PasswordHash = "hashedpassword456",
                DisplayName = "Bangkok Kitchen",
                Bio = "Bringing authentic Thai and Asian flavors to your kitchen.",
                RecipeCount = 3,
                FollowerCount = 890
            },
            new User
            {
                Id = 3,
                Username = "tokyotreats",
                Email = "tokyo@recipes.com",
                PasswordHash = "hashedpassword789",
                DisplayName = "Tokyo Treats",
                Bio = "Japanese home cooking made simple. Dessert specialist!",
                RecipeCount = 2,
                FollowerCount = 2100
            }
        };
    }
}
