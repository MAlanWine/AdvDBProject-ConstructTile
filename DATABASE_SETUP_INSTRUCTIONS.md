# Database Setup Instructions for ConstructTile System

## Student Information
- **Student ID**: A207421
- **Shop Name**: ConstructTile
- **Database File**: DB_CONSTRUCTTILE_A207421.accdb
- **Location**: `.\prj_constructtile_a207421\bin\Debug\`

---

## Step 1: Create Database in Microsoft Access

1. Open **Microsoft Access**
2. Click **Blank Database**
3. Name the database: `DB_CONSTRUCTTILE_A207421.accdb`
4. Save it to: `C:\Users\AlanWine\Documents\VSProjects\prj_constructtile_a207421\prj_constructtile_a207421\bin\Debug\`
5. Click **Create**

---

## Step 2: Create Tables

### Method A: Using SQL (Recommended)

1. In Access, go to **Create** → **Query Design**
2. Close the "Show Table" dialog
3. Click **SQL View** button
4. Copy and paste each CREATE TABLE statement from `DATABASE_CREATION_SCRIPT.sql`
5. Click **Run** (the red exclamation mark) for each table
6. Repeat for all 5 tables

### Method B: Using Table Design View

If SQL doesn't work, create tables manually:

#### Table 1: TBL_PRODUCTS_A207421
| Field Name | Data Type | Field Size | Primary Key |
|------------|-----------|------------|-------------|
| FLD_PRODUCT_ID | Short Text | 10 | Yes (✓) |
| FLD_PRODUCT_NAME | Short Text | 100 | |
| FLD_PRICE | Currency | | |
| FLD_BRAND | Short Text | 50 | |
| FLD_TYPE | Short Text | 20 | |
| FLD_MATERIAL | Short Text | 50 | |
| FLD_SIZE | Short Text | 30 | |
| FLD_QUANTITY | Number (Integer) | | |

#### Table 2: TBL_STAFF_A207421
| Field Name | Data Type | Field Size | Primary Key |
|------------|-----------|------------|-------------|
| FLD_STAFF_ID | Short Text | 10 | Yes (✓) |
| FLD_STAFF_NAME | Short Text | 100 | |
| FLD_POSITION | Short Text | 50 | |
| FLD_EMAIL | Short Text | 100 | |
| FLD_PHONE | Short Text | 20 | |

#### Table 3: TBL_CUSTOMERS_A207421
| Field Name | Data Type | Field Size | Primary Key |
|------------|-----------|------------|-------------|
| FLD_CUSTOMER_ID | Short Text | 10 | Yes (✓) |
| FLD_CUSTOMER_NAME | Short Text | 100 | |
| FLD_EMAIL | Short Text | 100 | |
| FLD_PHONE | Short Text | 20 | |
| FLD_ADDRESS | Short Text | 200 | |

#### Table 4: TBL_ORDERS_A207421
| Field Name | Data Type | Field Size | Primary Key |
|------------|-----------|------------|-------------|
| FLD_ORDER_ID | Short Text | 10 | Yes (✓) |
| FLD_CUSTOMER_ID | Short Text | 10 | |
| FLD_STAFF_ID | Short Text | 10 | |
| FLD_ORDER_DATE | Date/Time | | |
| FLD_TOTAL_AMOUNT | Currency | | |

#### Table 5: TBL_ORDERDETAILS_A207421
| Field Name | Data Type | Field Size | Primary Key |
|------------|-----------|------------|-------------|
| FLD_ORDERDETAIL_ID | AutoNumber | | Yes (✓) |
| FLD_ORDER_ID | Short Text | 10 | |
| FLD_PRODUCT_ID | Short Text | 10 | |
| FLD_QUANTITY | Number (Integer) | | |
| FLD_SUBTOTAL | Currency | | |

---

## Step 3: Add Sample Data

### Insert Staff Data (3 records)
Go to **Create** → **Query Design** → **SQL View** and run:

```sql
INSERT INTO TBL_STAFF_A207421 (FLD_STAFF_ID, FLD_STAFF_NAME, FLD_POSITION, FLD_EMAIL, FLD_PHONE)
VALUES ('S001', 'Ahmad bin Hassan', 'Sales Manager', 'ahmad.hassan@constructtile.com', '013-2345678');

INSERT INTO TBL_STAFF_A207421 (FLD_STAFF_ID, FLD_STAFF_NAME, FLD_POSITION, FLD_EMAIL, FLD_PHONE)
VALUES ('S002', 'Siti Nurhaliza', 'Sales Associate', 'siti.nurhaliza@constructtile.com', '012-9876543');

INSERT INTO TBL_STAFF_A207421 (FLD_STAFF_ID, FLD_STAFF_NAME, FLD_POSITION, FLD_EMAIL, FLD_PHONE)
VALUES ('S003', 'Lee Chong Wei', 'Store Supervisor', 'lee.chongwei@constructtile.com', '016-5554321');
```

### Insert Customer Data (3 records)
```sql
INSERT INTO TBL_CUSTOMERS_A207421 (FLD_CUSTOMER_ID, FLD_CUSTOMER_NAME, FLD_EMAIL, FLD_PHONE, FLD_ADDRESS)
VALUES ('C001', 'Tan Ah Kow', 'tankow@email.com', '012-3456789', 'No. 45, Jalan Melati, Kuala Lumpur');

INSERT INTO TBL_CUSTOMERS_A207421 (FLD_CUSTOMER_ID, FLD_CUSTOMER_NAME, FLD_EMAIL, FLD_PHONE, FLD_ADDRESS)
VALUES ('C002', 'Fatimah Abdullah', 'fatimah.a@email.com', '013-9876543', 'Lot 123, Taman Sejahtera, Selangor');

INSERT INTO TBL_CUSTOMERS_A207421 (FLD_CUSTOMER_ID, FLD_CUSTOMER_NAME, FLD_EMAIL, FLD_PHONE, FLD_ADDRESS)
VALUES ('C003', 'Raj Kumar', 'raj.kumar88@email.com', '017-2468135', 'Unit 5-2, Kondominium Vista, Petaling Jaya');
```

### Insert Product Data
Copy all the INSERT statements for products from `DATABASE_CREATION_SCRIPT.sql` (Lines for F001-F015, W001-W015, R001-R012).
Run each INSERT statement or use the table datasheet view to enter data manually.

---

## Step 4: Set Up Relationships

1. Go to **Database Tools** → **Relationships**
2. Click **Show Table** and add all 5 tables
3. Create the following relationships by dragging from one field to another:

### Relationship 1: Customer → Orders
- Drag `FLD_CUSTOMER_ID` from **TBL_CUSTOMERS_A207421**
- Drop on `FLD_CUSTOMER_ID` in **TBL_ORDERS_A207421**
- Check **Enforce Referential Integrity**
- Check **Cascade Update Related Fields**
- Click **Create**

### Relationship 2: Staff → Orders
- Drag `FLD_STAFF_ID` from **TBL_STAFF_A207421**
- Drop on `FLD_STAFF_ID` in **TBL_ORDERS_A207421**
- Check **Enforce Referential Integrity**
- Check **Cascade Update Related Fields**
- Click **Create**

### Relationship 3: Orders → OrderDetails
- Drag `FLD_ORDER_ID` from **TBL_ORDERS_A207421**
- Drop on `FLD_ORDER_ID` in **TBL_ORDERDETAILS_A207421**
- Check **Enforce Referential Integrity**
- Check **Cascade Update Related Fields**
- Check **Cascade Delete Related Records**
- Click **Create**

### Relationship 4: Products → OrderDetails
- Drag `FLD_PRODUCT_ID` from **TBL_PRODUCTS_A207421**
- Drop on `FLD_PRODUCT_ID` in **TBL_ORDERDETAILS_A207421**
- Check **Enforce Referential Integrity**
- Check **Cascade Update Related Fields**
- Click **Create**

4. Save the relationships layout
5. The relationship view should show "1" and "∞" symbols indicating One-to-Many relationships

---

## Step 5: Create Pictures Folder

1. Create a folder: `C:\Users\AlanWine\Documents\VSProjects\prj_constructtile_a207421\prj_constructtile_a207421\bin\Debug\pictures\`
2. Add product images named by Product ID (e.g., F001.jpg, W001.jpg, R001.jpg)
3. You can download tile images from websites like amazon.com, homedepot.com, or use placeholder images

---

## Verification Checklist

- [ ] Database file created: `DB_CONSTRUCTTILE_A207421.accdb`
- [ ] All 5 tables created with correct field names and data types
- [ ] Primary keys set for all tables
- [ ] 3 staff records inserted
- [ ] 3 customer records inserted
- [ ] 42 product records inserted (15 Floor, 15 Wall, 12 Roof)
- [ ] 4 relationships created with referential integrity enforced
- [ ] All relationships show correct cardinality (1:∞)
- [ ] Database saved in `bin\Debug\` directory
- [ ] Pictures folder created in `bin\Debug\` directory

---

## Database Normalization Compliance

This database design is normalized to **Third Normal Form (3NF)**:

### 1NF (First Normal Form):
- All tables have primary keys
- All fields contain atomic values (no repeating groups)
- Each field contains only one value

### 2NF (Second Normal Form):
- All tables are in 1NF
- All non-key attributes are fully dependent on the primary key
- No partial dependencies exist

### 3NF (Third Normal Form):
- All tables are in 2NF
- No transitive dependencies exist
- All non-key attributes depend only on the primary key

### Entity Relationships:
- **One Customer** can have **Many Orders** (1:N)
- **One Staff** can process **Many Orders** (1:N)
- **One Order** can contain **Many Products** via OrderDetails (1:N)
- **One Product** can be in **Many Orders** via OrderDetails (1:N)
- **Many-to-Many** relationship between Orders and Products is resolved through the junction table TBL_ORDERDETAILS_A207421

---

## Troubleshooting

### Issue: "Could not find installable ISAM"
**Solution**: Make sure you're using `Provider=Microsoft.ACE.OLEDB.12.0` and have Microsoft Access Database Engine installed.

### Issue: "Cannot create relationship"
**Solution**: Ensure that the foreign key values exist in the parent table before creating relationships.

### Issue: SQL syntax errors
**Solution**: Use the Table Design View to create tables manually instead of SQL queries.

### Issue: Connection string error in VB.NET
**Solution**: Verify that the database file is in the correct location: `.\bin\Debug\DB_CONSTRUCTTILE_A207421.accdb`