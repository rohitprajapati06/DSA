# 1068. Product Sales Analysis I

**Difficulty:** Easy
**Topic:** `INNER JOIN`

## Problem

Write a SQL query to report the:

* `product_name`
* `year`
* `price`

for every sale in the `Sales` table.

---

## Table: `Sales`

```text
+-------------+-------+
| Column Name | Type  |
+-------------+-------+
| sale_id     | int   |
| product_id  | int   |
| year        | int   |
| quantity    | int   |
| price       | int   |
+-------------+-------+
```

* `(sale_id, year)` is the primary key.
* `product_id` is a foreign key referencing the `Product` table.
* `price` is the price **per unit**.

## Table: `Product`

```text
+--------------+---------+
| Column Name  | Type    |
+--------------+---------+
| product_id   | int     |
| product_name | varchar |
+--------------+---------+
```

* `product_id` is the primary key.
* Each product has a corresponding product name.

---

## Example Input

### Sales

```text
+---------+------------+------+----------+-------+
| sale_id | product_id | year | quantity | price |
+---------+------------+------+----------+-------+
| 1       | 100        | 2008 | 10       | 5000  |
| 2       | 100        | 2009 | 12       | 5000  |
| 7       | 200        | 2011 | 15       | 9000  |
+---------+------------+------+----------+-------+
```

### Product

```text
+------------+--------------+
| product_id | product_name |
+------------+--------------+
| 100        | Nokia        |
| 200        | Apple        |
| 300        | Samsung      |
+------------+--------------+
```

---

## Expected Output

```text
+--------------+------+-------+
| product_name | year | price |
+--------------+------+-------+
| Nokia        | 2008 | 5000  |
| Nokia        | 2009 | 5000  |
| Apple        | 2011 | 9000  |
+--------------+------+-------+
```

---

## SQL Solution

```sql
SELECT
    p.product_name,
    s.year,
    s.price
FROM Sales s
INNER JOIN Product p
    ON s.product_id = p.product_id;
```

## Explanation

The `Sales` table contains the `product_id`, but not the product name.

The `Product` table contains:

```text
product_id → product_name
```

So we join the two tables using:

```sql
s.product_id = p.product_id
```

For example:

```text
Sales                         Product
-----------                   -----------
product_id = 100  ─────────→  Nokia
product_id = 200  ─────────→  Apple
```

Then we select only the required columns:

```sql
p.product_name,
s.year,
s.price
```

### Key Concept

**`INNER JOIN`**

Use `INNER JOIN` when you need records that have a **matching value in both tables**.
