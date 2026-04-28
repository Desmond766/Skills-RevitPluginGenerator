---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.CutExistsBetweenElements(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element,System.Boolean@)
source: html/ebe4f477-2aad-2523-570e-1f3dcff46f78.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.CutExistsBetweenElements Method

Checks that if there is a solid-solid cut between two elements.

## Syntax (C#)
```csharp
public static bool CutExistsBetweenElements(
	Element first,
	Element second,
	out bool firstCutsSecond
)
```

## Parameters
- **first** (`Autodesk.Revit.DB.Element`) - The solid being cut or the cutting solid.
- **second** (`Autodesk.Revit.DB.Element`) - The solid being cut or the cutting solid.
- **firstCutsSecond** (`System.Boolean %`) - If the return value of this function is true, this indicates which element is the cutting element from the pair.
 True if the first solid cuts the second one, false if the second solid cuts the first one.

## Returns
True if there is a solid-solid cut between the input elements, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

