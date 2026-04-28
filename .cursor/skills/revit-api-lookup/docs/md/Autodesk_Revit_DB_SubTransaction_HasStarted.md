---
kind: method
id: M:Autodesk.Revit.DB.SubTransaction.HasStarted
source: html/f901f404-1de2-912e-747d-375b0e782bef.htm
---
# Autodesk.Revit.DB.SubTransaction.HasStarted Method

Determines whether the sub-transaction has been started yet.

## Syntax (C#)
```csharp
public bool HasStarted()
```

## Returns
True if the sub-transaction has already started, False otherwise.

## Remarks
A sub-transaction is considered being started after the Start 
 method was called and until the sub-transaction is either committed or rolled back.

