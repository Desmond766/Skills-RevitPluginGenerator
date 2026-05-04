---
kind: method
id: M:Autodesk.Revit.DB.Transform.CreateReflection(Autodesk.Revit.DB.Plane)
zh: 变换
source: html/7c6c9293-64ca-ef47-3365-803e7f802883.htm
---
# Autodesk.Revit.DB.Transform.CreateReflection Method

**中文**: 变换

Creates a transform that represents a reflection across the given plane.

## Syntax (C#)
```csharp
public static Transform CreateReflection(
	Plane plane
)
```

## Parameters
- **plane** (`Autodesk.Revit.DB.Plane`) - The plane.

## Returns
The new transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

