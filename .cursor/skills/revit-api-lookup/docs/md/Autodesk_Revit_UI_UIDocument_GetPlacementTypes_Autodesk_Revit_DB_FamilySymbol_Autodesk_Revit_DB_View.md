---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.GetPlacementTypes(Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.DB.View)
source: html/3069f4c9-3caa-7a3f-f739-375482380805.htm
---
# Autodesk.Revit.UI.UIDocument.GetPlacementTypes Method

Get a collection of valid placement types for input family symbol.

## Syntax (C#)
```csharp
public IList<FaceBasedPlacementType> GetPlacementTypes(
	FamilySymbol familySymbol,
	View pDBView
)
```

## Parameters
- **familySymbol** (`Autodesk.Revit.DB.FamilySymbol`) - The family symbol.
- **pDBView** (`Autodesk.Revit.DB.View`) - The view in which the family instance will be placed in.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

