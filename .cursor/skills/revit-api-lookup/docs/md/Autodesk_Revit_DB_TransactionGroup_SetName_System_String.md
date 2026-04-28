---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.SetName(System.String)
source: html/6b009b31-5ee4-dc76-2c3e-b3867ffee33c.htm
---
# Autodesk.Revit.DB.TransactionGroup.SetName Method

Sets the transaction group's name.

## Syntax (C#)
```csharp
public void SetName(
	string name
)
```

## Parameters
- **name** (`System.String`) - A name for the transaction group.

## Remarks
Transaction group only needs a name if it is going to be assimilated at the end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

