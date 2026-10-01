## 1251. Average Selling Price

**Difficulty:** Easy
**Topics:** `LEFT JOIN`, `INNER JOIN`, `SUM()`, `ROUND()`, `COALESCE()`, `GROUP BY`

### Problem

We need to calculate the **weighted average selling price** for every product.

Formula:

```text
Average Price = SUM(price × units) / SUM(units)
```

Important: The price depends on the **purchase date**, so we need to match each sale with the correct price period.

### SQL Solution

```sql
SELECT
    p.product_id,
    ROUND(
        COALESCE(SUM(p.price * u.units) / SUM(u.units), 0),
        2
    ) AS average_price
FROM Prices p
LEFT JOIN UnitsSold u
    ON p.product_id = u.product_id
   AND u.purchase_date BETWEEN p.start_date AND p.end_date
GROUP BY p.product_id;
```

### Explanation

#### 1. Match the product

```sql
p.product_id = u.product_id
```

We only want sales belonging to the same product.

#### 2. Match the price period

```sql
u.purchase_date BETWEEN p.start_date AND p.end_date
```

For example:

```text
Product 1
2019-02-17 → 2019-02-28 → $5
2019-03-01 → 2019-03-22 → $20
```

A sale on `2019-02-25` gets price `$5`.

A sale on `2019-03-01` gets price `$20`.

#### 3. Calculate total revenue

```sql
SUM(p.price * u.units)
```

For product 1:

```text
5 × 100 = 500
20 × 15 = 300

Total = 800
```

#### 4. Calculate total units

```sql
SUM(u.units)
```

```text
100 + 15 = 115
```

Therefore:

```text
800 / 115 = 6.9565...
```

#### 5. Round to 2 decimals

```sql
ROUND(..., 2)
```

Result:

```text
6.96
```

#### 6. Why `LEFT JOIN`?

The problem says:

> If a product does not have any sold units, its average selling price is 0.

`LEFT JOIN` ensures that products from `Prices` remain in the result even when there is no matching row in `UnitsSold`.

Then:

```sql
COALESCE(..., 0)
```

converts the resulting `NULL` into `0`.

### Key Concepts

* `LEFT JOIN` → keep products even without sales
* `BETWEEN` → identify the applicable price period
* `SUM(price * units)` → total revenue
* `SUM(units)` → total units sold
* `COALESCE()` → replace `NULL` with `0`
* `ROUND(..., 2)` → two decimal places
* `GROUP BY product_id` → calculate separately for each product

**Mental model:**

```text
Prices
   ↓
Find matching product
   ↓
Find price period containing purchase_date
   ↓
price × units
   ↓
SUM(revenue) / SUM(units)
   ↓
ROUND to 2 decimals
```
