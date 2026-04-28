---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.CanElementsBeDisplaced(Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/c4dc323b-fd9d-816d-ab62-088a9a78c746.htm
---
# Autodesk.Revit.DB.DisplacementElement.CanElementsBeDisplaced Method

Indicates if elements can be assigned to a new DisplacementElement.

## Syntax (C#)
```csharp
public static bool CanElementsBeDisplaced(
	View view,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The element ids.

## Remarks
A necessary condition is that isAllowedAsDisplacedElement
 returns true for each individual element id.
 In addition, if isElementDisplaced must return the same value
 for all the specified element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

