---
kind: method
id: M:Autodesk.Revit.DB.Category.SetLinePatternId(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.GraphicsStyleType)
source: html/bc84b2b6-fdaf-5949-244c-8a75cc688ec3.htm
---
# Autodesk.Revit.DB.Category.SetLinePatternId Method

Sets the line pattern id associated with this category for the given graphics style type.

## Syntax (C#)
```csharp
public void SetLinePatternId(
	ElementId linePatternId,
	GraphicsStyleType graphicsStyleType
)
```

## Parameters
- **linePatternId** (`Autodesk.Revit.DB.ElementId`) - The line pattern id for the graphics style.
- **graphicsStyleType** (`Autodesk.Revit.DB.GraphicsStyleType`) - The type of graphics style.

## Remarks
The line pattern id will be one of the following: A negative value (representing a built-in line pattern); this value can only be obtained via GetLinePatternId The id of a LinePatternElement

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument "linePatternId" is an illegal id.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this category does not have stored line pattern id for this graphics style type.

