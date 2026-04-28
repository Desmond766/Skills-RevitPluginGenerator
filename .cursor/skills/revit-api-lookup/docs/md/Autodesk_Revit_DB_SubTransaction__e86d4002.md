---
kind: type
id: T:Autodesk.Revit.DB.SubTransaction
source: html/801e5f17-cab0-044d-835c-a39592374f89.htm
---
# Autodesk.Revit.DB.SubTransaction

Sub-transactions are objects that provide control over a subset of changes in a document.

## Syntax (C#)
```csharp
public class SubTransaction : IDisposable
```

## Remarks
A Sub-transaction can only be active as a part of an open transaction.
 Sub-transactions may be nested inside each other, but with the restriction
 that every nested sub-transaction is entirely contained (opened and closed)
 in the parent sub-transaction.
 If a sub-transaction was started and not committed or rolled back by the time
 the SubTransaction object is about to be disposed, the destructor will roll back the
 sub-transaction automatically, thus all changes made to the document during the
 sub-transaction will be discarded. It is not recommended to rely on this default
 behavior though. Instead, it is advised to always call either Commit 
 or RollBack explicitly before the sub-transaction
 object gets disposed.
 Please note that unless invoked explicitly the actual destruction of an object
 in managed code might not happen until the object is collected by the garbage collector.

