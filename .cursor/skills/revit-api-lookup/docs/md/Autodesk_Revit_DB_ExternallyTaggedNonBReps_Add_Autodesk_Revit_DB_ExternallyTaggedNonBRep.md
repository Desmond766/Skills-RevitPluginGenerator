---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedNonBReps.Add(Autodesk.Revit.DB.ExternallyTaggedNonBRep)
source: html/02f20ac4-7352-9410-de3a-36b18af1dd3d.htm
---
# Autodesk.Revit.DB.ExternallyTaggedNonBReps.Add Method

Adds a copy of the input ExternallyTaggedNonBRep to this collection.

## Syntax (C#)
```csharp
public void Add(
	ExternallyTaggedNonBRep geometry
)
```

## Parameters
- **geometry** (`Autodesk.Revit.DB.ExternallyTaggedNonBRep`) - The ExternallyTaggedNonBRep to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ExternalGeometryId of geometry already exists in this collection.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

