# LiteDB-Perf

A simple INSERT/BULK compare between SQLite and LiteDB v3

First results:

```
LiteDB: default - 5000 records
==============================
Insert         :  5008 ms -      998 records/second
Bulk           :     1 ms -  2700951 records/second
Update         :  3457 ms -     1446 records/second
CreateIndex    :   190 ms -    26296 records/second
Query          :     1 ms -  4230476 records/second
Delete         :   135 ms -    36997 records/second
Drop           :     1 ms -  3558212 records/second
FileLength     :  4036 kb

LiteDB: encrypted - 5000 records
================================
Insert         :  5775 ms -      866 records/second
Bulk           :     0 ms -  9009009 records/second
Update         :  4222 ms -     1184 records/second
CreateIndex    :   171 ms -    29114 records/second
Query          :     1 ms -  3406923 records/second
Delete         :   166 ms -    30088 records/second
Drop           :     0 ms -  7386615 records/second
FileLength     :  4036 kb

LiteDB: exclusive no journal - 5000 records
===========================================
Insert         :  4456 ms -     1122 records/second
Bulk           :     0 ms - 10460251 records/second
Update         :  3386 ms -     1477 records/second
CreateIndex    :   173 ms -    28864 records/second
Query          :     0 ms - 17799929 records/second
Delete         :   124 ms -    40161 records/second
Drop           :     0 ms -  8706251 records/second
FileLength     :  4028 kb

SQLite: default - 5000 records
==============================
Insert         : 46605 ms -      107 records/second
Bulk           :   124 ms -    40141 records/second
Update         : 46784 ms -      107 records/second
CreateIndex    :    16 ms -   305399 records/second
Query          :   491 ms -    10172 records/second
Delete         :    13 ms -   376634 records/second
Drop           :    11 ms -   442521 records/second
FileLength     :  3824 kb

SQLite: encrypted - 5000 records
================================
Insert         : 48780 ms -      103 records/second
Bulk           :   142 ms -    35173 records/second
Update         : 49654 ms -      101 records/second
CreateIndex    :    21 ms -   232913 records/second
Query          :   481 ms -    10380 records/second
Delete         :    12 ms -   394157 records/second
Drop           :    23 ms -   209688 records/second
FileLength     :  3836 kb
```
