---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.GetModelUpdatesStatus(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/346a8cda-0222-557c-8de7-deea05418868.htm
---
# Autodesk.Revit.DB.WorksharingUtils.GetModelUpdatesStatus Method

Gets the status of a single element in the central model.

## Syntax (C#)
```csharp
public static ModelUpdatesStatus GetModelUpdatesStatus(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the element.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element.

## Returns
The status of the element in the local session versus the central model.

## Remarks
This method returns a locally cached value which may not be up to date with the current state
 of the element in the central. Because of this, the return value is suitable for reporting to an
 interactive user (e.g. via a mechanism similar to Worksharing display mode), but cannot be considered
 a reliable indication of whether the element can be immediately edited by the application. Also, the return value
 may not be dependable in the middle of a local transaction. See the remarks
 on WorksharingUtils for more details. For performance reasons, the model is not validated to be workshared,
 and the element id is also not validated; the element will not be expanded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

