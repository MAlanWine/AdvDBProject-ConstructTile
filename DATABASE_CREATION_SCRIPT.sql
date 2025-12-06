-- ========================================
-- ConstructTile Database Creation Script
-- Student ID: A207421
-- Database: DB_CONSTRUCTTILE_A207421.accdb
-- ========================================

-- NOTE: Execute this script in Microsoft Access Query Designer
-- Create each table one by one, then add relationships in Relationship View

-- ========================================
-- TABLE 1: TBL_PRODUCTS_A207421
-- ========================================
CREATE TABLE TBL_PRODUCTS_A207421 (
    FLD_PRODUCT_ID VARCHAR(10) PRIMARY KEY,
    FLD_PRODUCT_NAME VARCHAR(100) NOT NULL,
    FLD_PRICE CURRENCY NOT NULL,
    FLD_BRAND VARCHAR(50) NOT NULL,
    FLD_TYPE VARCHAR(20) NOT NULL,
    FLD_MATERIAL VARCHAR(50),
    FLD_SIZE VARCHAR(30),
    FLD_QUANTITY INTEGER DEFAULT 0
);

-- ========================================
-- TABLE 2: TBL_STAFF_A207421
-- ========================================
CREATE TABLE TBL_STAFF_A207421 (
    FLD_STAFF_ID VARCHAR(10) PRIMARY KEY,
    FLD_STAFF_NAME VARCHAR(100) NOT NULL,
    FLD_POSITION VARCHAR(50) NOT NULL,
    FLD_EMAIL VARCHAR(100),
    FLD_PHONE VARCHAR(20)
);

-- ========================================
-- TABLE 3: TBL_CUSTOMERS_A207421
-- ========================================
CREATE TABLE TBL_CUSTOMERS_A207421 (
    FLD_CUSTOMER_ID VARCHAR(10) PRIMARY KEY,
    FLD_CUSTOMER_NAME VARCHAR(100) NOT NULL,
    FLD_EMAIL VARCHAR(100),
    FLD_PHONE VARCHAR(20),
    FLD_ADDRESS VARCHAR(200)
);

-- ========================================
-- TABLE 4: TBL_ORDERS_A207421
-- ========================================
CREATE TABLE TBL_ORDERS_A207421 (
    FLD_ORDER_ID VARCHAR(10) PRIMARY KEY,
    FLD_CUSTOMER_ID VARCHAR(10) NOT NULL,
    FLD_STAFF_ID VARCHAR(10) NOT NULL,
    FLD_ORDER_DATE DATETIME DEFAULT NOW(),
    FLD_TOTAL_AMOUNT CURRENCY DEFAULT 0,
    FOREIGN KEY (FLD_CUSTOMER_ID) REFERENCES TBL_CUSTOMERS_A207421(FLD_CUSTOMER_ID),
    FOREIGN KEY (FLD_STAFF_ID) REFERENCES TBL_STAFF_A207421(FLD_STAFF_ID)
);

-- ========================================
-- TABLE 5: TBL_ORDERDETAILS_A207421
-- (Junction table for many-to-many relationship)
-- ========================================
CREATE TABLE TBL_ORDERDETAILS_A207421 (
    FLD_ORDERDETAIL_ID AUTOINCREMENT PRIMARY KEY,
    FLD_ORDER_ID VARCHAR(10) NOT NULL,
    FLD_PRODUCT_ID VARCHAR(10) NOT NULL,
    FLD_QUANTITY INTEGER NOT NULL DEFAULT 1,
    FLD_SUBTOTAL CURRENCY DEFAULT 0,
    FOREIGN KEY (FLD_ORDER_ID) REFERENCES TBL_ORDERS_A207421(FLD_ORDER_ID),
    FOREIGN KEY (FLD_PRODUCT_ID) REFERENCES TBL_PRODUCTS_A207421(FLD_PRODUCT_ID)
);

-- ========================================
-- SAMPLE DATA: Staff (3 staff members)
-- ========================================
INSERT INTO TBL_STAFF_A207421 (FLD_STAFF_ID, FLD_STAFF_NAME, FLD_POSITION, FLD_EMAIL, FLD_PHONE)
VALUES
('S001', 'Ahmad bin Hassan', 'Sales Manager', 'ahmad.hassan@constructtile.com', '013-2345678'),
('S002', 'Siti Nurhaliza', 'Sales Associate', 'siti.nurhaliza@constructtile.com', '012-9876543'),
('S003', 'Lee Chong Wei', 'Store Supervisor', 'lee.chongwei@constructtile.com', '016-5554321');

-- ========================================
-- SAMPLE DATA: Customers (3 customers)
-- ========================================
INSERT INTO TBL_CUSTOMERS_A207421 (FLD_CUSTOMER_ID, FLD_CUSTOMER_NAME, FLD_EMAIL, FLD_PHONE, FLD_ADDRESS)
VALUES
('C001', 'Tan Ah Kow', 'tankow@email.com', '012-3456789', 'No. 45, Jalan Melati, Kuala Lumpur'),
('C002', 'Fatimah Abdullah', 'fatimah.a@email.com', '013-9876543', 'Lot 123, Taman Sejahtera, Selangor'),
('C003', 'Raj Kumar', 'raj.kumar88@email.com', '017-2468135', 'Unit 5-2, Kondominium Vista, Petaling Jaya');

-- ========================================
-- SAMPLE DATA: Products (40+ products)
-- ========================================

-- Floor Tiles (15 products)
INSERT INTO TBL_PRODUCTS_A207421 (FLD_PRODUCT_ID, FLD_PRODUCT_NAME, FLD_PRICE, FLD_BRAND, FLD_TYPE, FLD_MATERIAL, FLD_SIZE, FLD_QUANTITY)
VALUES
('F001', 'Marble Look Porcelain Floor Tile', 89.90, 'CeramicaPro', 'Floor', 'Porcelain', '600x600mm', 150),
('F002', 'Wood Effect Floor Tile Oak', 75.50, 'NaturalStone', 'Floor', 'Ceramic', '200x1000mm', 200),
('F003', 'Polished Granite Floor Tile', 95.00, 'GraniteMax', 'Floor', 'Granite', '600x600mm', 120),
('F004', 'Matte Black Floor Tile', 65.00, 'ModernTile', 'Floor', 'Porcelain', '300x600mm', 180),
('F005', 'Beige Travertine Floor Tile', 110.00, 'NaturalStone', 'Floor', 'Travertine', '400x400mm', 95),
('F006', 'Grey Cement Look Floor Tile', 72.50, 'IndustrialChic', 'Floor', 'Porcelain', '600x600mm', 160),
('F007', 'White Carrara Marble Floor Tile', 125.00, 'MarbleLux', 'Floor', 'Marble', '600x600mm', 80),
('F008', 'Hexagon Mosaic Floor Tile', 58.00, 'MosaicArt', 'Floor', 'Ceramic', '300x300mm', 220),
('F009', 'Terracotta Floor Tile', 68.90, 'Rustica', 'Floor', 'Terracotta', '400x400mm', 140),
('F010', 'Slate Effect Floor Tile', 82.00, 'NaturalStone', 'Floor', 'Porcelain', '300x600mm', 110),
('F011', 'Glossy White Floor Tile', 55.00, 'BrightHome', 'Floor', 'Ceramic', '300x300mm', 250),
('F012', 'Concrete Look Floor Tile', 78.50, 'IndustrialChic', 'Floor', 'Porcelain', '600x600mm', 130),
('F013', 'Brown Wood Plank Floor Tile', 88.00, 'WoodLook', 'Floor', 'Ceramic', '200x1200mm', 105),
('F014', 'Patterned Encaustic Floor Tile', 92.00, 'VintageStyle', 'Floor', 'Cement', '200x200mm', 190),
('F015', 'Anti-Slip Outdoor Floor Tile', 71.00, 'SafeStep', 'Floor', 'Porcelain', '300x300mm', 175);

-- Wall Tiles (15 products)
INSERT INTO TBL_PRODUCTS_A207421 (FLD_PRODUCT_ID, FLD_PRODUCT_NAME, FLD_PRICE, FLD_BRAND, FLD_TYPE, FLD_MATERIAL, FLD_SIZE, FLD_QUANTITY)
VALUES
('W001', 'Subway White Wall Tile', 45.00, 'MetroStyle', 'Wall', 'Ceramic', '75x150mm', 300),
('W002', 'Blue Moroccan Wall Tile', 62.50, 'ExoticDesign', 'Wall', 'Ceramic', '200x200mm', 180),
('W003', 'Glass Mosaic Wall Tile Silver', 98.00, 'GlassArt', 'Wall', 'Glass', '300x300mm', 95),
('W004', 'Textured Stone Wall Tile', 85.00, 'NaturalStone', 'Wall', 'Stone', '150x600mm', 120),
('W005', 'Glossy Black Wall Tile', 52.00, 'ModernTile', 'Wall', 'Ceramic', '200x400mm', 210),
('W006', 'Cream Marble Effect Wall Tile', 73.50, 'MarbleLux', 'Wall', 'Porcelain', '300x600mm', 145),
('W007', 'Wood Panel Wall Tile', 79.00, 'WoodLook', 'Wall', 'Ceramic', '150x900mm', 110),
('W008', 'Geometric Pattern Wall Tile', 66.00, 'GeometricArt', 'Wall', 'Ceramic', '200x200mm', 190),
('W009', 'Brick Effect Wall Tile Red', 58.50, 'IndustrialChic', 'Wall', 'Ceramic', '60x240mm', 230),
('W010', 'White Gloss Beveled Wall Tile', 49.00, 'ClassicWhite', 'Wall', 'Ceramic', '100x200mm', 280),
('W011', 'Turquoise Blue Wall Tile', 61.00, 'ColorPop', 'Wall', 'Ceramic', '200x200mm', 165),
('W012', 'Marble Hexagon Wall Tile', 87.00, 'MarbleLux', 'Wall', 'Marble', '200x230mm', 90),
('W013', '3D Wave Pattern Wall Tile', 94.50, 'ModernArt', 'Wall', 'Porcelain', '250x750mm', 75),
('W014', 'Grey Stone Ledger Wall Tile', 102.00, 'NaturalStone', 'Wall', 'Stone', '150x600mm', 85),
('W015', 'Mint Green Wall Tile', 54.00, 'ColorPop', 'Wall', 'Ceramic', '200x300mm', 200);

-- Roof Tiles (12 products)
INSERT INTO TBL_PRODUCTS_A207421 (FLD_PRODUCT_ID, FLD_PRODUCT_NAME, FLD_PRICE, FLD_BRAND, FLD_TYPE, FLD_MATERIAL, FLD_SIZE, FLD_QUANTITY)
VALUES
('R001', 'Terracotta Clay Roof Tile', 135.00, 'RoofMaster', 'Roof', 'Clay', '420x330mm', 400),
('R002', 'Concrete Roof Tile Grey', 98.00, 'DuraRoof', 'Roof', 'Concrete', '420x330mm', 500),
('R003', 'Spanish Style Roof Tile Red', 145.00, 'MediterraneanRoof', 'Roof', 'Clay', '400x300mm', 350),
('R004', 'Slate Roof Tile Black', 185.00, 'NaturalStone', 'Roof', 'Slate', '600x300mm', 250),
('R005', 'Metal Roof Tile Green', 125.00, 'MetalRoof', 'Roof', 'Metal', '1200x400mm', 180),
('R006', 'Flat Concrete Roof Tile', 88.00, 'ModernRoof', 'Roof', 'Concrete', '420x330mm', 450),
('R007', 'Solar Reflective Roof Tile', 165.00, 'EcoRoof', 'Roof', 'Concrete', '420x330mm', 200),
('R008', 'Traditional Clay Roof Tile Brown', 132.00, 'Heritage', 'Roof', 'Clay', '420x330mm', 380),
('R009', 'Lightweight Polymer Roof Tile', 155.00, 'TechRoof', 'Roof', 'Polymer', '1000x350mm', 150),
('R010', 'Double Roman Roof Tile', 142.00, 'RoofMaster', 'Roof', 'Concrete', '420x330mm', 320),
('R011', 'Interlocking Roof Tile Charcoal', 138.00, 'SecureRoof', 'Roof', 'Concrete', '420x330mm', 290),
('R012', 'Glazed Roof Tile Blue', 175.00, 'ColorRoof', 'Roof', 'Clay', '400x300mm', 160);

-- ========================================
-- RELATIONSHIPS (Set up in Access GUI)
-- ========================================
-- 1. TBL_ORDERS_A207421.FLD_CUSTOMER_ID -> TBL_CUSTOMERS_A207421.FLD_CUSTOMER_ID (One-to-Many)
-- 2. TBL_ORDERS_A207421.FLD_STAFF_ID -> TBL_STAFF_A207421.FLD_STAFF_ID (One-to-Many)
-- 3. TBL_ORDERDETAILS_A207421.FLD_ORDER_ID -> TBL_ORDERS_A207421.FLD_ORDER_ID (One-to-Many)
-- 4. TBL_ORDERDETAILS_A207421.FLD_PRODUCT_ID -> TBL_PRODUCTS_A207421.FLD_PRODUCT_ID (One-to-Many)
--
-- Enable "Enforce Referential Integrity" for all relationships in the Relationship View