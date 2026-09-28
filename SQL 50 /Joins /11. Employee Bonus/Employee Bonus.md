# Employee Bonus

**Difficulty:** Easy
**Topic:** `LEFT JOIN`, `IS NULL`, `WHERE`

## Problem

Write a SQL query to find the **name and bonus** of every employee who satisfies either condition:

* Their bonus is **less than 1000**
* They **did not receive a bonus**

---

## Table: `Employee`

```text
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| empId       | int     |
| name        | varchar |
| supervisor  | int     |
| salary      | int     |
+-------------+---------+
```

* `empId` uniquely identifies each employee.
* `supervisor` contains the employee's manager ID.
* `salary` contains the employee's salary.

## Table: `Bonus`

```text
+-------------+------+
| Column Name | Type |
+-------------+------+
| empId       | int  |
| bonus       | int  |
+-------------+------+
```

* `empId` uniquely identifies an employee in the `Bonus` table.
* `bonus` contains the employee's bonus amount.

---

## Example Input

### Employee

```text
+-------+--------+------------+--------+
| empId | name   | supervisor | salary |
+-------+--------+------------+--------+
| 3     | Brad   | null       | 4000   |
| 1     | John   | 3          | 1000   |
| 2     | Dan    | 3          | 2000   |
| 4     | Thomas | 3          | 4000   |
+-------+--------+------------+--------+
```

### Bonus

```text
+-------+-------+
| empId | bonus |
+-------+-------+
| 2     | 500   |
| 4     | 2000  |
+-------+-------+
```

---

## Expected Output

```text
+------+-------+
| name | bonus |
+------+-------+
| Brad | null  |
| John | null  |
| Dan  | 500   |
+------+-------+
```

---

## SQL Solution

```sql
SELECT
    e.name,
    b.bonus
FROM Employee e
LEFT JOIN Bonus b
    ON e.empId = b.empId
WHERE b.bonus < 1000
   OR b.bonus IS NULL;
```

## Explanation

We use `LEFT JOIN` because we need **all employees**, including employees who don't have a record in the `Bonus` table.

After the join:

| Employee |  Bonus |
| -------- | -----: |
| Brad     | `NULL` |
| John     | `NULL` |
| Dan      |    500 |
| Thomas   |   2000 |

Then this condition:

```sql
WHERE b.bonus < 1000
   OR b.bonus IS NULL
```

keeps:

* **Brad** → no bonus → `NULL` ✅
* **John** → no bonus → `NULL` ✅
* **Dan** → bonus = 500 → less than 1000 ✅
* **Thomas** → bonus = 2000 → not less than 1000 ❌

### Key Concept

The important pattern here is:

```sql
LEFT JOIN
WHERE column < value
   OR column IS NULL
```

This is useful when you need records that **either satisfy a condition or have no matching record at all**.
