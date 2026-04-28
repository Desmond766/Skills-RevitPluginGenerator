---
kind: method
id: M:Autodesk.Revit.DB.ElementIntersectsFilter.IsCategorySupported(Autodesk.Revit.DB.Element)
source: html/a85b752e-895f-1041-279e-bbab04ba6d1c.htm
---
# Autodesk.Revit.DB.ElementIntersectsFilter.IsCategorySupported Method

Identifies if the input element is of a category supported by element intersection filters.

## Syntax (C#)
```csharp
public static bool IsCategorySupported(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element.

## Returns
True if the element category is supported, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

