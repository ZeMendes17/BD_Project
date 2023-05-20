-- use groups DB
USE p5g4;
GO;

-- drops the schema if it exists in the DB
DROP SCHEMA IF EXISTS Project;
GO;

-- creates the schema
CREATE SCHEMA Project;
GO;

-- table drops/ constraint drops
DROP TABLE Project.PERSON;
DROP TABLE Project.[USER];
DROP TABLE Project.COSTUMER;
DROP TABLE Project.STORE;
DROP TABLE Project.SUPPLIER;
DROP TABLE Project.STAFF;
DROP TABLE Project.MANAGER;
DROP TABLE Project.[ORDER]
DROP TABLE Project.MANAGES;
DROP TABLE Project.ITEM;
DROP TABLE Project.ITEM_ORDER;
DROP TABLE Project.SUPPLIES;
DROP TABLE Project.CONTACT_SUPPLIER;
DROP TABLE Project.TRASPORT;
DROP TABLE Project.CONTACT_TRANSPORT;
GO;

-- create tables needed
CREATE TABLE Project.PERSON (
    NIF         CHAR(9) NOT NULL,
    [Address]   VARCHAR(30),
    PName       VARCHAR(20),
    PhoneNumb   CHAR(9),
    Email       VARCHAR(30) NOT NULL,
    BirthDate   DATE

    PRIMARY KEY (NIF),
    UNIQUE (Email)
);

CREATE TABLE Project.[USER] (
    UserNIF         CHAR(9) NOT NULL,
    ID              INT NOT NULL,
    RegisterDate    DATE,
    UserPassword    VARCHAR(20),
    UserName        VARCHAR(30) NOT NULL,
    Salary          INT,

    PRIMARY KEY (UserNIF, ID),
    FOREIGN KEY (UserNIF) REFERENCES Project.PERSON (NIF) ON UPDATE CASCADE ON DELETE CASCADE,
    UNIQUE (UserName)
);

CREATE TABLE Project.COSTUMER (
    CostumerNIF     CHAR(9) NOT NULL,

    PRIMARY KEY (CostumerNIF),
    FOREIGN KEY (CostumerNIF) REFERENCES Project.PERSON (NIF) ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE Project.STORE (
    StoreURL           VARCHAR(50) NOT NULL,
    StoreName           VARCHAR(20) NOT NULL,
    StoreDescription    VARCHAR(100),

    PRIMARY KEY (StoreURL),
    UNIQUE (StoreName)
);

CREATE TABLE Project.SUPPLIER (
    ID              INT NOT NULL,
    SupName         VARCHAR(20) NOT NULL,
    Email           VARCHAR(30),
    SupLocation     VARCHAR(30),

    PRIMARY KEY (ID),
    UNIQUE (SupName)
);

CREATE TABLE Project.STAFF (
    StaffNIF         CHAR(9) NOT NULL,
    ID               INT NOT NULL,
    StoreURL         VARCHAR(50),

    PRIMARY KEY (StaffNIF, ID),
    FOREIGN KEY (StaffNIF, ID) REFERENCES Project.[USERS] (UserNIF, ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (StoreURL) REFERENCES Project.STORE(StoreURL) ON UPDATE CASCADE
);

CREATE TABLE Project.MANAGER (
    ManagerNIF          CHAR(9) NOT NULL,
    ID                  INT NOT NULL,
    StoreURL            VARCHAR(50),

    PRIMARY KEY (ManagerNIF, ID),
    FOREIGN KEY (ManagerNIF, ID) REFERENCES Project.[USERS] (UserNIF, ID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (StoreURL) REFERENCES Project.STORE(StoreURL) ON UPDATE CASCADE
);

CREATE TABLE Project.[ORDER] (
    OrderNumber     INT NOT NULL,
    CostumerNIF     CHAR(9) NOT NULL,
    Price           DECIMAL(6, 2) NOT NULL CHECK (Price > 0),
    OrderState      VARCHAR(15),
    NumItems        INT,
    StoreURL        VARCHAR(50),

    PRIMARY KEY (OrderNumber, CostumerNIF),
    FOREIGN KEY (CostumerNIF) REFERENCES Project.COSTUMER (CostumerNIF) ON DELETE SET NULL,
    FOREIGN KEY (StoreURL) REFERENCES Project.STORE (StoreURL) ON DELETE CASCADE
);

CREATE TABLE Project.MANAGES(
    StaffNIF        CHAR(9) NOT NULL,
    StaffID         INT NOT NULL,
    OrderNumber     INT NOT NULL,

    PRIMARY KEY (StaffNIF, StaffID, OrderNumber),
    FOREIGN KEY (StaffNIF, StaffID) REFERENCES Project.STAFF (StaffNIF, ID) ON UPDATE CASCADE,
    FOREIGN KEY (OrderNumber) REFERENCES Project.[ORDER] (OrderNumber) ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE Project.ITEM(
    ID                  INT NOT NULL,
    -- SupplierID          INT NOT NULL,
    ItemDescription     VARCHAR(50),
    Price               DECIMAL(6,2) NOT NULL CHECK (Price > 0),
    Quantity            INT,
    StoreURL            VARCHAR(50),

    PRIMARY KEY (ID), -- SupplierID
    -- FOREIGN KEY (SupplierID) REFERENCES Project.SUPPLIER (ID),
    FOREIGN KEY (StoreURL) REFERENCES Project.STORE (StoreURL) 
);

CREATE TABLE Project.ITEM_ORDER(
    OrderNumber         INT NOT NULL,
    ItemID              INT NOT NULL,

    PRIMARY KEY (OrderNumber, ItemID),
    FOREIGN KEY (OrderNumber) REFERENCES Project.[ORDER] (OrderNumber) ON UPDATE CASCADE,
    FOREIGN KEY (ItemID) REFERENCES Project.ITEM (ID) ON UPDATE CASCADE
);

CREATE TABLE Project.SUPPLIES(
    SupplierID  INT NOT NULL,
    ItemID      INT NOT NULL,

    PRIMARY KEY (SupplierID, ItemID),
    FOREIGN KEY (SupplierID) REFERENCES Project.SUPPLIER (ID) ON UPDATE CASCADE,
    FOREIGN KEY (ItemID) REFERENCES Project.ITEM (ID) ON UPDATE CASCADE
);

CREATE TABLE Project.CONTACT_SUPPLIER(
    ManagerNIF      CHAR(9) NOT NULL,
    ManagerID       INT NOT NULL,
    SupplierID      INT NOT NULL,

    PRIMARY KEY (ManagerNIF, ManagerID, SupplierID),
    FOREIGN KEY (ManagerNIF, ManagerID) REFERENCES Project.Manager (ManagerNIF, ID) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (SupplierID) REFERENCES Project.SUPPLIER (ID) ON UPDATE CASCADE
);

CREATE TABLE Project.TRANSPORT(
    TransportNumber INT NOT NULL,
    OrderNumber     INT NOT NULL,
    Availabilty     BINARY,
    Cost            DECIMAL(6,2),
    Method          VARCHAR(15),
    CompanyEmail    VARCHAR(30),
    CompanyName     VARCHAR(15),

    PRIMARY KEY (TransportNumber, OrderNumber),
    FOREIGN KEY (OrderNumber) REFERENCES Project.[ORDER] (OrderNumber) ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE Project.CONTACT_TRANSPORT(
    ManagerNIF      CHAR(9) NOT NULL,
    ManagerID       INT NOT NULL,
    TransportNumber INT NOT NULL,

    PRIMARY KEY (ManagerNIF, ManagerID, TransportNumber),
    FOREIGN KEY (ManagerNIF, ManagerID) REFERENCES Project.Manager (ManagerNIF, ID) ON UPDATE CASCADE ON DELETE SET NULL,
    FOREIGN KEY (TransportNumber) REFERENCES Project.TRANSPORT (TransportNumber) ON UPDATE CASCADE
);