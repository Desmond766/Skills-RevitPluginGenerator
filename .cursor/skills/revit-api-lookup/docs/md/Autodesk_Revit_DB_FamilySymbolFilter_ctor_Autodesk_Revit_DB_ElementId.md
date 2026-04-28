---
kind: method
id: M:Autodesk.Revit.DB.FamilySymbolFilter.#ctor(Autodesk.Revit.DB.ElementId)
source: html/67c230d2-e446-fed9-f648-69cf5dd395f8.htm
---
# Autodesk.Revit.DB.FamilySymbolFilter.#ctor Method

Constructs a new instance of a filter to find all family symbols of the given family.

## Syntax (C#)
```csharp
public FamilySymbolFilter(
	ElementId familyId
)
```

## Parameters
- **familyId** (`Autodesk.Revit.DB.ElementId`) - The family id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The familyId is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

