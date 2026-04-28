---
kind: method
id: M:Autodesk.Revit.DB.Element.IsPhaseDemolishedValid(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/f97c9af7-fcbe-f617-d7ff-cfd4fb5af37f.htm
---
# Autodesk.Revit.DB.Element.IsPhaseDemolishedValid Method

**中文**: 构件、图元、元素

Returns true if demolishedPhaseId is an allowed value for the property DemolishedPhaseId in this Element.

## Syntax (C#)
```csharp
public bool IsPhaseDemolishedValid(
	ElementId demolishedPhaseId
)
```

## Parameters
- **demolishedPhaseId** (`Autodesk.Revit.DB.ElementId`) - The id of a Phase or invalidElementId.

## Returns
True if demolishedPhaseId is an allowed value for the property DemolishedPhaseId in this Element, false otherwise.

## Remarks
Acts as a validator for setting the property DemolishedPhaseId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

