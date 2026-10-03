## 1211. Queries Quality and Percentage

**Difficulty:** Easy
**Topics:** `AVG()`, `SUM()`, `CASE`, `GROUP BY`, `ROUND()`

### Problem

For each `query_name`, calculate:

**Quality**

```text
Average of (rating / position)
```

**Poor Query Percentage**

```text
(Number of queries with rating < 3 / Total queries) × 100
```

### SQL Solution

```sql
SELECT
    query_name,
    ROUND(AVG(rating / position), 2) AS quality,
    ROUND(
        SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) * 100.0
        / COUNT(*),
        2
    ) AS poor_query_percentage
FROM Queries
GROUP BY query_name;
```

### Explanation

#### 1. Group by query

```sql
GROUP BY query_name
```

We need one result for each query:

```text
Dog
Cat
```

---

#### 2. Calculate Quality

```sql
AVG(rating / position)
```

For `Dog`:

```text
5 / 1 = 5
5 / 2 = 2.5
1 / 200 = 0.005

Average = (5 + 2.5 + 0.005) / 3
        = 2.5016...
        = 2.50
```

So:

```sql
ROUND(AVG(rating / position), 2)
```

gives `2.50`.

---

#### 3. Identify poor queries

A poor query has:

```sql
rating < 3
```

We use `CASE`:

```sql
CASE
    WHEN rating < 3 THEN 1
    ELSE 0
END
```

Example for `Dog`:

```text
Rating    CASE
  5         0
  5         0
  1         1
```

Therefore:

```sql
SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END)
```

returns `1`.

---

#### 4. Calculate percentage

```sql
SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END) * 100.0
/ COUNT(*)
```

For `Dog`:

```text
Poor queries = 1
Total queries = 3

1 / 3 × 100 = 33.33
```

---

### Why `100.0`?

```sql
* 100.0
```

instead of:

```sql
* 100
```

Using `100.0` ensures decimal arithmetic rather than integer division in SQL implementations where integer division could truncate the result.

---

### Final Output

```text
+------------+---------+-----------------------+
| query_name | quality | poor_query_percentage |
+------------+---------+-----------------------+
| Dog        | 2.50    | 33.33                 |
| Cat        | 0.66    | 33.33                 |
+------------+---------+-----------------------+
```

### Key Concepts

* `GROUP BY` → calculate results separately for each query
* `AVG()` → calculate quality
* `CASE WHEN` → conditionally count poor queries
* `SUM()` → count the rows satisfying the condition
* `COUNT(*)` → total queries
* `ROUND(..., 2)` → 2 decimal places

### Important Pattern

This is a very useful SQL interview pattern:

```sql
SUM(CASE WHEN condition THEN 1 ELSE 0 END)
```

It means:

> **Count the rows where the condition is true.**

For example:

```sql
SUM(CASE WHEN rating < 3 THEN 1 ELSE 0 END)
```

= number of queries where `rating < 3`.
