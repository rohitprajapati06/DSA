
## SQL Question : Customers Who Visited but Did Not Make Any Transactions

### Problem

You are given two tables: `Visits` and `Transactions`.

Find the `customer_id` of customers who visited the mall **without making any transactions**, along with the number of such visits.

Return the result in any order.

---

### Table: `Visits`

```text
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| visit_id    | int     |
| customer_id | int     |
+-------------+---------+
```

* `visit_id` is unique.
* Each row represents a customer visiting the mall.

### Table: `Transactions`

```text
+----------------+---------+
| Column Name    | Type    |
+----------------+---------+
| transaction_id | int     |
| visit_id       | int     |
| amount         | int     |
+----------------+---------+
```

* `transaction_id` is unique.
* Each row represents a transaction made during a particular visit.

---

## Example Input

### Visits

```text
+----------+-------------+
| visit_id | customer_id |
+----------+-------------+
| 1        | 23          |
| 2        | 9           |
| 4        | 30          |
| 5        | 54          |
| 6        | 96          |
| 7        | 54          |
| 8        | 54          |
+----------+-------------+
```

### Transactions

```text
+----------------+----------+--------+
| transaction_id | visit_id | amount |
+----------------+----------+--------+
| 2              | 5        | 310    |
| 3              | 5        | 300    |
| 9              | 5        | 200    |
| 12             | 1        | 910    |
| 13             | 2        | 970    |
+----------------+----------+--------+
```

---

## Expected Output

```text
+-------------+----------------+
| customer_id | count_no_trans |
+-------------+----------------+
| 54          | 2              |
| 30          | 1              |
| 96          | 1              |
+-------------+----------------+
```

---

## Explanation

| Customer | Visit IDs | Transaction? | No-transaction visits |
| -------: | --------- | ------------ | --------------------: |
|       23 | 1         | Yes          |                     0 |
|        9 | 2         | Yes          |                     0 |
|       30 | 4         | No           |                     1 |
|       54 | 5, 7, 8   | Yes, No, No  |                     2 |
|       96 | 6         | No           |                     1 |

Therefore:

* Customer `30` → **1** visit without transaction
* Customer `54` → **2** visits without transaction
* Customer `96` → **1** visit without transaction

---

## SQL Solution

```sql
SELECT 
    v.customer_id,
    COUNT(*) AS count_no_trans
FROM Visits v
LEFT JOIN Transactions t
    ON v.visit_id = t.visit_id
WHERE t.transaction_id IS NULL
GROUP BY v.customer_id;
```

### How it works

```text
Visits
   |
   | LEFT JOIN
   ↓
Transactions
   |
   | transaction_id IS NULL
   ↓
Visits without transactions
   |
   | GROUP BY customer_id
   ↓
COUNT visits
```

### Key SQL Concepts

* `LEFT JOIN` → keeps every visit.
* `IS NULL` → identifies visits with no transaction.
* `GROUP BY` → groups those visits by customer.
* `COUNT(*)` → counts how many no-transaction visits each customer had.

**Interview pattern to remember:**

```sql
LEFT JOIN
WHERE right_table.id IS NULL
GROUP BY
```

This pattern is commonly used to find **records that exist in one table but have no matching record in another table**.
