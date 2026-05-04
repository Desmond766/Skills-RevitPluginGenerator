---
kind: method
id: M:Autodesk.Revit.DB.ProjectPosition.#ctor(System.Double,System.Double,System.Double,System.Double)
source: html/c833984a-b94b-fba9-df13-acedf096d83f.htm
---
# Autodesk.Revit.DB.ProjectPosition.#ctor Method

Construct a new ProjectPosition with the specified
 East/West offset, North/South offset, elevation offset,
 and angle of rotation.

## Syntax (C#)
```csharp
public ProjectPosition(
	double ew,
	double ns,
	double elevation,
	double angle
)
```

## Parameters
- **ew** (`System.Double`) - East/West offset
- **ns** (`System.Double`) - North/South offset
- **elevation** (`System.Double`) - Elevation offset
- **angle** (`System.Double`) - Rotation from true north, in radians

## Remarks
The angle parameter must be in the range of -PI to PI.
 If the parameter value is outside that range, it
 will be shifted by 2*PI until it falls into range.

