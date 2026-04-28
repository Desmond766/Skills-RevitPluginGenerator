---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.CanBeDivisionProfile(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Document)
source: html/eade50e5-f894-8d94-79f4-15781b06e69f.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.CanBeDivisionProfile Method

Checks whether a family defines a profile which can be used by this method.

## Syntax (C#)
```csharp
public static bool CanBeDivisionProfile(
	ElementId familyId,
	Document familyDocument
)
```

## Parameters
- **familyId** (`Autodesk.Revit.DB.ElementId`) - Element id of the family.
- **familyDocument** (`Autodesk.Revit.DB.Document`) - The document containing the family to be tested.

## Returns
True if the family defines a profile which can be used by a part maker,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

