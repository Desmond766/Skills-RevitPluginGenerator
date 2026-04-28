---
kind: method
id: M:Autodesk.Revit.DB.Element.GetMaterialVolume(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/99b50d87-bfa6-ca67-e205-47b22cad6587.htm
---
# Autodesk.Revit.DB.Element.GetMaterialVolume Method

**中文**: 构件、图元、元素

Gets the volume of the material with the given id.

## Syntax (C#)
```csharp
public double GetMaterialVolume(
	ElementId materialId
)
```

## Parameters
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material id returned from GetMaterialIds(Boolean) .

## Returns
The volume of the material for this element. Returns 0.0 if the material is not a part of this element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - materialId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

