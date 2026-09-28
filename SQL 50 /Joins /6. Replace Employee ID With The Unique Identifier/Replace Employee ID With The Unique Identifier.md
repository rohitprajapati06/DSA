# 1378. Replace Employee ID With The Unique Identifier

**Difficulty:** Easy
**Topic:** `LEFT JOIN`

## Problem

Write a SQL query to display the `unique_id` of each employee along with their name.

If an employee does not have a corresponding `unique_id`, display `NULL`.

---

## Table: `Employees`

```text
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| id            | int     |
| name          | varchar |
+---------------+---------+
```

* `id` is the primary key.
* Each row contains an employee's ID and name.

## Table: `EmployeeUNI`

```text
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| id            | int     |
| unique_id     | int     |
+---------------+---------+
```

* `(id, unique_id)` is the primary key.
* This table contains the unique ID corresponding to an employee.

---

## Example Input

### Employees

```text
+----+----------+
| id | name     |
+----+----------+
| 1  | Alice    |
| 7  | Bob      |
| 11 | Meir     |
| 90 | Winston  |
| 3  | Jonathan |
+----+----------+
```

### EmployeeUNI

```text
+----+-----------+
| id | unique_id |
+----+-----------+
| 3  | 1         |
| 11 | 2         |
| 90 | 3         |
+----+-----------+
```

---

## Expected Output

```text
+-----------+----------+
| unique_id | name     |
+-----------+----------+
| null      | Alice    |
| null      | Bob      |
| 2         | Meir     |
| 3         | Winston  |
| 1         | Jonathan |
+-----------+----------+
```

---

## SQL Solution

```sql
SELECT
    eu.unique_id,
    e.name
FROM Employees e
LEFT JOIN EmployeeUNI eu
    ON e.id = eu.id;
```

## Explanation

We use a **`LEFT JOIN`** because we want to display **every employee**, even if they don't have a matching record in `EmployeeUNI`.

For example:

* Alice (`id = 1`) → no matching record → `NULL`
* Bob (`id = 7`) → no matching record → `NULL`
* Meir (`id = 11`) → `unique_id = 2`
* Winston (`id = 90`) → `unique_id = 3`
* Jonathan (`id = 3`) → `unique_id = 1`

### Key Concept

```text
LEFT JOIN
```

Use `LEFT JOIN` when you want **all records from the left table**, regardless of whether a matching record exists in the right table.
