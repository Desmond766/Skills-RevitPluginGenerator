---
kind: method
id: M:Autodesk.Revit.DB.Category.SetLineWeight(System.Int32,Autodesk.Revit.DB.GraphicsStyleType)
source: html/1a43c153-cbaf-f89b-d298-93c6ff7d0ae0.htm
---
# Autodesk.Revit.DB.Category.SetLineWeight Method

Sets the line weight for the given graphics style type.

## Syntax (C#)
```csharp
public void SetLineWeight(
	int lineWeight,
	GraphicsStyleType graphicsStyleType
)
```

## Parameters
- **lineWeight** (`System.Int32`)
- **graphicsStyleType** (`Autodesk.Revit.DB.GraphicsStyleType`) - The type of graphics style.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"lineWeight" or "graphicsStyleType"-is out of range.

