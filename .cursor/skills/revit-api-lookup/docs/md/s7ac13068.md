---
kind: method
id: M:Autodesk.Revit.DB.Subelement.GetBoundingBox(Autodesk.Revit.DB.View)
source: html/32e76eb1-e305-ead5-0b3b-9eb15891c957.htm
---
# Autodesk.Revit.DB.Subelement.GetBoundingBox Method

Retrieves a box that circumscribes all geometry of the subelement.

## Syntax (C#)
```csharp
public BoundingBoxXYZ GetBoundingBox(
	View dbView
)
```

## Parameters
- **dbView** (`Autodesk.Revit.DB.View`) - The view for view-specific geometry or Nothing nullptr a null reference ( Nothing in Visual Basic) for model geometry.

## Returns
The bounding box.

## Remarks
Pass in a view to query view-specific (e.g., cut) geometry or Nothing nullptr a null reference ( Nothing in Visual Basic) for model
 geometry. If the view box is not known or cannot be calculated, this will return the model box;
 if the model box is not known,
 this will return Nothing nullptr a null reference ( Nothing in Visual Basic) . The box will always be aligned to the default axes of the
 model coordinate system (thus no rotation should be applied to the return value).
 Also note that this bounding box volume
 may enclose geometry that is not obvious. For example, the "flip controls" that
 could be part of a family will be included in the computation of the bounding box even
 though they are not always visible in the family instance of the family.

