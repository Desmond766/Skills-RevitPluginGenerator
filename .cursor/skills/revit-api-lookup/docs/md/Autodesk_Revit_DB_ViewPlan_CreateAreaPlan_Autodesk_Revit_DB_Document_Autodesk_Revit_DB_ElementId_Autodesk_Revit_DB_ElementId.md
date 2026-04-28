---
kind: method
id: M:Autodesk.Revit.DB.ViewPlan.CreateAreaPlan(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 平面视图、平面图
source: html/ee798643-6236-d804-b64b-74b0e597947f.htm
---
# Autodesk.Revit.DB.ViewPlan.CreateAreaPlan Method

**中文**: 平面视图、平面图

Creates a new area plan ViewPlan.

## Syntax (C#)
```csharp
public static ViewPlan CreateAreaPlan(
	Document document,
	ElementId areaSchemeId,
	ElementId levelId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the area plan will be added.
- **areaSchemeId** (`Autodesk.Revit.DB.ElementId`) - The id of the AreaScheme which will be used by the area plan.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the Level to associate with the area plan.

## Returns
The new area plan ViewPlan.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The AreaScheme id is not valid and cannot be used for area plan views.
 -or-
 The ElementId levelId does not correspond to a Level.
 -or-
 Plan view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

