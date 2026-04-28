---
kind: method
id: M:Autodesk.Revit.DB.Element.GetExternalFileReference
zh: 构件、图元、元素
source: html/e784fb6e-94f4-09bd-1f9c-17e6968e18a5.htm
---
# Autodesk.Revit.DB.Element.GetExternalFileReference Method

**中文**: 构件、图元、元素

Gets information pertaining to the external file referenced
 by the element.

## Syntax (C#)
```csharp
public ExternalFileReference GetExternalFileReference()
```

## Returns
An object containing path and type information for the external
 file referenced by the element.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Element does not represent an external file.

