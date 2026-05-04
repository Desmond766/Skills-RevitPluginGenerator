---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.GetWorksharingTooltipInfo(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/1e54c25f-7d7a-7484-be7b-d741084418a9.htm
---
# Autodesk.Revit.DB.WorksharingUtils.GetWorksharingTooltipInfo Method

Gets worksharing information about an element to display in an in-canvas tooltip.

## Syntax (C#)
```csharp
public static WorksharingTooltipInfo GetWorksharingTooltipInfo(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the element
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element in question

## Returns
Worksharing information about the specified element.

## Remarks
If there is no element corresponding to the given id,
 then all the strings returned in WorksharingTooltipInfo are empty. The return value may not be dependable in the middle of a transaction.
 See the remarks on WorksharingUtils for more details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

