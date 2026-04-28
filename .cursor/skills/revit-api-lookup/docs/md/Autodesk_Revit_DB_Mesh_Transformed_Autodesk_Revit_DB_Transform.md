---
kind: property
id: P:Autodesk.Revit.DB.Mesh.Transformed(Autodesk.Revit.DB.Transform)
source: html/00e8a597-b351-cc16-e236-87095e84d6f6.htm
---
# Autodesk.Revit.DB.Mesh.Transformed Property

Transforms this mesh and returns the result.

## Syntax (C#)
```csharp
public Mesh this[
	Transform transform
] { get; }
```

## Parameters
- **transform** (`Autodesk.Revit.DB.Transform`) - The transformation used to transform the profile.

## Returns
The transformed mesh.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the handle of the specified transformation is Nothing nullptr a null reference ( Nothing in Visual Basic) .

