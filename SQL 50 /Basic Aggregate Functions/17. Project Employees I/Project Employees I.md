## 1075. Project Employees I

**Difficulty:** Easy
**Topics:** `JOIN`, `AVG()`, `GROUP BY`, `ROUND()`

### Problem

Find the **average experience years** of employees working on each project.

### SQL Solution

```sql
SELECT
    p.project_id,
    ROUND(AVG(e.experience_years), 2) AS average_years
FROM Project p
JOIN Employee e
    ON p.employee_id = e.employee_id
GROUP BY p.project_id;
```

### Explanation

#### 1. Join the tables

```sql
JOIN Employee e
    ON p.employee_id = e.employee_id
```

`Project` tells us **which employee works on which project**.

`Employee` contains the employee's `experience_years`.

For example:

```text
Project 1 → Employee 1 → 3 years
Project 1 → Employee 2 → 2 years
Project 1 → Employee 3 → 1 year
```

#### 2. Group by project

```sql
GROUP BY p.project_id
```

We need one result for **each project**.

So:

```text
Project 1 → employees 1, 2, 3
Project 2 → employees 1, 4
```

#### 3. Calculate average

```sql
AVG(e.experience_years)
```

For Project 1:

```text
(3 + 2 + 1) / 3 = 2
```

For Project 2:

```text
(3 + 2) / 2 = 2.5
```

#### 4. Round to 2 decimal places

```sql
ROUND(AVG(e.experience_years), 2)
```

Result:

```text
2.00
2.50
```

### Final Output

```text
+------------+---------------+
| project_id | average_years |
+------------+---------------+
| 1          | 2.00          |
| 2          | 2.50          |
+------------+---------------+
```

### Key Concepts

* `JOIN` → connect project assignments with employee details
* `GROUP BY project_id` → calculate separately for each project
* `AVG()` → calculate average experience
* `ROUND(..., 2)` → keep 2 decimal places

**Pattern to remember:**

```sql
SELECT group_column, ROUND(AVG(value_column), 2)
FROM table1
JOIN table2 ON matching_condition
GROUP BY group_column;
```

This is a very common **JOIN + GROUP BY + aggregate** interview pattern.
