# 1934. Confirmation Rate

**Difficulty:** Medium
**Topic:** `LEFT JOIN`, `COUNT()`, `CASE`, `ROUND()`, `GROUP BY`

## Problem

Find the **confirmation rate** for every user.

The confirmation rate is:

```text
Number of confirmed messages
--------------------------------
Total confirmation requests
```

If a user has **not requested any confirmation messages**, their confirmation rate should be `0`.

The result should be rounded to **2 decimal places**.

---

## Table: `Signups`

```text
+----------------+----------+
| Column Name    | Type     |
+----------------+----------+
| user_id        | int      |
| time_stamp     | datetime |
+----------------+----------+
```

* `user_id` uniquely identifies each user.
* Each row represents a user's signup.

## Table: `Confirmations`

```text
+----------------+----------+
| Column Name    | Type     |
+----------------+----------+
| user_id        | int      |
| time_stamp     | datetime |
| action         | ENUM     |
+----------------+----------+
```

* `(user_id, time_stamp)` is the primary key.
* `action` can be `'confirmed'` or `'timeout'`.
* Each row represents a confirmation request.

---

## Example Input

### Signups

```text
+---------+---------------------+
| user_id | time_stamp          |
+---------+---------------------+
| 3       | 2020-03-21 10:16:13 |
| 7       | 2020-01-04 13:57:59 |
| 2       | 2020-07-29 23:09:44 |
| 6       | 2020-12-09 10:39:37 |
+---------+---------------------+
```

### Confirmations

```text
+---------+---------------------+-----------+
| user_id | time_stamp          | action    |
+---------+---------------------+-----------+
| 3       | 2021-01-06 03:30:46 | timeout   |
| 3       | 2021-07-14 14:00:00 | timeout   |
| 7       | 2021-06-12 11:57:29 | confirmed |
| 7       | 2021-06-13 12:58:28 | confirmed |
| 7       | 2021-06-14 13:59:27 | confirmed |
| 2       | 2021-01-22 00:00:00 | confirmed |
| 2       | 2021-02-28 23:59:59 | timeout   |
+---------+---------------------+-----------+
```

## Expected Output

```text
+---------+-------------------+
| user_id | confirmation_rate |
+---------+-------------------+
| 6       | 0.00              |
| 3       | 0.00              |
| 7       | 1.00              |
| 2       | 0.50              |
+---------+-------------------+
```

---

## SQL Solution

```sql
SELECT
    s.user_id,
    ROUND(
        COALESCE(
            SUM(c.action = 'confirmed') / COUNT(c.user_id),
            0
        ),
        2
    ) AS confirmation_rate
FROM Signups s
LEFT JOIN Confirmations c
    ON s.user_id = c.user_id
GROUP BY s.user_id;
```

## Explanation

### Step 1: Start with `Signups`

We need the confirmation rate for **every user**.

Therefore, `Signups` must be our main table:

```sql
FROM Signups s
```

---

### Step 2: Use `LEFT JOIN`

```sql
LEFT JOIN Confirmations c
    ON s.user_id = c.user_id
```

Why `LEFT JOIN`?

Because users who have **no confirmation requests** must still appear.

For example, user `6` doesn't exist in `Confirmations`.

With `LEFT JOIN`:

```text
6 | NULL
```

So we can later return:

```text
0.00
```

If we used `INNER JOIN`, user `6` would disappear completely.

---

### Step 3: Count confirmed messages

```sql
SUM(c.action = 'confirmed')
```

In MySQL, the condition:

```sql
c.action = 'confirmed'
```

evaluates to:

```text
1 → true
0 → false
```

For user `7`:

```text
confirmed
confirmed
confirmed
```

So:

```text
1 + 1 + 1 = 3
```

---

### Step 4: Count total requests

```sql
COUNT(c.user_id)
```

For user `2`:

```text
confirmed
timeout
```

Total requests:

```text
2
```

Therefore:

```text
3 confirmed / 3 requests = 1.00
```

For user `2`:

```text
1 confirmed / 2 requests = 0.50
```

---

### Step 5: Handle users with no requests

For user `6`:

```text
confirmed = 0
total requests = 0
```

We don't want to perform:

```text
0 / 0
```

So we use:

```sql
COALESCE(..., 0)
```

This converts `NULL` to `0`.

---

### Step 6: Round to 2 decimal places

```sql
ROUND(..., 2)
```

For example:

```text
0.5 → 0.50
```

---

## Another Common Solution

You can also write it using `CASE`:

```sql
SELECT
    s.user_id,
    ROUND(
        COALESCE(
            SUM(CASE
                WHEN c.action = 'confirmed' THEN 1
                ELSE 0
            END) / COUNT(c.user_id),
            0
        ),
        2
    ) AS confirmation_rate
FROM Signups s
LEFT JOIN Confirmations c
    ON s.user_id = c.user_id
GROUP BY s.user_id;
```

This version is slightly more explicit and is useful to understand because `CASE` is commonly used for **conditional counting**.

### Key Concepts

**`LEFT JOIN`**

Keeps users who have no confirmation records.

**`COUNT()`**

Counts total confirmation requests.

**`SUM(condition)` / `CASE`**

Counts only the confirmed requests.

**`COALESCE()`**

Converts `NULL` to `0`.

**`ROUND(value, 2)`**

Rounds the result to two decimal places.

### Important Pattern

```sql
LEFT JOIN
GROUP BY
COUNT(...)
SUM(CASE WHEN condition THEN 1 ELSE 0 END)
```

This is a very common SQL pattern for calculating **ratios, percentages, success rates, and conversion rates**.
