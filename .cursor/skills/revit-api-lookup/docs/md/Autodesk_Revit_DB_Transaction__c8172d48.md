---
kind: type
id: T:Autodesk.Revit.DB.Transaction
zh: 事务
source: html/308ebf8d-d96d-4643-cd1d-34fffcea53fd.htm
---
# Autodesk.Revit.DB.Transaction

**中文**: 事务

Transactions are context-like objects that guard any changes made to a Revit model

## Syntax (C#)
```csharp
public class Transaction : IDisposable
```

## Remarks
Any change to a document can only be made while there is an active transaction
 open for that document. Changes do not become part of the document until the
 active transaction is committed . Consequently, all
 changes made in a transaction can be rolled back 
 either explicitly or implicitly by the transaction's destructor. A document can have only one transaction open at any given time. Transactions cannot be started when the document is in read-only mode,
 either permanently or temporarily. See the Document class methods IsReadOnly
 and IsModifiable for more details. Transactions in linked documents are not permitted,
 for linked documents are not allowed to be modified. If a transaction was started and not finished yet by the time the Transaction object
 is about to be disposed, the default destructor will roll it back automatically, thus all
 changes made to the document while this transaction was open will be discarded.
 It is not recommended to rely on this default behavior though. Instead,
 it is advised to always call either Commit 
 or RollBack explicitly before the transaction
 object gets disposed.
 Please note that unless invoked explicitly the actual destruction of an object
 in managed code might not happen until the object is collected by the garbage collector.

