---
kind: method
id: M:Autodesk.Revit.DB.UpdaterData.IsChangeTriggered(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ChangeType)
source: html/c5dcda11-ce70-52d3-f415-60dc4c2d88a2.htm
---
# Autodesk.Revit.DB.UpdaterData.IsChangeTriggered Method

Allows updater to check if specific change has happened to an element.
 Compares input type to the types that caused Updater::execute() to be triggered.
 If input type was not registered as a trigger for the associated Updater, this
 method will always return false for that ChangeType.
 For example, if the only trigger registered for UpdaterX is ChangeTypeAny for Element A,
 then passing in ChangeTypeGeometry will return false even if the geometry of A changed because
 the registered trigger was ChangeTypeAny. However, passing in ChangeTypeAny will return true.

## Syntax (C#)
```csharp
public bool IsChangeTriggered(
	ElementId id,
	ChangeType type
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - Id of element to check
- **type** (`Autodesk.Revit.DB.ChangeType`) - ChangeType to check

## Returns
True if ChangeType happened to specified element

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

