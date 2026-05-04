---
kind: method
id: M:Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData(Autodesk.Revit.DB.Face,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.FamilySymbol)
source: html/0ed53569-0802-5c68-0079-5f77810d9866.htm
---
# Autodesk.Revit.Creation.Application.NewFamilyInstanceCreationData Method

Creates an object which wraps the arguments of NewFamilyInstance() for batch creation.

## Syntax (C#)
```csharp
public FamilyInstanceCreationData NewFamilyInstanceCreationData(
	Face face,
	Line position,
	FamilySymbol symbol
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - A face of a geometry object.
- **position** (`Autodesk.Revit.DB.Line`) - A line on the face defining where the symbol is to be placed.
- **symbol** (`Autodesk.Revit.DB.FamilySymbol`) - A FamilySymbol object that represents the type of the instance that is to be inserted.

