---
kind: method
id: M:Autodesk.Revit.DB.Structure.FabricSheet.SetBendProfile(Autodesk.Revit.DB.CurveLoop)
source: html/086c6100-798a-6998-f8e0-fac6d856e6be.htm
---
# Autodesk.Revit.DB.Structure.FabricSheet.SetBendProfile Method

Sets new profile that defines the shape of the Fabric Sheet bending.

## Syntax (C#)
```csharp
public void SetBendProfile(
	CurveLoop bendProfile
)
```

## Parameters
- **bendProfile** (`Autodesk.Revit.DB.CurveLoop`) - A profile that defines the bending shape of the fabric sheet.
 The profile can be provided without fillets (eg. for L shape, only two lines not two lines and one arc), if so,
 then fillets (in example one arc) will be automatically generated basing on the Bend Diameter parameter defined in the Fabric Wire system family.
 If the provided profile has no corners (has a tangent defined at each point except the ends), no fillets will be generated.
 The provided profile defines the center-curve of a wire.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the bend profile contains an overlap or intersecting segments.
 -or-
 Thrown when the bend profile is empty.
 -or-
 Thrown when the bend profile contains an empty loop.
 -or-
 Thrown when the bend profile contains multiple loops.
 -or-
 Thrown when the bend profile contains a closed loop.
 -or-
 Thrown when the bend profile contains two or more arcs that are not separated from one another by a straight segment.
 -or-
 Thrown when the bend profile contains too short segments which prevent the fillets from being added. The fillet radius is taken from Bend Diameter parameter defined in the Fabric Wire system family.
 -or-
 Thrown when the provided profile cannot be used as a bending shape for this fabric sheet.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidObjectException** - The data-setting method is not applicable to fabric sheets that are flat.

