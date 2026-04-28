---
kind: method
id: M:Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.CanBeDivisionProfile(Autodesk.Revit.DB.ElementId)
source: html/e4f5dbf4-9560-ffb6-8f57-61b604c347a4.htm
---
# Autodesk.Revit.DB.PartMakerMethodToDivideVolumes.CanBeDivisionProfile Method

Checks whether a family defines a profile which can be used by this method.

## Syntax (C#)
```csharp
public bool CanBeDivisionProfile(
	ElementId familyId
)
```

## Parameters
- **familyId** (`Autodesk.Revit.DB.ElementId`) - Element id of the family.

## Returns
True if the family defines a profile which can be used by a part maker,
 false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

