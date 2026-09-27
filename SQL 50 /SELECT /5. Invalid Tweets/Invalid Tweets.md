# 1683. Invalid Tweets

**Difficulty:** Easy
**Topic:** `WHERE`, `LENGTH()`

## Problem

Find the IDs of all tweets that are **invalid**.

A tweet is invalid if the number of characters in its `content` is **strictly greater than 15**.

---

## Table: `Tweets`

```text
+----------------+---------+
| Column Name    | Type    |
+----------------+---------+
| tweet_id       | int     |
| content        | varchar |
+----------------+---------+
```

* `tweet_id` is the primary key.
* `content` contains the tweet text.
* A tweet is invalid when its content length is **greater than 15**.

---

## Example Input

```text
+----------+-----------------------------------+
| tweet_id | content                           |
+----------+-----------------------------------+
| 1        | Let us Code                       |
| 2        | More than fifteen chars are here! |
+----------+-----------------------------------+
```

## Expected Output

```text
+----------+
| tweet_id |
+----------+
| 2        |
+----------+
```

---

## SQL Solution

```sql
SELECT tweet_id
FROM Tweets
WHERE LENGTH(content) > 15;
```

## Explanation

We use the `LENGTH()` function to calculate the number of characters in `content`.

For example:

```text
Tweet 1
"Let us Code"
Length = 11
11 > 15 → FALSE ❌
```

```text
Tweet 2
"More than fifteen chars are here!"
Length = 33
33 > 15 → TRUE ✅
```

Therefore, only tweet `2` is invalid.

### Key Concept

**`LENGTH()`**

Used to find the length of a string:

```sql
LENGTH(column_name)
```

And because the condition says **strictly greater than 15**:

```sql
WHERE LENGTH(content) > 15;
```

**Remember:**

```text
>  → strictly greater than
>= → greater than or equal to
<  → strictly less than
<= → less than or equal to
```
