# 1757. Recyclable and Low Fat Products

**Difficulty:** Easy
**Topic:** `WHERE`, `AND`

## Problem

Find the IDs of products that are **both**:

* Low fat (`low_fats = 'Y'`)
* Recyclable (`recyclable = 'Y'`)

---

## Table: `Products`

```text
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| product_id  | int     |
| low_fats    | enum    |
| recyclable  | enum    |
+-------------+---------+
```

* `product_id` is the primary key.
* `low_fats` can be `'Y'` or `'N'`.
* `recyclable` can be `'Y'` or `'N'`.

---

## Example Input

```text
+------------+----------+------------+
| product_id | low_fats | recyclable |
+------------+----------+------------+
| 0          | Y        | N          |
| 1          | Y        | Y          |
| 2          | N        | Y          |
| 3          | Y        | Y          |
| 4          | N        | N          |
+------------+----------+------------+
```

## Expected Output

```text
+------------+
| product_id |
+------------+
| 1          |
| 3          |
+------------+
```

---

## SQL Solution

```sql
SELECT product_id
FROM Products
WHERE low_fats = 'Y'
  AND recyclable = 'Y';
```

## Explanation

We need products satisfying **both conditions**, so we use `AND`:

```sql
WHERE low_fats = 'Y'
  AND recyclable = 'Y'
```

Checking the data:

* Product `0` → low fat but not recyclable ❌
* Product `1` → low fat and recyclable ✅
* Product `2` → not low fat ❌
* Product `3` → low fat and recyclable ✅
* Product `4` → neither ❌

Therefore, the answer is **1 and 3**.

### Key Concept

```sql
WHERE condition1
  AND condition2
```

Use `AND` when **all specified conditions must be true**.
