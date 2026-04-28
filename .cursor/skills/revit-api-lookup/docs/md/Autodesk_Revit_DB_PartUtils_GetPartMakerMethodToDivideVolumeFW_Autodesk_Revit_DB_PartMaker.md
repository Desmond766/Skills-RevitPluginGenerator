---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.GetPartMakerMethodToDivideVolumeFW(Autodesk.Revit.DB.PartMaker)
source: html/3af27a3a-64c0-517f-f37d-601fae0e9fe1.htm
---
# Autodesk.Revit.DB.PartUtils.GetPartMakerMethodToDivideVolumeFW Method

Obtains the object allowing access to the divided volume
 properties of the PartMaker.

## Syntax (C#)
```csharp
public static PartMakerMethodToDivideVolumes GetPartMakerMethodToDivideVolumeFW(
	PartMaker partMaker
)
```

## Parameters
- **partMaker** (`Autodesk.Revit.DB.PartMaker`) - The PartMaker.

## Returns
The object handle. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the
 PartMaker does not represent divided volumes.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

