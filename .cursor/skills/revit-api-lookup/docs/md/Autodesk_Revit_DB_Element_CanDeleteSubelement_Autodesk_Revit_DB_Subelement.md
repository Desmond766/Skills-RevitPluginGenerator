---
kind: method
id: M:Autodesk.Revit.DB.Element.CanDeleteSubelement(Autodesk.Revit.DB.Subelement)
zh: 构件、图元、元素
source: html/c9795398-2d2c-db8e-a4e7-ca99d69fcc1d.htm
---
# Autodesk.Revit.DB.Element.CanDeleteSubelement Method

**中文**: 构件、图元、元素

Checks if given subelement can be removed from the element.

## Syntax (C#)
```csharp
public bool CanDeleteSubelement(
	Subelement subelem
)
```

## Parameters
- **subelem** (`Autodesk.Revit.DB.Subelement`) - Subelement to check.

## Returns
True if subelement can be removed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

