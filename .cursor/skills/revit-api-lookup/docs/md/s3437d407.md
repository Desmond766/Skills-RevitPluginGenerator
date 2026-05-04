---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData(Autodesk.Revit.DB.FamilySymbol,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/03b8e2af-4445-39ed-f7b0-da9f3df942ef.htm
---
# Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData Method

Creates an object which wraps the arguments of NewFamilyInstance() for batch creation.

## Syntax (C#)
```csharp
public FamilyInstanceCreationData NewFamilyInstanceCreationData(
	FamilySymbol symbol,
	IList<XYZ> adaptivePoints
)
```

## Parameters
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.
- **adaptivePoints** (`System.Collections.Generic.IList < XYZ >`) - The adaptive point location where the adaptive instance is to be placed.

