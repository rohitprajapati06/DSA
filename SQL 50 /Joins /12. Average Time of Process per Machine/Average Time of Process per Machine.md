# 1661. Average Time of Process per Machine

**Difficulty:** Easy
**Topic:** `SELF JOIN`, `AVG()`, `GROUP BY`, `ROUND()`

## Problem

Each machine runs multiple processes.

For every process:

* `start` → when the process begins
* `end` → when the process finishes

The **processing time** is:

```text
end timestamp - start timestamp
```

Find the **average processing time for each machine** and round the result to **3 decimal places**.

---

## Table: `Activity`

```text
+----------------+---------+
| Column Name    | Type    |
+----------------+---------+
| machine_id     | int     |
| process_id     | int     |
| activity_type  | enum    |
| timestamp      | float   |
+----------------+---------+
```

* `(machine_id, process_id, activity_type)` is the primary key.
* `machine_id` identifies the machine.
* `process_id` identifies the process.
* `activity_type` is either `'start'` or `'end'`.
* `timestamp` represents the time in seconds.
* Every process has exactly one `start` and one `end` record.

---

## Example Input

```text
+------------+------------+---------------+-----------+
| machine_id | process_id | activity_type | timestamp |
+------------+------------+---------------+-----------+
| 0          | 0          | start         | 0.712     |
| 0          | 0          | end           | 1.520     |
| 0          | 1          | start         | 3.140     |
| 0          | 1          | end           | 4.120     |
| 1          | 0          | start         | 0.550     |
| 1          | 0          | end           | 1.550     |
| 1          | 1          | start         | 0.430     |
| 1          | 1          | end           | 1.420     |
| 2          | 0          | start         | 4.100     |
| 2          | 0          | end           | 4.512     |
| 2          | 1          | start         | 2.500     |
| 2          | 1          | end           | 5.000     |
+------------+------------+---------------+-----------+
```

## Expected Output

```text
+------------+-----------------+
| machine_id | processing_time |
+------------+-----------------+
| 0          | 0.894           |
| 1          | 0.995           |
| 2          | 1.456           |
+------------+-----------------+
```

---

## SQL Solution

```sql
SELECT
    s.machine_id,
    ROUND(AVG(e.timestamp - s.timestamp), 3) AS processing_time
FROM Activity s
JOIN Activity e
    ON s.machine_id = e.machine_id
   AND s.process_id = e.process_id
WHERE s.activity_type = 'start'
  AND e.activity_type = 'end'
GROUP BY s.machine_id;
```

## Explanation

Since the `start` and `end` timestamps are stored as **separate rows in the same table**, we use a **self join**.

### Step 1: Create two references to the table

```sql
Activity s
Activity e
```

Here:

```text
s = start record
e = end record
```

### Step 2: Match the same machine and process

```sql
ON s.machine_id = e.machine_id
AND s.process_id = e.process_id
```

This pairs:

```text
machine 0, process 0 → start + end
machine 0, process 1 → start + end
machine 1, process 0 → start + end
...
```

### Step 3: Make sure we're comparing start and end

```sql
WHERE s.activity_type = 'start'
  AND e.activity_type = 'end'
```

### Step 4: Calculate processing time

```sql
e.timestamp - s.timestamp
```

For Machine `0`:

```text
Process 0:
1.520 - 0.712 = 0.808

Process 1:
4.120 - 3.140 = 0.980
```

Average:

```text
(0.808 + 0.980) / 2
= 0.894
```

### Step 5: Calculate the average for each machine

```sql
AVG(e.timestamp - s.timestamp)
```

We use:

```sql
GROUP BY s.machine_id
```

because we need one result per machine.

### Step 6: Round to 3 decimal places

```sql
ROUND(..., 3)
```

---

## Key Concepts

### 1. Self Join

```sql
FROM Activity s
JOIN Activity e
```

Used when related information is stored in different rows of the **same table**.

### 2. `AVG()`

```sql
AVG(e.timestamp - s.timestamp)
```

Calculates the average processing time.

### 3. `GROUP BY`

```sql
GROUP BY s.machine_id
```

Produces one average for each machine.

### 4. `ROUND()`

```sql
ROUND(value, 3)
```

Rounds the result to **3 decimal places**.

### Important Pattern to Remember

```sql
SELECT
    group_column,
    ROUND(AVG(end_value - start_value), 3)
FROM Table start
JOIN Table end
    ON matching_conditions
WHERE start_condition
  AND end_condition
GROUP BY group_column;
```

This pattern is very useful for **start/end event processing problems** in SQL interviews.
