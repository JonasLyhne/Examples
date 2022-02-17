-- BurgerDB creation script
-- Last modified: 16-11-2018 12:12
-- By: Nicky

USE [BurgerDB]


-- Drop tables in reverse order, if changes are made to the table creation script.
DROP TABLE IF EXISTS BurgerContent;
DROP TABLE IF EXISTS OrderContent;
DROP TABLE IF EXISTS Inventory;
DROP TABLE IF EXISTS BurgerIngredient;
DROP TABLE IF EXISTS [Order];
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS Restaurant;
DROP TABLE IF EXISTS BurgerIngredientType;
DROP TABLE IF EXISTS Burger;



-- Creation of tables with the FOREIGN KEY constraints applied also.
CREATE TABLE Burger
(
[guid] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NewId(),
[name] VARCHAR(64) NOT NULL
)
GO

CREATE TABLE BurgerIngredientType
(
id int PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(32)
)
GO

CREATE TABLE Restaurant
(
id int PRIMARY KEY IDENTITY(1,1),
city VARCHAR(32) NOT NULL,
[address] VARCHAR(32) NOT NULL,
phone VARCHAR(16) NOT NULL
)
GO

CREATE TABLE Customer
(
id int PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(255) NOT NULL,
[tableNumber] VARCHAR(255) NOT NULL,
)
GO

CREATE TABLE [Order]
(
id int PRIMARY KEY IDENTITY(1,1),
restaurant_id int NOT NULL,
customer_id int NOT NULL,
completed bit DEFAULT 0,
CONSTRAINT fk_order_customer_id FOREIGN KEY (customer_id) REFERENCES Customer(id),
CONSTRAINT fk_order_restaurant_id FOREIGN KEY (restaurant_id) REFERENCES Restaurant(id)
)
GO

CREATE TABLE BurgerIngredient
(
id int PRIMARY KEY IDENTITY(1,1),
[name] VARCHAR(64),
[description] VARCHAR(255),
[price] MONEY NOT NULL DEFAULT 0,
[type_id] int,
CONSTRAINT fk_burgeringredient_burgeringredient_type FOREIGN KEY ([type_id]) REFERENCES BurgerIngredientType(id)
)
GO

CREATE TABLE Inventory
(
id int NOT NULL PRIMARY KEY IDENTITY(1,1),
restaurant_id int NOT NULL,
burger_ingredient_id int NOT NULL,
quantity int NOT NULL,
CONSTRAINT fk_inventory_restaurant_id FOREIGN KEY (restaurant_id) REFERENCES Restaurant(id),
CONSTRAINT fk_inventory_burger_ingredient_id FOREIGN KEY (burger_ingredient_id) REFERENCES BurgerIngredient(id),
UNIQUE (restaurant_id, burger_ingredient_id)
)
GO

CREATE TABLE OrderContent
(
id int NOT NULL PRIMARY KEY IDENTITY(1,1),
order_id int NOT NULL,
burger_id UNIQUEIDENTIFIER NOT NULL,
quantity int,
CONSTRAINT fk_ordercontent_order_id FOREIGN KEY (order_id) REFERENCES [Order](id),
CONSTRAINT fk_ordercontent_burger_id FOREIGN KEY (burger_id) REFERENCES Burger([guid]),
UNIQUE (order_id, burger_id)
)
GO

CREATE TABLE BurgerContent
(
id int NOT NULL PRIMARY KEY IDENTITY(1,1),
burger_id UNIQUEIDENTIFIER NOT NULL,
burgerIngredient_id int,
/*quantity int NOT NULL,*/
CONSTRAINT fk_burgercontent_burger_id FOREIGN KEY (burger_id) REFERENCES Burger([guid]),
CONSTRAINT fk_burgercontent_burgerIngredient_id FOREIGN KEY (burgerIngredient_id) REFERENCES BurgerIngredient(id),
--UNIQUE (burger_id, burgerIngredient_id)
)

GO

