---
kind: method
id: M:Autodesk.Revit.DB.Structure.Truss.GetTrussMemberInfo(Autodesk.Revit.DB.ElementId)
zh: 桁架
source: html/885bcdab-10c1-5857-29db-3b95fe43be6d.htm
---
# Autodesk.Revit.DB.Structure.Truss.GetTrussMemberInfo Method

**中文**: 桁架

Query if a given element is a member of a truss, its lock status and its usage, etc.

## Syntax (C#)
```csharp
public TrussMemberInfo GetTrussMemberInfo(
	ElementId elemId
)
```

## Parameters
- **elemId** (`Autodesk.Revit.DB.ElementId`) - The querying element.

## Returns
A struct TrussMemberInfo that contains the querying element's host truss, whether to lock to the truss, usage type, etc.

