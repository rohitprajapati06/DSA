# 1280. Students and Examinations

**Difficulty:** Easy
**Topic:** `CROSS JOIN`, `LEFT JOIN`, `COUNT()`, `GROUP BY`, `ORDER BY`

## Problem

Find the number of times **each student attended each subject's exam**.

The result must contain **every combination of student and subject**, even if the student attended the exam **0 times**.

---

## Table: `Students`

```text
+---------------+---------+
| Column Name   | Type    |
+---------------+---------+
| student_id    | int     |
| student_name  | varchar |
+---------------+---------+
```

* `student_id` is the primary key.
* Each row represents a student.

## Table: `Subjects`

```text
+--------------+
| subject_name |
+--------------+
```

* `subject_name` is the primary key.
* Each row represents a subject.

## Table: `Examinations`

```text
+--------------+---------+
| Column Name  | Type    |
+--------------+---------+
| student_id   | int     |
| subject_name | varchar |
+--------------+---------+
```

* This table can contain duplicate rows.
* Each row represents one exam attendance.

---

## Example Input

### Students

```text
+------------+--------------+
| student_id | student_name |
+------------+--------------+
| 1          | Alice        |
| 2          | Bob          |
| 13         | John         |
| 6          | Alex         |
+------------+--------------+
```

### Subjects

```text
+--------------+
| subject_name |
+--------------+
| Math         |
| Physics      |
| Programming  |
+--------------+
```

### Examinations

```text
+------------+--------------+
| student_id | subject_name |
+------------+--------------+
| 1          | Math         |
| 1          | Physics      |
| 1          | Programming  |
| 2          | Programming  |
| 1          | Physics      |
| 1          | Math         |
| 13         | Math         |
| 13         | Programming  |
| 13         | Physics      |
| 2          | Math         |
| 1          | Math         |
+------------+--------------+
```

## Expected Output

```text
+------------+--------------+--------------+----------------+
| student_id | student_name | subject_name | attended_exams |
+------------+--------------+--------------+----------------+
| 1          | Alice        | Math         | 3              |
| 1          | Alice        | Physics      | 2              |
| 1          | Alice        | Programming  | 1              |
| 2          | Bob          | Math         | 1              |
| 2          | Bob          | Physics      | 0              |
| 2          | Bob          | Programming  | 1              |
| 6          | Alex         | Math         | 0              |
| 6          | Alex         | Physics      | 0              |
| 6          | Alex         | Programming  | 0              |
| 13         | John         | Math         | 1              |
| 13         | John         | Physics      | 1              |
| 13         | John         | Programming  | 1              |
+------------+--------------+--------------+----------------+
```

---

## SQL Solution

```sql
SELECT
    s.student_id,
    s.student_name,
    sub.subject_name,
    COUNT(e.student_id) AS attended_exams
FROM Students s
CROSS JOIN Subjects sub
LEFT JOIN Examinations e
    ON s.student_id = e.student_id
   AND sub.subject_name = e.subject_name
GROUP BY
    s.student_id,
    s.student_name,
    sub.subject_name
ORDER BY
    s.student_id,
    sub.subject_name;
```

## Explanation

This question has **two important steps**.

### Step 1: Create every student-subject combination

We use:

```sql
CROSS JOIN Subjects sub
```

Suppose we have:

```text
4 students × 3 subjects = 12 combinations
```

So we initially create:

```text
Alice → Math
Alice → Physics
Alice → Programming

Bob → Math
Bob → Physics
Bob → Programming

Alex → Math
Alex → Physics
Alex → Programming

John → Math
John → Physics
John → Programming
```

This is important because the output must contain students even when they attended **zero exams**.

---

### Step 2: Match the examination records

We use:

```sql
LEFT JOIN Examinations e
    ON s.student_id = e.student_id
   AND sub.subject_name = e.subject_name
```

This matches both:

```text
student
+
subject
```

For example, Alice's Math records are:

```text
Alice + Math
Alice + Math
Alice + Math
```

So:

```text
COUNT = 3
```

Bob's Physics has no matching record:

```text
Bob + Physics → NULL
```

Because we use `LEFT JOIN`, the combination is still present.

---

### Why `COUNT(e.student_id)` instead of `COUNT(*)`?

This is **very important**.

For Bob + Physics, the `LEFT JOIN` produces:

```text
Bob | Physics | NULL
```

If we use:

```sql
COUNT(*)
```

SQL counts that row and gives:

```text
1 ❌
```

But:

```sql
COUNT(e.student_id)
```

doesn't count `NULL`, so:

```text
0 ✅
```

Therefore:

```sql
COUNT(e.student_id)
```

is the correct choice.

---

### Step 3: Group the records

```sql
GROUP BY
    s.student_id,
    s.student_name,
    sub.subject_name
```

We need one result for each:

```text
student + subject
```

For example:

```text
Alice + Math        → 3
Alice + Physics     → 2
Alice + Programming → 1
```

---

### Step 4: Sort the result

```sql
ORDER BY
    s.student_id,
    sub.subject_name;
```

This sorts first by `student_id` and then by `subject_name`.

---

## Key Concepts

### 1. `CROSS JOIN`

```sql
Students
CROSS JOIN Subjects
```

Creates **every possible combination**.

```text
Students × Subjects
```

This is the key idea for this problem.

### 2. `LEFT JOIN`

Keeps all student-subject combinations even when there is **no examination record**.

### 3. `COUNT(column)`

```sql
COUNT(e.student_id)
```

Counts only non-`NULL` values, allowing us to correctly return `0` for students who didn't attend.

### 4. The Important Pattern

Remember this pattern:

```sql
SELECT
    ...
    COUNT(e.id)
FROM A
CROSS JOIN B
LEFT JOIN C
    ON ...
GROUP BY ...
```

This is commonly used when a question asks:

> **"Show every combination and count how many records exist for each combination."**
