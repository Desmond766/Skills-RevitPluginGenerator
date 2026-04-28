---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.AddCutBetweenSolids(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element,System.Boolean)
source: html/eb640bff-a6be-d931-afbf-df3bc7a1a869.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.AddCutBetweenSolids Method

Adds a solid-solid cut for the two elements with the option to control splitting of faces of the cutting solid.

## Syntax (C#)
```csharp
public static void AddCutBetweenSolids(
	Document document,
	Element solidToBeCut,
	Element cuttingSolid,
	bool splitFacesOfCuttingSolid
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements.
- **solidToBeCut** (`Autodesk.Revit.DB.Element`) - The solid to be cut.
- **cuttingSolid** (`Autodesk.Revit.DB.Element`) - The cutting solid.
- **splitFacesOfCuttingSolid** (`System.Boolean`) - True to split faces of cutting solid where it intersects the solid to be cut, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element must be in a project document or in a conceptual model, pattern based curtain panel, or adaptive component family.
 -or-
 The element does not meet the condition that it must be solid and must be a GenericForm, GeomCombination, or a FamilyInstance.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to add solid-solid cut for the two elements.

