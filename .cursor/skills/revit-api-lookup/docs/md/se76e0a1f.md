---
kind: method
id: M:Autodesk.Revit.DB.DirectShape.SetTypeId(Autodesk.Revit.DB.ElementId)
source: html/077e58a6-977e-be35-6e20-dd07daa1fdd0.htm
---
# Autodesk.Revit.DB.DirectShape.SetTypeId Method

Sets the DirectShapeType for the DirectShape element.

## Syntax (C#)
```csharp
public void SetTypeId(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The ID of the type corresponding to this DirectShape element. May only be set once.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - typeId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

