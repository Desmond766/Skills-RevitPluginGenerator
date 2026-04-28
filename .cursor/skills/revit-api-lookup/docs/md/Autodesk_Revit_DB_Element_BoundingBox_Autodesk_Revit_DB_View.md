---
kind: property
id: P:Autodesk.Revit.DB.Element.BoundingBox(Autodesk.Revit.DB.View)
zh: 构件、图元、元素
source: html/def2f9f2-b23a-bcea-43a3-e6de41b014c8.htm
---
# Autodesk.Revit.DB.Element.BoundingBox Property

**中文**: 构件、图元、元素

Retrieves a box that circumscribes all geometry of the element.

## Syntax (C#)
```csharp
public BoundingBoxXYZ this[
	View A_0
] { get; }
```

## Parameters
- **A_0** (`Autodesk.Revit.DB.View`)

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

