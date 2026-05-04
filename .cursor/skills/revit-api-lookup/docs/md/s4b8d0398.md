---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.GetWorkset(Autodesk.Revit.DB.WorksetId)
source: html/229ca8bb-5356-2d95-1e4b-5d3557092647.htm
---
# Autodesk.Revit.DB.WorksetTable.GetWorkset Method

Returns the workset from a input WorksetId.

## Syntax (C#)
```csharp
public Workset GetWorkset(
	WorksetId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.WorksetId`) - Id of a workset.

## Returns
The returned workset. Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no workset in this table with this Id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

