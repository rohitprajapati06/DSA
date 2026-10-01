# 620. Not Boring Movies

**Difficulty:** Easy
**Topic:** `WHERE`, `MOD()`, `ORDER BY`

## Problem

Find all movies that satisfy **both** conditions:

1. The movie has an **odd-numbered `id`**.
2. The `description` is **not equal to `'boring'`**.

Return the results ordered by `rating` in **descending order**.

---

## Table: `Cinema`

```text
+----------------+----------+
| Column Name    | Type     |
+----------------+----------+
| id             | int      |
| movie          | varchar  |
| description    | varchar  |
| rating         | float    |
+----------------+----------+
```

* `id` is the primary key.
* `movie` contains the movie name.
* `description` contains the movie description.
* `rating` contains the movie rating.

---

## Example Input

```text
+----+------------+-------------+--------+
| id | movie      | description | rating |
+----+------------+-------------+--------+
| 1  | War        | great 3D    | 8.9    |
| 2  | Science    | fiction     | 8.5    |
| 3  | irish      | boring      | 6.2    |
| 4  | Ice song   | Fantacy     | 8.6    |
| 5  | House card | Interesting | 9.1    |
+----+------------+-------------+--------+
```

## Expected Output

```text
+----+------------+-------------+--------+
| id | movie      | description | rating |
+----+------------+-------------+--------+
| 5  | House card | Interesting | 9.1    |
| 1  | War        | great 3D    | 8.9    |
+----+------------+-------------+--------+
```

---

## SQL Solution

```sql
SELECT
    id,
    movie,
    description,
    rating
FROM Cinema
WHERE id % 2 = 1
  AND description <> 'boring'
ORDER BY rating DESC;
```

## Explanation

### 1. Find odd IDs

We use the modulo operator `%`:

```sql
id % 2 = 1
```

Examples:

```text
1 % 2 = 1 → Odd ✅
2 % 2 = 0 → Even ❌
3 % 2 = 1 → Odd ✅
4 % 2 = 0 → Even ❌
5 % 2 = 1 → Odd ✅
```

So the odd IDs are:

```text
1, 3, 5
```

### 2. Remove boring movies

```sql
description <> 'boring'
```

Movie with ID `3` has:

```text
description = 'boring'
```

So it is excluded.

Remaining:

```text
ID 1 → War
ID 5 → House card
```

### 3. Sort by rating

```sql
ORDER BY rating DESC
```

`DESC` means **highest to lowest**:

```text
9.1
8.9
```

---

## Key Concepts

### Modulo `%`

Used to determine whether a number is odd or even:

```sql
id % 2 = 1   -- Odd
id % 2 = 0   -- Even
```

### Not Equal

You can use:

```sql
description <> 'boring'
```

or:

```sql
description != 'boring'
```

Both mean **not equal to** in MySQL.

### Descending Order

```sql
ORDER BY rating DESC
```

Highest values appear first.

### Final Pattern

```sql
SELECT columns
FROM table
WHERE condition1
  AND condition2
ORDER BY column DESC;
```

This is a basic but very common SQL interview pattern combining **filtering + sorting**.
