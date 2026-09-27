# 595. Big Countries

**Difficulty:** Easy
**Topic:** `WHERE`, `OR`, Comparison Operators

## Problem

A country is considered **big** if:

* Its area is at least `3,000,000 km²`, **OR**
* Its population is at least `25,000,000`.

Find the `name`, `population`, and `area` of all big countries.

---

## Table: `World`

```text
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| name        | varchar |
| continent   | varchar |
| area        | int     |
| population  | int     |
| gdp         | bigint  |
+-------------+---------+
```

* `name` is the primary key.
* `area` represents the country's area in km².
* `population` represents the country's population.

---

## Example Input

```text
+-------------+-----------+---------+------------+--------------+
| name        | continent | area    | population | gdp          |
+-------------+-----------+---------+------------+--------------+
| Afghanistan | Asia      | 652230  | 25500100   | 20343000000  |
| Albania     | Europe    | 28748   | 2831741    | 12960000000  |
| Algeria     | Africa    | 2381741 | 37100000   | 188681000000 |
| Andorra     | Europe    | 468     | 78115      | 3712000000   |
| Angola      | Africa    | 1246700 | 20609294   | 100990000000 |
+-------------+-----------+---------+------------+--------------+
```

## Expected Output

```text
+-------------+------------+---------+
| name        | population | area    |
+-------------+------------+---------+
| Afghanistan | 25500100   | 652230  |
| Algeria     | 37100000   | 2381741 |
+-------------+------------+---------+
```

---

## SQL Solution

```sql
SELECT
    name,
    population,
    area
FROM World
WHERE area >= 3000000
   OR population >= 25000000;
```

## Explanation

We need countries satisfying **at least one** of the two conditions.

### Afghanistan

```text
area       = 652,230       ❌
population = 25,500,100    ✅
```

Include because population is greater than `25,000,000`.

### Algeria

```text
area       = 2,381,741     ❌
population = 37,100,000    ✅
```

Include because population is greater than `25,000,000`.

The other countries don't satisfy either condition.

### Key Concept

Use **`OR`** when **any one of multiple conditions** can make a row qualify:

```sql
WHERE condition1
   OR condition2;
```

Also remember:

```text
>=  → greater than or equal to
>   → greater than
<=  → less than or equal to
<   → less than
=   → equal to
```
