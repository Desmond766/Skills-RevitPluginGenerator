---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.SetDisplacedElementIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/e1071a6a-2856-6672-4e7d-8a60bb6fdbd7.htm
---
# Autodesk.Revit.DB.DisplacementElement.SetDisplacedElementIds Method

Sets the ids of the elements affected by this DisplacementElement.

## Syntax (C#)
```csharp
public void SetDisplacedElementIds(
	ICollection<ElementId> displacedElemIds
)
```

## Parameters
- **displacedElemIds** (`System.Collections.Generic.ICollection < ElementId >`) - Set of ids of elements to be displaced by this DisplacementElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - For each individual element in the set displacedElemIds, isAllowedAsDisplacedElement must return true, and the
 elements must not already be displaced in the specified view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

