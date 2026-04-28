---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.IsElementFromAppropriateContext(Autodesk.Revit.DB.Element)
source: html/d99d08e0-d818-ce6a-2a21-a083664affa8.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.IsElementFromAppropriateContext Method

Validates that the element is from an appropriate document.

## Syntax (C#)
```csharp
public static bool IsElementFromAppropriateContext(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The solid to be cut or the cutting solid.

## Returns
True if the element is from an appropriate document for solid-solid cuts, false otherwise.

## Remarks
Currently an element from either a project document, conceptual model, pattern based curtain panel, or adaptive component family
 may participate in solid-solid cuts.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

