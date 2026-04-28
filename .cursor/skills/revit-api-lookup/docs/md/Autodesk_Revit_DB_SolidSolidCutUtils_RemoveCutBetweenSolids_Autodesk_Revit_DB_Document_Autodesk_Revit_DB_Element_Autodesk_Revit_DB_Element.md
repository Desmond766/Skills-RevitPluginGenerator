---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.RemoveCutBetweenSolids(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/dc614d7b-5a07-4d65-dd58-ed78c9d3cb2a.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.RemoveCutBetweenSolids Method

Removes the solid-solid cut between the two elements if it exists.

## Syntax (C#)
```csharp
public static void RemoveCutBetweenSolids(
	Document document,
	Element first,
	Element second
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements
- **first** (`Autodesk.Revit.DB.Element`) - The solid being cut or the cutting solid.
- **second** (`Autodesk.Revit.DB.Element`) - The solid being cut or the cutting solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

