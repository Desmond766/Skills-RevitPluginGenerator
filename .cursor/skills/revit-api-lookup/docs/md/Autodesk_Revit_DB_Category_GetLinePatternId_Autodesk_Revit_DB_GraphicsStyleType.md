---
kind: method
id: M:Autodesk.Revit.DB.Category.GetLinePatternId(Autodesk.Revit.DB.GraphicsStyleType)
source: html/fb42b3c0-86d2-ae03-a5c0-7d499f78e67d.htm
---
# Autodesk.Revit.DB.Category.GetLinePatternId Method

Gets the line pattern id associated with this category for the given graphics style type.

## Syntax (C#)
```csharp
public ElementId GetLinePatternId(
	GraphicsStyleType graphicsStyleType
)
```

## Parameters
- **graphicsStyleType** (`Autodesk.Revit.DB.GraphicsStyleType`) - The type of graphics style.

## Returns
Returns the line pattern id associated with this category for the given graphics style type.

## Remarks
The line pattern id will be one of the following: A negative value (representing a built-in line pattern) The id of a LinePatternElement InvalidElementId, indicating that this category does not have a stored line pattern id for this graphics style type.

