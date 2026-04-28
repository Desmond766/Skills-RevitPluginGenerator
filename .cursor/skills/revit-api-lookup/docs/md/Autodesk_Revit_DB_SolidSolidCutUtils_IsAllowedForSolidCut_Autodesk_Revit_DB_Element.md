---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.IsAllowedForSolidCut(Autodesk.Revit.DB.Element)
source: html/1fe7758b-d702-2dbc-f3a7-33b1be9b26de.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.IsAllowedForSolidCut Method

Validates that the element is eligible for a solid-solid cut.

## Syntax (C#)
```csharp
public static bool IsAllowedForSolidCut(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The solid to be cut or the cutting solid.

## Returns
True if the input element can participate in a solid-solid cut. False otherwise.

## Remarks
The element must be solid and must be a GenericForm, GeomCombination, or a FamilyInstance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

