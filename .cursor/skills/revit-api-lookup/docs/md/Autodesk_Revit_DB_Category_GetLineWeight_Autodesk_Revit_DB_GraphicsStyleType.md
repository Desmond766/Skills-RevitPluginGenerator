---
kind: method
id: M:Autodesk.Revit.DB.Category.GetLineWeight(Autodesk.Revit.DB.GraphicsStyleType)
source: html/5b25c3c6-3f83-95bf-b7c3-c868c431e0fa.htm
---
# Autodesk.Revit.DB.Category.GetLineWeight Method

Retrieves the line weight assigned to the category for the given graphics style type.

## Syntax (C#)
```csharp
public Nullable<int> GetLineWeight(
	GraphicsStyleType graphicsStyleType
)
```

## Parameters
- **graphicsStyleType** (`Autodesk.Revit.DB.GraphicsStyleType`) - The type of graphics style.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"graphicsStyleType"-is out of range.

