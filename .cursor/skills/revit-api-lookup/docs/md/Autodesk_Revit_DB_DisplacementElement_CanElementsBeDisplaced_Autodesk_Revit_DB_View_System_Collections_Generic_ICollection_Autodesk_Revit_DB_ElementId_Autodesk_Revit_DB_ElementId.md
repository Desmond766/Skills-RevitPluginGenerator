---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.CanElementsBeDisplaced(Autodesk.Revit.DB.View,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId@)
source: html/bcea307d-e573-de96-0769-642e74efa46b.htm
---
# Autodesk.Revit.DB.DisplacementElement.CanElementsBeDisplaced Method

Indicates if elements can be assigned to a new DisplacementElement.

## Syntax (C#)
```csharp
public static bool CanElementsBeDisplaced(
	View view,
	ICollection<ElementId> elementIds,
	out ElementId commonDisplacedElementId
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The element ids.
- **commonDisplacedElementId** (`Autodesk.Revit.DB.ElementId %`) - If this method returns true, then this is the element id of
 a DisplacementElement which lists all of elemIds among its
 displaced elements.

## Returns
Returns true if the specified element ids can be assigned to a new DisplacementElement.

## Remarks
A necessary condition is that isAllowedAsDisplacedElement
 returns true for each individual element id.
 In addition, if isElementDisplaced must return the same value
 for all the specified element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

