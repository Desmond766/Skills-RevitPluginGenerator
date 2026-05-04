---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.AddCutBetweenSolids(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/eb10c2f6-4d13-0437-12aa-06be28c1b927.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.AddCutBetweenSolids Method

Adds a solid-solid cut for the two elements.

## Syntax (C#)
```csharp
public static void AddCutBetweenSolids(
	Document document,
	Element solidToBeCut,
	Element cuttingSolid
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements.
- **solidToBeCut** (`Autodesk.Revit.DB.Element`) - The solid to be cut.
- **cuttingSolid** (`Autodesk.Revit.DB.Element`) - The cutting solid.

## Remarks
This utility will split faces of cutting solid by default.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element must be in a project document or in a conceptual model, pattern based curtain panel, or adaptive component family.
 -or-
 The element does not meet the condition that it must be solid and must be a GenericForm, GeomCombination, or a FamilyInstance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to add solid-solid cut for the two elements.

