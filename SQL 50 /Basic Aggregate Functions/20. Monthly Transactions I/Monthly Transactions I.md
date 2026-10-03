## 1193. Monthly Transactions I

**Difficulty:** Medium
**Topics:** `GROUP BY`, `DATE_FORMAT()`, `COUNT()`, `SUM()`, `CASE WHEN`

### Problem

For each **month + country**, calculate:

1. Total number of transactions
2. Number of approved transactions
3. Total transaction amount
4. Total amount of approved transactions

### SQL Solution

```sql
SELECT
    DATE_FORMAT(trans_date, '%Y-%m') AS month,
    country,

    COUNT(*) AS trans_count,

    SUM(
        CASE
            WHEN state = 'approved' THEN 1
            ELSE 0
        END
    ) AS approved_count,

    SUM(amount) AS trans_total_amount,

    SUM(
        CASE
            WHEN state = 'approved' THEN amount
            ELSE 0
        END
    ) AS approved_total_amount

FROM Transactions
GROUP BY
    DATE_FORMAT(trans_date, '%Y-%m'),
    country;
```

### Explanation

### 1. Extract the month

```sql
DATE_FORMAT(trans_date, '%Y-%m')
```

For example:

```text
2018-12-18 → 2018-12
2018-12-19 → 2018-12
2019-01-01 → 2019-01
```

We only care about the **year and month**, not the exact day.

---

### 2. Group by month and country

```sql
GROUP BY
    DATE_FORMAT(trans_date, '%Y-%m'),
    country
```

This creates groups such as:

```text
2018-12 + US
2019-01 + US
2019-01 + DE
```

This is important because the requirement is **for each month and country**.

---

### 3. Count all transactions

```sql
COUNT(*) AS trans_count
```

For:

```text
2018-12 + US
```

there are:

```text
121 → approved
122 → declined
```

Therefore:

```text
trans_count = 2
```

---

### 4. Count approved transactions

```sql
SUM(
    CASE
        WHEN state = 'approved' THEN 1
        ELSE 0
    END
) AS approved_count
```

Think of `CASE` as creating a temporary column:

```text
state       CASE
approved    1
declined    0
approved    1
```

Then `SUM()` adds the values.

For `2018-12 + US`:

```text
1 + 0 = 1
```

So:

```text
approved_count = 1
```

---

### 5. Total transaction amount

```sql
SUM(amount) AS trans_total_amount
```

For December US:

```text
1000 + 2000 = 3000
```

Therefore:

```text
trans_total_amount = 3000
```

---

### 6. Approved transaction amount

This is slightly different from `approved_count`.

We need to add the **amount only when approved**:

```sql
SUM(
    CASE
        WHEN state = 'approved' THEN amount
        ELSE 0
    END
) AS approved_total_amount
```

For December US:

```text
approved → 1000 → include
declined → 2000 → 0

1000 + 0 = 1000
```

Therefore:

```text
approved_total_amount = 1000
```

### Final Output

```text
+----------+---------+-------------+----------------+--------------------+-----------------------+
| month    | country | trans_count | approved_count | trans_total_amount | approved_total_amount |
+----------+---------+-------------+----------------+--------------------+-----------------------+
| 2018-12  | US      | 2           | 1              | 3000               | 1000                  |
| 2019-01  | US      | 1           | 1              | 2000               | 2000                  |
| 2019-01  | DE      | 1           | 1              | 2000               | 2000                  |
+----------+---------+-------------+----------------+--------------------+-----------------------+
```

### Key Concept

This problem is mainly testing **conditional aggregation**.

Remember this pattern:

```sql
SUM(CASE WHEN condition THEN 1 ELSE 0 END)
```

→ **conditional count**

And:

```sql
SUM(CASE WHEN condition THEN amount ELSE 0 END)
```

→ **conditional sum**

So the core structure is:

```sql
SELECT
    month,
    country,
    COUNT(*),
    SUM(CASE WHEN condition THEN 1 ELSE 0 END),
    SUM(amount),
    SUM(CASE WHEN condition THEN amount ELSE 0 END)
FROM Transactions
GROUP BY month, country;
```

This `SUM + CASE WHEN` pattern is **very important for SQL interviews**.
