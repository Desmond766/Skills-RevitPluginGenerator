---
kind: method
id: M:Autodesk.Revit.DB.Element.GetMaterialArea(Autodesk.Revit.DB.ElementId,System.Boolean)
zh: 构件、图元、元素
source: html/02417c40-bcc4-f04c-9897-cf47737e8739.htm
---
# Autodesk.Revit.DB.Element.GetMaterialArea Method

**中文**: 构件、图元、元素

Gets the area of the material with the given id.

## Syntax (C#)
```csharp
public double GetMaterialArea(
	ElementId materialId,
	bool usePaintMaterial
)
```

## Parameters
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material id returned from GetMaterialIds(Boolean) .
- **usePaintMaterial** (`System.Boolean`) - If true, this material id was returned as a paint material from GetMaterialIds(Boolean) and the area returned should be calculated from paint applied to the element.
 If false, this material id was returned as a non-paint element material from GetMaterialIds(Boolean) and the area is calculated from the element geometry and layers.

## Returns
The area of the material for this element. Returns 0.0 if the material id is not a part of this element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - materialId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Element element does not support paint material assignment.

