# LiteDB-Perf

A simple INSERT/BULK compare between SQLite and LiteDB v3

First results:

```
Total records: 10000

Journal Enabled
SQLite - Insert: 74253 ms - 135 records/second
LiteDB - Insert: 7960 ms - 1256 records/second
SQLite - Bulk  : 266 ms - 37587 records/second
LiteDB - Bulk  : 455 ms - 21942 records/second

Journal Disabled
SQLite - Insert: 6320 ms - 1582 records/second
LiteDB - Insert: 4769 ms - 2097 records/second
SQLite - Bulk  : 198 ms - 50317 records/second
LiteDB - Bulk  : 415 ms - 24057 records/second
```
