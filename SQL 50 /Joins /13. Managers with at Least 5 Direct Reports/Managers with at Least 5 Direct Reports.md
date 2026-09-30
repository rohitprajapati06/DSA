# 570. Managers with at Least 5 Direct Reports

**Difficulty:** Medium
**Topic:** `GROUP BY`, `HAVING`, `COUNT()`

## Problem

Find the names of employees who are managers of **at least 5 direct reports**.

A direct report is an employee whose `managerId` is equal to the manager's `id`.

---

## Table: `Employee`

```text
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| id          | int     |
| name        | varchar |
| department  | varchar |
| managerId   | int     |
+-------------+---------+
```

* `id` is the primary key.
* `managerId` contains the ID of the employee's manager.
* `managerId = NULL` means the employee has no manager.
* An employee cannot be their own manager.

---

## Example Input

```text
+-----+-------+------------+-----------+
| id  | name  | department | managerId |
+-----+-------+------------+-----------+
| 101 | John  | A          | NULL      |
| 102 | Dan   | A          | 101       |
| 103 | James | A          | 101       |
| 104 | Amy   | A          | 101       |
| 105 | Anne  | A          | 101       |
| 106 | Ron   | B          | 101       |
+-----+-------+------------+-----------+
```

## Expected Output

```text
+------+
| name |
+------+
| John |
+------+
```

---

## SQL Solution

```sql
SELECT name
FROM Employee
WHERE id IN (
    SELECT managerId
    FROM Employee
    WHERE managerId IS NOT NULL
    GROUP BY managerId
    HAVING COUNT(*) >= 5
);
```

## Explanation

The important thing is to understand what `managerId` represents.

For the example:

```text
Dan   → managerId = 101
James → managerId = 101
Amy   → managerId = 101
Anne  → managerId = 101
Ron   → managerId = 101
```

So manager `101` has **5 direct reports**.

### Step 1: Group employees by manager

```sql
SELECT managerId
FROM Employee
WHERE managerId IS NOT NULL
GROUP BY managerId;
```

This gives:

```text
managerId
---------
101
```

### Step 2: Count direct reports

```sql
HAVING COUNT(*) >= 5
```

So we get managers who have at least 5 employees reporting directly to them.

```text
managerId | count
----------+------
101       | 5
```

### Step 3: Find the manager's name

We then use:

```sql
WHERE id IN (...)
```

The manager's `id` is `101`, so:

```text
Employee with id = 101 → John
```

Therefore the result is:

```text
John
```

---

## Alternative Solution — Self Join

You can also solve it using a `SELF JOIN`:

```sql
SELECT m.name
FROM Employee m
JOIN Employee e
    ON m.id = e.managerId
GROUP BY m.id, m.name
HAVING COUNT(e.id) >= 5;
```

Here:

```text
m → manager
e → employee/direct report
```

The join:

```sql
ON m.id = e.managerId
```

means:

> Match each manager with the employees who directly report to them.

Then:

```sql
HAVING COUNT(e.id) >= 5
```

keeps only managers with at least 5 direct reports.

### Key Concept

`WHERE` filters **rows before grouping**:

```sql
WHERE condition
```

`HAVING` filters **groups after `GROUP BY`**:

```sql
GROUP BY managerId
HAVING COUNT(*) >= 5
```

For this problem, the most important pattern is:

```sql
GROUP BY managerId
HAVING COUNT(*) >= 5
```

This pattern is commonly used for questions such as:

> "Find customers with at least 3 orders."

> "Find departments with more than 10 employees."

> "Find managers with at least 5 employees."
