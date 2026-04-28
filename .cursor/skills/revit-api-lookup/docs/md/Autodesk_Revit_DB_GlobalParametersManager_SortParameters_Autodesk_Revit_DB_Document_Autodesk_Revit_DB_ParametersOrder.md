---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.SortParameters(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ParametersOrder)
source: html/fe58ca0b-7002-3162-0f7f-ceaa85baea99.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.SortParameters Method

Sorts global parameters in the desired order.

## Syntax (C#)
```csharp
public static void SortParameters(
	Document document,
	ParametersOrder order
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document containing the global parameters to be sorted
- **order** (`Autodesk.Revit.DB.ParametersOrder`) - Desired sorting order

## Remarks
All global parameters are sorted, but only within the range
 of their respective parameter group. This operation has no effect on the global parameters themselves.
 The sorted order is only visible in the standard Global Parameters
 dialog. However, the order of parameters is serialized in the document,
 thus available on the DB level as well.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Global parameters are not supported in the given document.
 A possible cause is that it is not a project document,
 for global parameters are not supported in Revit families.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

