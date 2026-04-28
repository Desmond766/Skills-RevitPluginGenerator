---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.GetWorkset(System.Guid)
source: html/55244a65-68b3-0c65-1282-f3c338f052ed.htm
---
# Autodesk.Revit.DB.WorksetTable.GetWorkset Method

Returns the workset from a input Guid.

## Syntax (C#)
```csharp
public Workset GetWorkset(
	Guid guid
)
```

## Parameters
- **guid** (`System.Guid`) - Guid of the workset.

## Returns
The returned workset. Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no workset in this table with this Id.

