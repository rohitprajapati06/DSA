Perfect. I'll keep the **left = question/practice** and **right = answer/solution** format.

# 1378. Replace Employee ID With The Unique Identifier

| 📝 **QUESTION / INPUT**                                                                                                                                                                                                                        | ✅ **ANSWER / OUTPUT**                                                                                                                                                                                                                                                                                               |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Problem:** Show the `unique_id` of each employee. If an employee does not have a `unique_id`, show `NULL`.                                                                                                                                   | **Approach:** We need **all employees**, even those without a matching record in `EmployeeUNI`. Therefore, use `LEFT JOIN`.                                                                                                                                                                                         |
| **Employees**<br><br>`text<br>+----+----------+<br>\| id \| name     \|<br>+----+----------+<br>\| 1  \| Alice    \|<br>\| 7  \| Bob      \|<br>\| 11 \| Meir     \|<br>\| 90 \| Winston  \|<br>\| 3  \| Jonathan \|<br>+----+----------+<br>` | **SQL Solution**<br><br>`sql<br>SELECT<br>    eu.unique_id,<br>    e.name<br>FROM Employees e<br>LEFT JOIN EmployeeUNI eu<br>    ON e.id = eu.id;<br>`                                                                                                                                                              |
| **EmployeeUNI**<br><br>`text<br>+----+-----------+<br>\| id \| unique_id \|<br>+----+-----------+<br>\| 3  \| 1         \|<br>\| 11 \| 2         \|<br>\| 90 \| 3         \|<br>+----+-----------+<br>`                                        | **Expected Output**<br><br>`text<br>+-----------+----------+<br>\| unique_id \| name     \|<br>+-----------+----------+<br>\| NULL      \| Alice    \|<br>\| NULL      \| Bob      \|<br>\| 2         \| Meir     \|<br>\| 3         \| Winston  \|<br>\| 1         \| Jonathan \|<br>+-----------+----------+<br>` |
| **Your Task:**<br><br>Try to solve it before looking at the right side.<br><br>**Think:** Which JOIN keeps employees who don't have a matching `EmployeeUNI` record?                                                                           | **Answer:** `LEFT JOIN`<br><br>Because `Employees` is the main table, every employee must appear in the result. If no matching `id` exists in `EmployeeUNI`, SQL automatically returns `NULL` for `unique_id`.                                                                                                      |

### 🔑 Key Concept

```text
Employees
   |
   | LEFT JOIN
   ↓
EmployeeUNI
   |
   ├── Match found    → unique_id
   |
   └── No match       → NULL
```

### Interview takeaway

Whenever the requirement says:

> **"Show all records from Table A, even if there is no matching record in Table B."**

Think:

```sql
A
LEFT JOIN
B
```

This question is primarily testing your understanding of **`LEFT JOIN`**.
