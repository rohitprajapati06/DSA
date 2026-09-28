# 197. Rising Temperature

**Difficulty:** Easy
**Topic:** `SELF JOIN`, `DATEDIFF()`, Comparison Operators

## Problem

Find the `id` of every day where the temperature was **higher than the previous day (yesterday)**.

---

## Table: `Weather`

```text
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| id            | int     |
| recordDate    | date    |
| temperature   | int     |
+---------------+---------+
```

* `id` is unique.
* There are no duplicate `recordDate` values.
* Each row contains the temperature recorded on a particular day.

---

## Example Input

```text
+----+------------+-------------+
| id | recordDate | temperature |
+----+------------+-------------+
| 1  | 2015-01-01 | 10          |
| 2  | 2015-01-02 | 25          |
| 3  | 2015-01-03 | 20          |
| 4  | 2015-01-04 | 30          |
+----+------------+-------------+
```

## Expected Output

```text
+----+
| id |
+----+
| 2  |
| 4  |
+----+
```

---

## SQL Solution

```sql
SELECT w1.id
FROM Weather w1
JOIN Weather w2
    ON DATEDIFF(w1.recordDate, w2.recordDate) = 1
WHERE w1.temperature > w2.temperature;
```

## Explanation

We need to compare **today's temperature with yesterday's temperature**.

Since both temperatures are stored in the same `Weather` table, we use a **self join**.

We treat the table as two copies:

```text
w1 → today's record
w2 → yesterday's record
```

### Step 1 — Find yesterday

```sql
DATEDIFF(w1.recordDate, w2.recordDate) = 1
```

This means `w1` is exactly **one day after** `w2`.

For example:

```text
w1 = 2015-01-02
w2 = 2015-01-01

DATEDIFF = 1
```

### Step 2 — Compare temperatures

```sql
w1.temperature > w2.temperature
```

For the example:

```text
2015-01-02 → 25 > 10 → ✅
2015-01-03 → 20 > 25 → ❌
2015-01-04 → 30 > 20 → ✅
```

Therefore:

```text
2
4
```

### Key Concepts

**Self Join**

```sql
FROM Weather w1
JOIN Weather w2
```

Used when you need to compare rows within the **same table**.

**`DATEDIFF()`**

```sql
DATEDIFF(date1, date2)
```

Returns the difference between two dates.

**Important pattern:**

```sql
JOIN table t2
    ON DATEDIFF(t1.date, t2.date) = 1
```

This is a common SQL pattern for comparing a row with its **previous day's record**.
