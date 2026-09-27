# 584. Find Customer Referee

**Difficulty:** Easy
**Topic:** `WHERE`, `OR`, `IS NULL`

## Problem

Find the names of customers who satisfy either of these conditions:

1. They were referred by a customer whose `id` is **not 2**.
2. They were **not referred by anyone**.

---

## Table: `Customer`

```text
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| name        | varchar |
| referee_id  | int     |
+-------------+---------+
```

* `id` is the primary key.
* `referee_id` contains the ID of the customer who referred the customer.
* `referee_id = NULL` means the customer was not referred by anyone.

---

## Example Input

```text
+----+------+------------+
| id | name | referee_id |
+----+------+------------+
| 1  | Will | NULL       |
| 2  | Jane | NULL       |
| 3  | Alex | 2          |
| 4  | Bill | NULL       |
| 5  | Zack | 1          |
| 6  | Mark | 2          |
+----+------+------------+
```

## Expected Output

```text
+------+
| name |
+------+
| Will |
| Jane |
| Bill |
| Zack |
+------+
```

---

## SQL Solution

```sql
SELECT name
FROM Customer
WHERE referee_id != 2
   OR referee_id IS NULL;
```

## Explanation

We need customers who:

* Were referred by someone **other than customer 2**
* **OR** were not referred at all.

Let's check:

| Customer | `referee_id` | Include? |
| -------- | -----------: | -------- |
| Will     |         NULL | ✅        |
| Jane     |         NULL | ✅        |
| Alex     |            2 | ❌        |
| Bill     |         NULL | ✅        |
| Zack     |            1 | ✅        |
| Mark     |            2 | ❌        |

So the result is:

```text
Will
Jane
Bill
Zack
```

### Important SQL Concept: `NULL`

You **cannot** correctly check NULL using:

```sql
referee_id = NULL       -- ❌
referee_id != NULL      -- ❌
```

Instead use:

```sql
referee_id IS NULL      -- ✅
referee_id IS NOT NULL  -- ✅
```

### Key Concept

```sql
WHERE referee_id != 2
   OR referee_id IS NULL
```

This is a common interview pattern when a condition should include **both non-matching values and NULL values**.
