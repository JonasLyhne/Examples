USE [BurgerDB]

DELETE FROM BurgerIngredient;
DELETE FROM BurgerIngredientType;
DELETE FROM Inventory;

INSERT INTO BurgerIngredientType ([name]) VALUES ('Cheese');
INSERT INTO BurgerIngredientType ([name]) VALUES ('Meat');
INSERT INTO BurgerIngredientType ([name]) VALUES ('Vegetable');
INSERT INTO BurgerIngredientType ([name]) VALUES ('Sauce');
INSERT INTO BurgerIngredientType ([name]) VALUES ('Bun');
INSERT INTO BUrgerIngredientTYpe ([name]) VALUES ('Extra');


-- Cheeses:
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Mozarella', 'Cheese from italy', 5, 1);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Cheddar', 'Cheese made from cow milk.', 5, 1);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Swiss', 'Cheese from switzerland', 5, 1);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Blue', 'An acquired taste', 5, 1);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Emmentaler', 'A cheese with origins from switzerland', 5, 1);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Ghouda', 'Cheese from The Netherlands', 5, 1);


-- Meat:
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Pulled Pork', 'Pork, that is pulled apart.', 5, 2);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Beef Patty', 'A Beef patty', 5, 2);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Texas Beef', 'Our handcrafted beef.', 5, 2);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Fried Chicken', 'Our handcrafted beef.', 5, 2);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Tofu Patty', 'Made from tofu.', 5, 2);


-- Vegetable
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Onions', 'Onion rings', 2, 3);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Lettuce', 'Shredded lettuce', 2, 3);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Tomato', 'Sliced tomato', 5, 3);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Cucumber', 'Sliced cucumber', 5, 3);

-- Buns:
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Sesame Seed Bun', 'A sesame seed bun.', 10, 5);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Kaiser Bun', 'an effin bun.', 12, 5);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Brioche Bun', 'a french sounding bun.', 14, 5);

-- Sauces:
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Texas Sauce', 'Our own secret sauce made in house (it is totally a ripoff of big mac dressing :P)', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Aioli', 'A mixture primary taste of garlic.)', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Chili', 'For those wanting to add a little something spicy', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Curry', 'Our amazing curry mix.', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Green Pesto', 'Pesto primarily taste of bassilikum', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Ketchup', 'The sweet taste of tomatoes', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Mayonaise', 'Mayonaise?', 5, 4);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Sweet Chili', 'The best of both worlds, combine sweet and spicy.', 5, 4);

-- Extras:
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Bacon strips', 'Smoked pork bacon', 8, 6);
INSERT INTO BurgerIngredient ([name], [description], [price], [type_id]) VALUES ('Fried Onion Rings', 'onion rings, that is fried.', 8, 6);


-- Restaurants:
INSERT INTO Restaurant(city, [address], phone) VALUES ('Vordingborg', 'Marienbergvej 108', '+45 88 88 88 88');

-- Test customers:
INSERT INTO Customer ([name], [tableNumber]) VALUES ('Tester', '2');


-- Quantity is measured in per burger estimates.
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 1, 400); -- Mozarella
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 2, 200); -- Pulled Pork
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 3, 200); -- Beef Patty
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 4, 100); -- Onions
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 5, 100); -- Lettuce
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 6, 400); -- Bacon
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 7, 200); -- Tomato
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 8, 100); -- Cucumber
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1, 9, 500); -- Texas Sauce
INSERT INTO Inventory(restaurant_id, burger_ingredient_id, quantity) VALUES (1,10,300); -- Sesame Bun





SELECT * FROM Inventory;
SELECT * FROM Restaurant;
SELECT * FROM BurgerIngredientType
SELECT * FROM BurgerIngredient

SELECT x.name as 'Ingredient', x.description as 'Description', y.[name] as 'Ingredient type' FROM BurgerIngredient as x
INNER JOIN BurgerIngredientType as y ON x.type_id = y.id 
ORDER BY 'Ingredient type';