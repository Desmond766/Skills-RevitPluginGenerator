---
kind: type
id: T:Autodesk.Revit.DB.TransactionGroup
source: html/f1113d30-4c36-7844-1537-aad7f095cea0.htm
---
# Autodesk.Revit.DB.TransactionGroup

Transaction groups aggregate a number of transactions.

## Syntax (C#)
```csharp
public class TransactionGroup : IDisposable
```

## Remarks
A transaction group controls whether transactions committed inside the group should
 stay committed or should be all discarded. If the group is committed, all the transactions
 remain committed, but if the transaction group is rolled back instead, all the inner,
 already committed transactions will be undone (and removed). There are two ways of committing a group - Commit and Assimilate. By committing,
 all transactions committed inside a group stay as they are, while by assimilating,
 all inner transactions will be merged into a single transaction. A transaction group can only be started when no transaction is active,
 and must be closed only after the last transaction started inside the group is finished,
 i.e. after it was either committed or rolled back. Transaction groups may be nested inside each other with the restriction
 that every nested transaction group is entirely contained (opened and closed)
 in the parent transaction group. If a transaction group was started and not finished yet by the time the TransactionGroup object
 is about to be, the default destructor will roll it back automatically, thus all
 changes made to the document while this transaction group was open will be discarded.
 It is not recommended to rely on this default behavior though. Instead, it is advised
 to always call either Commit () () () , RollBack () () () ,
 or Assimilate () () () explicitly before the group object gets destroyed.
 Please note that unless invoked explicitly the actual destruction of an object
 in managed code might not happen until the object is collected by the garbage collector.

