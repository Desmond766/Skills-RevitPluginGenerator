---
kind: method
id: M:Autodesk.Revit.DB.ExternallyTaggedNonBReps.CanAddExternallyTaggedNonBRep(Autodesk.Revit.DB.ExternallyTaggedNonBRep)
source: html/47c39c8d-5edc-2b78-1dfb-23af7fe4e6f8.htm
---
# Autodesk.Revit.DB.ExternallyTaggedNonBReps.CanAddExternallyTaggedNonBRep Method

Checks if the input geometry could be added to this collection or not.

## Syntax (C#)
```csharp
public bool CanAddExternallyTaggedNonBRep(
	ExternallyTaggedNonBRep geometry
)
```

## Parameters
- **geometry** (`Autodesk.Revit.DB.ExternallyTaggedNonBRep`)

## Returns
True if we can add the input geometry to this collection, false otherwise.

## Remarks
Duplicate ExternalGeometryIds are prohibited.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

