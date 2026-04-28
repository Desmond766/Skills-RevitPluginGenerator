---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFascia(Autodesk.Revit.DB.Architecture.FasciaType,Autodesk.Revit.DB.Reference)
zh: 文档、文件
source: html/b718bf71-309b-f512-fc21-e08012cec091.htm
---
# Autodesk.Revit.Creation.Document.NewFascia Method

**中文**: 文档、文件

Creates a fascia along a reference.

## Syntax (C#)
```csharp
public Fascia NewFascia(
	FasciaType FasciaType,
	Reference reference
)
```

## Parameters
- **FasciaType** (`Autodesk.Revit.DB.Architecture.FasciaType`) - The type of the fascia to create
- **reference** (`Autodesk.Revit.DB.Reference`) - A planar line or arc that represents the place where you
want to place the fascia.

## Returns
If successful a new fascia object within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the fascia type does not exist in the given document.

