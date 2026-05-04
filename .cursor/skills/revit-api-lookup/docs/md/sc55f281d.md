---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightType.SetLightDistribution(Autodesk.Revit.DB.Lighting.LightDistribution)
source: html/b5a83b94-c75b-f7d7-bd38-310c6e89bc3b.htm
---
# Autodesk.Revit.DB.Lighting.LightType.SetLightDistribution Method

Replace the current LightDistribution object with the given object

## Syntax (C#)
```csharp
public void SetLightDistribution(
	LightDistribution lightDistribution
)
```

## Parameters
- **lightDistribution** (`Autodesk.Revit.DB.Lighting.LightDistribution`) - An instance of an object derived from LightDistribution

## Remarks
The argument object is cloned
 Light distribution is a family element parameter. All other LightType properties and methods except for light shape are
 family type parameters. Changes to family type parameters may not be committed in the same transaction with changes to
 family element parameters, otherwise the modifications to the family type may be lost. Always use a separate transaction
 for changes to the shape and distribution of a light.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The LightDistribution is the argument that is being validated
 The LightDistribution is not valid because it of a different derived type than the current LightDistribution derived type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

