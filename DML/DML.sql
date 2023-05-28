-- insert 30 constumers
EXEC p5g4.Project.addCostumer '123456789', '123 Main Street', 'John Smith', '921123456', 'john.smith@example.com', '1990-01-15';
EXEC p5g4.Project.addCostumer '253619487', '456 Side Street', 'Michael Johnson', '900000000', 'michael.johnson@example.com', '1985-12-20';
EXEC p5g4.Project.addCostumer '129164375', 'Rua Mário Scramento 12', 'Jennifer Davis', '912343219', 'jennifer.davis@example.com', '1992-08-05';
EXEC p5g4.Project.addCostumer '236472918', '398 Main Avenue', 'David Anderson', '998098264', 'david.anderson@example.com', '1987-06-12';
EXEC p5g4.Project.addCostumer '219483526', '789 Oak Avenue', 'Jessica Martinez', '919283147', 'jessica.martinez@example.com', '1994-03-25';
EXEC p5g4.Project.addCostumer '245871629', '234 Maple Lane', 'Daniel Taylor', '900000123', 'daniel.taylor@example.com', '1989-09-08';
EXEC p5g4.Project.addCostumer '128574931', '567 Cedar Road', 'Sarah Clark', '926927456', 'sarah.clark@example.com', '1991-11-03';
EXEC p5g4.Project.addCostumer '197638254', '890 Pine Court', 'Christopher Brown', '955667889', 'christopher.brown@example.com', '1984-04-17';
EXEC p5g4.Project.addCostumer '163281745', '123 Birch Avenue', 'Amanda Rodriguez', '913579246', 'amanda.rodriguez@example.com', '1993-07-29';
EXEC p5g4.Project.addCostumer '202817936', '789 Cherry Street', 'António Mendes', '909090909', 'ant.mendes@example.com', '2003-12-31';
EXEC p5g4.Project.addCostumer '189654321', '987 Elm Street', 'Robert Johnson', '921234567', 'robert.johnson@example.com', '1991-05-10';
EXEC p5g4.Project.addCostumer '157913624', '654 Pine Lane', 'Emily Davis', '911111111', 'emily.davis@example.com', '1988-09-22';
EXEC p5g4.Project.addCostumer '148219753', '876 Oak Road', 'Matthew Anderson', '998877665', 'matthew.anderson@example.com', '1995-02-08';
EXEC p5g4.Project.addCostumer '232871569', '543 Maple Court', 'Sophia Martinez', '912345678', 'sophia.martinez@example.com', '1993-07-15';
EXEC p5g4.Project.addCostumer '182736451', '321 Cedar Avenue', 'Oliver Taylor', '922233445', 'oliver.taylor@example.com', '1990-12-03';
EXEC p5g4.Project.addCostumer '157419823', '765 Birch Lane', 'Isabella Clark', '919876543', 'isabella.clark@example.com', '1996-04-27';
EXEC p5g4.Project.addCostumer '176543219', '432 Pine Street', 'William Brown', '933388877', 'william.brown@example.com', '1987-08-14';
EXEC p5g4.Project.addCostumer '243982765', '987 Oak Avenue', 'Emma Rodriguez', '944455566', 'emma.rodriguez@example.com', '1994-10-09';
EXEC p5g4.Project.addCostumer '191874563', '654 Maple Lane', 'Alexander Mendes', '966699999', 'alexander.mendes@example.com', '1992-03-18';
EXEC p5g4.Project.addCostumer '176543210', '876 Cherry Road', 'Sophie Johnson', '955599559', 'sophie.johnson@example.com', '1997-06-26';
EXEC p5g4.Project.addCostumer '129743586', '234 Elm Street', 'Christopher Adams', '911234567', 'christopher.adams@example.com', '1993-09-18';
EXEC p5g4.Project.addCostumer '276981345', '456 Pine Lane', 'Sophia Turner', '922345678', 'sophia.turner@example.com', '1995-05-03';
EXEC p5g4.Project.addCostumer '192837465', '678 Oak Road', 'James Roberts', '933456789', 'james.roberts@example.com', '1989-12-10';
EXEC p5g4.Project.addCostumer '219384657', '890 Maple Court', 'Olivia Harris', '944567890', 'olivia.harris@example.com', '1992-04-25';
EXEC p5g4.Project.addCostumer '237894561', '123 Cedar Avenue', 'Daniel Turner', '955678901', 'daniel.turner@example.com', '1998-08-12';
EXEC p5g4.Project.addCostumer '214365879', '345 Birch Lane', 'Emily Clark', '966789012', 'emily.clark@example.com', '1991-11-27';
EXEC p5g4.Project.addCostumer '281739465', '567 Pine Street', 'Benjamin Brown', '977890123', 'benjamin.brown@example.com', '1994-06-04';
EXEC p5g4.Project.addCostumer '303011301', '789 Oak Avenue', 'Amelia Martinez', '988901234', 'amelia.martinez@example.com', '1997-02-19';
EXEC p5g4.Project.addCostumer '218374659', '432 Maple Lane', 'Henry Taylor', '999012345', 'henry.taylor@example.com', '1996-07-15';
EXEC p5g4.Project.addCostumer '216598743', '654 Cedar Road', 'Charlotte Clark', '900123456', 'charlotte.clark@example.com', '1990-10-01';

-- insert 2 stores
INSERT INTO p5g4.Project.STORE VALUES ('https://www.weselltech.com', 'We Sell Tech', 'We sell all types of technological products! If you need something check us out');
INSERT INTO p5g4.Project.STORE VALUES ('https://www.hatit.com', 'Hat It!', 'If you are looking to buy a new hat, check our site, we have what you need!');


-- insert 6 managers
EXEC p5g4.Project.addManager '244729300', '12 Cedar Road', 'Alberto Macieira', '933445009', 'al.macas@example.com', '1994-08-21', '1234321', 'Albertino', 5000, 'https://www.weselltech.com'
EXEC p5g4.Project.addManager '199124587', '1 Fafe City', 'Joe Rogers', '912343210', 'joe.rogers@example.com', '2003-08-19', '123', 'Rogers', 4000.99, 'https://www.weselltech.com'
EXEC p5g4.Project.addManager '200010010', '719 Aveiro City', 'João Pato', '900111222', 'johnny.pato@example.com', '1950-01-01', '987654321', 'Johnny', 9999, 'https://www.weselltech.com'
EXEC p5g4.Project.addManager '234129765', '869 Cherry Road', 'Albino Marques', '913245768', 'al.marques@example.com', '1995-05-03', 'segura', 'Marques', 6000, 'https://www.hatit.com'
EXEC p5g4.Project.addManager '234889889', '12 Lisbon City', 'Miguel Pinhais', '901020304', 'miguel.pi@example.com', '1986-08-25', '123resulta', 'Miguel', 3999.95, 'https://www.hatit.com'
EXEC p5g4.Project.addManager '123456123', '4 Estarreja', 'José Pereira', '921003406', 'jo.pereira@example.com', '2000-03-05', 'epanaopsei', 'Pereira', 2345, 'https://www.hatit.com'

-- insert 10 staff members
EXEC p5g4.Project.addStaff '251236789', '511 Maple Court', 'Daniel Mark ', '982734654', 'daniel.mark@example.com', '1978-09-20', 'daniel!', 'DanielMark', 1000, 'https://www.hatit.com'
EXEC p5g4.Project.addStaff '222222333', '324 Maple Avenue', 'Michael Collins', '982734639', 'mike.coll@example.com', '1962-05-05', 'mikeyZZ', 'MikeCollins', 2000, 'https://www.hatit.com'
EXEC p5g4.Project.addStaff '190333456', '12 Forward Avenue', 'Jeff Stevens ', '911131234', 'jeffy.stv@example.com', '1987-02-25', 'jstv', 'JeffStevens', 2134, 'https://www.hatit.com'
EXEC p5g4.Project.addStaff '351236789', '222 Oliveiras', 'Isabela Grey', '933445119', 'izzy.grey@example.com', '1994-08-21', 'izznono12', 'Isabela', 2670, 'https://www.hatit.com'
EXEC p5g4.Project.addStaff '200900800', '13 Azemeis', 'Manny Manos', '911345222', 'manny.manitos@example.com', '1996-10-09', 'maozinhas', 'Manny', 1670, 'https://www.weselltech.com'
EXEC p5g4.Project.addStaff '234344333', '14 Cedar Avenue', 'Rafael Pinho', '911345331', 'rad.pi@example.com', '1998-12-17', 'rafapinh', 'Rafael', 1679.99, 'https://www.weselltech.com'
EXEC p5g4.Project.addStaff '234344334', '111 Apple Cedar', 'Mark Roseberg', '999898797', 'roseberg@example.com', '1982-11-27', 'markyyy', 'M. Roseberg', 3200, 'https://www.weselltech.com'
EXEC p5g4.Project.addStaff '234333444', '111 Apple Cedar', 'Jenna Roseberg', '999898798', 'jroseberg@example.com', '1982-12-30', 'jenna:)', 'J. Roseberg', 3201, 'https://www.weselltech.com'
EXEC p5g4.Project.addStaff '255567999', 'Rua do Canto, 12', 'Ricardo Santos', '900000124', 'rikky.angels@example.com', '1992-11-27', 'ricardito999', 'Ricardo', 2210, 'https://www.weselltech.com'
EXEC p5g4.Project.addStaff '255544444', 'Rua da Esquina', 'Sebastian', '900100200', 'seb@example.com', '1973-04-14', '123seb123', 'Sebastian', 1999.99, 'https://www.weselltech.com'

-- insert 7 suppliers
INSERT INTO p5g4.Project.SUPPLIER VALUES (1, 'GetYourSupplies', 'supplies@example.com', '567 Pine Street');
INSERT INTO p5g4.Project.SUPPLIER VALUES (2, 'XYZ Distributors', 'xyz@example.com', '13 Santo Amaro');
INSERT INTO p5g4.Project.SUPPLIER VALUES (3, 'Global Suppliers Inc', 'global@example.com', '599 Bacarena');
INSERT INTO p5g4.Project.SUPPLIER VALUES (4, 'Quality Products Co.', 'quality@example.com', '1212 Zambujeira');
INSERT INTO p5g4.Project.SUPPLIER VALUES (5, 'Best Deals Ltd.', 'bestdeals@example.com', '11 Fundão');
INSERT INTO p5g4.Project.SUPPLIER VALUES (6, 'Superior Imports', 'superior@example.com', '14 Chaves City');
INSERT INTO p5g4.Project.SUPPLIER VALUES (7, 'Trusted Supplies LLC', 'trusted@example.com', '328 Main Avenue');

--insert 6 orders
INSERT INTO p5g4.Project.[ORDER] VALUES (1, '189654321', 1099.99, 'Pending', 1, 'https://www.weselltech.com','2023-06-01 14:30:00');
INSERT INTO p5g4.Project.[ORDER] VALUES (2, '129743586', 49.99, 'Shipped', 1, 'https://www.weselltech.com', '2023-06-19 12:34:56');
INSERT INTO p5g4.Project.[ORDER] VALUES (3, '216598743', 149.98, 'Delivered', 2, 'https://www.weselltech.com', '2023-06-20 15:55:20');
INSERT INTO p5g4.Project.[ORDER] VALUES (4, '237894561', 19.99, 'Pending', 1, 'https://www.hatit.com', '2023-06-15 10:00:00');
INSERT INTO p5g4.Project.[ORDER] VALUES (5, '236472918', 74.98, 'Shipped', 2, 'https://www.hatit.com', '2023-06-20 13:32:49');
INSERT INTO p5g4.Project.[ORDER] VALUES (6, '253619487', 89.97, 'Delivered', 3, 'https://www.hatit.com', '2023-06-21 18:15:12');
-- new:
INSERT INTO p5g4.Project.[ORDER] VALUES (7, '123456789', 2199.97, 'Pending', 3, 'https://www.weselltech.com', '2023-07-05 09:00:00');
INSERT INTO p5g4.Project.[ORDER] VALUES (8, '219384657', 203.94, 'Delivered', 6, 'https://www.hatit.com', '2023-07-05 09:00:00');
INSERT INTO p5g4.Project.[ORDER] VALUES (9, '276981345', 3499.96, 'Shipped', 4, 'https://www.weselltech.com', '2023-07-05 09:00:00');
INSERT INTO p5g4.Project.[ORDER] VALUES (10, '176543219', 4479.90, 'Shipped', 10, 'https://www.weselltech.com', '2023-07-05 09:00:00');
INSERT INTO p5g4.Project.[ORDER] VALUES (11, '176543219', 339.90, 'Shipped', 10, 'https://www.hatit.com', '2023-07-05 09:00:10');


-- insert 6 orders to manages
INSERT INTO p5g4.Project.MANAGES VALUES ('234333444', 12, 1, '189654321');
INSERT INTO p5g4.Project.MANAGES VALUES ('234344333', 11, 2, '129743586');
INSERT INTO p5g4.Project.MANAGES VALUES ('234344333', 11, 3, '216598743');
INSERT INTO p5g4.Project.MANAGES VALUES ('251236789', 7, 4, '237894561');
INSERT INTO p5g4.Project.MANAGES VALUES ('251236789', 7, 5, '236472918');
INSERT INTO p5g4.Project.MANAGES VALUES ('222222333', 8, 6, '253619487');

-- insert 20 items
INSERT INTO p5g4.Project.ITEM VALUES (1, 'Apple iPhone 12 Pro', 1099.99, 5, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (2, 'Samsung Galaxy Watch 4', 299.99, 3, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (3, 'Sony Noise Cancelling Headphones', 249.99, 10, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (4, 'Nintendo Switch Console', 299.99, 2, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (5, 'Bose SoundLink Bluetooth Speaker', 129.99, 1, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (6, 'Amazon Echo Dot (4th Generation)', 49.99, 8, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (7, 'Fitbit Charge 4 Fitness Tracker', 149.99, 6, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (8, 'Dyson V11 Cordless Vacuum Cleaner', 599.99, 2, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (9, 'Instant Pot Duo 7-in-1 Pressure Cooker', 99.99, 1, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (10, 'Sony 65-Inch 4K Smart LED TV', 1499.99, 4, 'https://www.weselltech.com');
INSERT INTO p5g4.Project.ITEM VALUES (11, 'Fedora Hat', 49.99, 10, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (12, 'Beanie Hat', 19.99, 15, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (13, 'Straw Hat', 34.99, 8, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (14, 'Bucket Hat', 24.99, 12, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (15, 'Baseball Cap', 14.99, 20, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (16, 'Sun Hat', 39.99, 6, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (17, 'Cowboy Hat', 59.99, 4, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (18, 'Beret Hat', 29.99, 10, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (19, 'Trucker Hat', 19.99, 15, 'https://www.hatit.com');
INSERT INTO p5g4.Project.ITEM VALUES (20, 'Wide Brim Hat', 44.99, 8, 'https://www.hatit.com');

-- insert the order items into ITEM_ORDER --> 9
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (1, '189654321', 1, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (2, '129743586', 6, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (3, '216598743', 6, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (3, '216598743', 9, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (4, '237894561', 12, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (5, '236472918', 18, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (5, '236472918', 20, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (6, '253619487', 15, 2);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (6, '253619487', 17, 1);
-- new:
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (7, '123456789', 8, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (7, '123456789', 9, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (7, '123456789', 10, 1);

INSERT INTO p5g4.Project.ITEM_ORDER VALUES (8, '219384657', 15, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (8, '219384657', 16, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (8, '219384657', 17, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (8, '219384657', 18, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (8, '219384657', 19, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (8, '219384657', 20, 1);

INSERT INTO p5g4.Project.ITEM_ORDER VALUES (9, '276981345', 1 , 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (9, '276981345', 2 , 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (9, '276981345', 8 , 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (9, '276981345', 10, 1);

INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',1,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',2, 1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',3,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',4,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',5,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',6,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',7,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',8,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',9,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (10, '176543219',10,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',11,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',12,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',13,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',14,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',15,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',16,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',17,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',18,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',19,1);
INSERT INTO p5g4.Project.ITEM_ORDER VALUES (11, '176543219',20,1);

-- insert for each item, its supplier --> 20
INSERT INTO p5g4.Project.SUPPLIES VALUES (1, 1);
INSERT INTO p5g4.Project.SUPPLIES VALUES (1, 2);
INSERT INTO p5g4.Project.SUPPLIES VALUES (2, 3);
INSERT INTO p5g4.Project.SUPPLIES VALUES (2, 4);
INSERT INTO p5g4.Project.SUPPLIES VALUES (2, 5);
INSERT INTO p5g4.Project.SUPPLIES VALUES (3, 6);
INSERT INTO p5g4.Project.SUPPLIES VALUES (4, 7);
INSERT INTO p5g4.Project.SUPPLIES VALUES (5, 8);
INSERT INTO p5g4.Project.SUPPLIES VALUES (5, 9);
INSERT INTO p5g4.Project.SUPPLIES VALUES (5, 10);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 11);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 12);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 13);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 14);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 15);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 16);
INSERT INTO p5g4.Project.SUPPLIES VALUES (6, 17);
INSERT INTO p5g4.Project.SUPPLIES VALUES (7, 18);
INSERT INTO p5g4.Project.SUPPLIES VALUES (7, 19);
INSERT INTO p5g4.Project.SUPPLIES VALUES (7, 20);

-- insert 12 supplier contacts
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('123456123', 6, 6, '2023-06-15 09:24:32', 'Ordering more products');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('234129765', 4, 6, '2023-06-17 14:58:21', 'Needed to see availability');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('234889889', 5, 7, '2023-06-19 08:37:45', 'Ordering more Beret Hats');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('234889889', 5, 6, '2023-06-14 17:12:03', 'Checking if Baseball Cap are available for order');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('234889889', 5, 6, '2023-06-18 21:30:57', 'Called the company');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('199124587', 2, 1, '2023-06-16 12:45:29', 'Contacted the company to discuss prices');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('199124587', 2, 2, '2023-06-20 07:03:14', 'Ordered more Nintendo Switch Console');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('200010010', 3, 3, '2023-06-15 23:55:02', 'Price negotiation');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('200010010', 3, 1, '2023-06-18 05:42:36', 'Called the company');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('244729300', 1, 3, '2023-06-17 18:19:47', 'Seeing availability of Amazon Echo Dot (4th Generation)');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('244729300', 1, 4, '2023-06-19 16:28:10', 'Discused prices');
INSERT INTO p5g4.Project.CONTACT_SUPPLIER (ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription) VALUES ('244729300', 1, 5, '2023-06-16 08:12:55', 'Ordered more Dyson V11 Cordless Vacuum Cleaner');

--insert 6 transport
INSERT INTO p5g4.Project.TRANSPORT VALUES (1, 1, 12.99, 'Plane', 'hts@example.com', 'Horizon Transport Solutions');
INSERT INTO p5g4.Project.TRANSPORT VALUES (2, 1, 6.99, 'Car', 'hts@example.com', 'Horizon Transport Solutions');
INSERT INTO p5g4.Project.TRANSPORT VALUES (3, 0, 3.99, 'Car', 'hts@example.com', 'Horizon Transport Solutions');
INSERT INTO p5g4.Project.TRANSPORT VALUES (4, 1, 2.99, 'Boat', 'swifttlogistics@example.com', 'SwiftTrans Logistics');
INSERT INTO p5g4.Project.TRANSPORT VALUES (5, 1, 9.99, 'Plane', 'swifttlogistics@example.com', 'SwiftTrans Logistics');
INSERT INTO p5g4.Project.TRANSPORT VALUES (6, 0, 5.99, 'Car', 'transmax.express@example.com', 'TransMax Express');

-- insert into contact transport --> 3
INSERT INTO p5g4.Project.CONTACT_TRANSPORT (ManagerNIF, ManagerID, TransportNumber, ContactDate, ContactDescription) VALUES ('199124587', 2, 1, '2023-06-15 19:41:22', 'Contacted company regarding prices');
INSERT INTO p5g4.Project.CONTACT_TRANSPORT (ManagerNIF, ManagerID, TransportNumber, ContactDate, ContactDescription) VALUES ('123456123', 6, 5, '2023-06-20 09:03:18', 'Checking Plane availabilty for more orders');
INSERT INTO p5g4.Project.CONTACT_TRANSPORT (ManagerNIF, ManagerID, TransportNumber, ContactDate, ContactDescription) VALUES ('234129765', 4, 4, '2023-05-17 13:27:09', 'Talked prices');