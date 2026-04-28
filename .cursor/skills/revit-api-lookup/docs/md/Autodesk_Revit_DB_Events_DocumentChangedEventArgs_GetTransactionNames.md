---
kind: method
id: M:Autodesk.Revit.DB.Events.DocumentChangedEventArgs.GetTransactionNames
source: html/bc13391a-66bd-1530-3d08-f1b48a460416.htm
---
# Autodesk.Revit.DB.Events.DocumentChangedEventArgs.GetTransactionNames Method

Returns names of the transactions associated with this event

## Syntax (C#)
```csharp
public IList<string> GetTransactionNames()
```

## Returns
The names of the transactions associated with this event

## Remarks
Typically, there will be only one name in the array, because document changes mostly involve just one transaction

