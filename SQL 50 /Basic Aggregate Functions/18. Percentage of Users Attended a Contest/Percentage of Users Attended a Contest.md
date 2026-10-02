## 1633. Percentage of Users Attended a Contest

**Difficulty:** Easy
**Topics:** `JOIN`, `COUNT`, `GROUP BY`, `ROUND`, `ORDER BY`

### Problem

For each contest, calculate:

```text
Percentage = (Number of registered users / Total number of users) × 100
```

Then:

* Round to **2 decimal places**
* Sort by `percentage DESC`
* If percentages are equal, sort by `contest_id ASC`

### SQL Solution

```sql
SELECT
    r.contest_id,
    ROUND(
        COUNT(r.user_id) * 100.0 / COUNT(u.user_id),
        2
    ) AS percentage
FROM Register r
CROSS JOIN Users u
GROUP BY r.contest_id
ORDER BY
    percentage DESC,
    r.contest_id ASC;
```

### Explanation

#### 1. `CROSS JOIN`

```sql
FROM Register r
CROSS JOIN Users u
```

We need the **total number of users**.

There are 3 users:

```text
Alice
Bob
Alex
```

`CROSS JOIN` creates combinations between `Register` and `Users`, which allows us to count all users for each contest.

However, there is a simpler and cleaner approach using a subquery.

### Recommended Solution

```sql
SELECT
    contest_id,
    ROUND(
        COUNT(user_id) * 100.0 / (SELECT COUNT(*) FROM Users),
        2
    ) AS percentage
FROM Register
GROUP BY contest_id
ORDER BY
    percentage DESC,
    contest_id ASC;
```

### Why this solution is better

The subquery:

```sql
(SELECT COUNT(*) FROM Users)
```

returns:

```text
3
```

This is the **total number of users**.

Then:

```sql
COUNT(user_id)
```

counts how many users registered for each contest.

For contest `215`:

```text
2 registered users
------------------ × 100
3 total users

= 66.67%
```

### Step-by-Step

For contest `208`:

```text
Registered users = 3
Total users      = 3

3 / 3 × 100 = 100%
```

For contest `215`:

```text
Registered users = 2
Total users      = 3

2 / 3 × 100 = 66.67%
```

For contest `207`:

```text
Registered users = 1
Total users      = 3

1 / 3 × 100 = 33.33%
```

### Why `100.0` instead of `100`?

```sql
COUNT(user_id) * 100.0
```

Using `100.0` ensures **decimal division** rather than integer division in SQL implementations where integer arithmetic could truncate the result.

### `ORDER BY`

```sql
ORDER BY
    percentage DESC,
    contest_id ASC;
```

First:

```text
Highest percentage → lowest percentage
```

If two contests have the same percentage, then:

```text
Smaller contest_id → larger contest_id
```

### Final Output

```text
+------------+------------+
| contest_id | percentage |
+------------+------------+
| 208        | 100.00     |
| 209        | 100.00     |
| 210        | 100.00     |
| 215        | 66.67      |
| 207        | 33.33      |
+------------+------------+
```

### Key Concepts

* `COUNT(user_id)` → registered users per contest
* `COUNT(*) FROM Users` → total users
* `GROUP BY contest_id` → calculate separately for each contest
* `ROUND(..., 2)` → two decimal places
* `ORDER BY ... DESC` → highest percentage first
* `ORDER BY ... ASC` → tie-breaker by contest ID

**Important pattern to remember:**

```sql
SELECT
    group_column,
    ROUND(
        COUNT(*) * 100.0 / (SELECT COUNT(*) FROM total_table),
        2
    )
FROM table
GROUP BY group_column;
```

This **"group count / total count × 100"** pattern appears frequently in SQL interview questions.
