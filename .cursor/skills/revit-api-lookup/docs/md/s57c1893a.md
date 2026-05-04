---
kind: method
id: M:Autodesk.Revit.DB.DisplacementElement.GetDisplacementElementIds(Autodesk.Revit.DB.View)
source: html/a8f8e350-c1c1-c3f7-ff73-660388b40098.htm
---
# Autodesk.Revit.DB.DisplacementElement.GetDisplacementElementIds Method

The element ids of all DisplacementElements owned by the specified view.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetDisplacementElementIds(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.

## Returns
The element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

