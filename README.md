# LiteDB-Perf

A simple INSERT/BULK compare between SQLite and LiteDB v3

First results:

| Action        | LiteDB #1 | LiteDB #2  | LiteDB #3 | SQLite #1  | SQLite #2 |
|---------------|------------|-----------|-----------|------------|-----------|
|Insert         |   4.999 ms |  5.690 ms |  4.839 ms |  46.379 ms | 49.296 ms |
|Bulk           |     236 ms |    280 ms |    219 ms |     122 ms |    122 ms |
|Update         |   3.674 ms |  3.784 ms |  3.242 ms |  47.470 ms | 48.490 ms |
|CreateIndex    |     176 ms |    174 ms |    176 ms |      13 ms |     36 ms |
|Query          |     204 ms |    208 ms |     93 ms |     457 ms |    463 ms |
|Delete         |     157 ms |    207 ms |    140 ms |      11 ms |     13 ms |
|Drop           |      17 ms |     56 ms |     14 ms |      11 ms |     25 ms |
|FileLength     |   7.580 kb |  7.576 kb |  7.572 kb |   3.824 kb |  3.856 kb |
LiteDB
- #1 Default
- #2 Encrypted
- #3 Exclusive mode and no journal

SQLite
- #1 Default
- #2 Encrypted

```

LiteDB: default - 5000 records
==============================
Insert         :  4999 ms -     1000 records/second
Bulk           :   236 ms -    21184 records/second
Update         :  3674 ms -     1361 records/second
CreateIndex    :   176 ms -    28321 records/second
Query          :   204 ms -    24467 records/second
Delete         :   157 ms -    31722 records/second
Drop           :    17 ms -   289513 records/second
FileLength     :  7580 kb

LiteDB: encrypted - 5000 records
================================
Insert         :  5690 ms -      879 records/second
Bulk           :   280 ms -    17820 records/second
Update         :  3784 ms -     1321 records/second
CreateIndex    :   174 ms -    28669 records/second
Query          :   208 ms -    24037 records/second
Delete         :   207 ms -    24078 records/second
Drop           :    56 ms -    87898 records/second
FileLength     :  7576 kb

LiteDB: exclusive no journal - 5000 records
===========================================
Insert         :  4839 ms -     1033 records/second
Bulk           :   219 ms -    22775 records/second
Update         :  3242 ms -     1542 records/second
CreateIndex    :   176 ms -    28379 records/second
Query          :    93 ms -    53243 records/second
Delete         :   140 ms -    35574 records/second
Drop           :    14 ms -   334283 records/second
FileLength     :  7572 kb

SQLite: default - 5000 records
==============================
Insert         : 46379 ms -      108 records/second
Bulk           :   122 ms -    40827 records/second
Update         : 47470 ms -      105 records/second
CreateIndex    :    13 ms -   367266 records/second
Query          :   457 ms -    10933 records/second
Delete         :    11 ms -   441583 records/second
Drop           :    11 ms -   454141 records/second
FileLength     :  3824 kb

SQLite: encrypted - 5000 records
================================
Insert         : 49296 ms -      101 records/second
Bulk           :   122 ms -    40851 records/second
Update         : 48490 ms -      103 records/second
CreateIndex    :    36 ms -   136413 records/second
Query          :   463 ms -    10798 records/second
Delete         :    13 ms -   357189 records/second
Drop           :    25 ms -   199642 records/second
FileLength     :  3856 kb
```
