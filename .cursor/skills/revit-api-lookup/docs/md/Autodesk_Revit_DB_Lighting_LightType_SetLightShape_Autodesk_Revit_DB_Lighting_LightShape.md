---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightType.SetLightShape(Autodesk.Revit.DB.Lighting.LightShape)
source: html/76754532-8954-48aa-f515-c0d5a4e3ef8b.htm
---
# Autodesk.Revit.DB.Lighting.LightType.SetLightShape Method

Replace the current LightShape object with the given object

## Syntax (C#)
```csharp
public void SetLightShape(
	LightShape lightShape
)
```

## Parameters
- **lightShape** (`Autodesk.Revit.DB.Lighting.LightShape`) - An instance of an object derived from LightShape

## Remarks
The argument object is cloned.
 Light shape is a family element parameter. All other LightType properties and methods except for light distribution are
 family type parameters. Changes to family type parameters may not be committed in the same transaction with changes to
 family element parameters, otherwise the modifications to the family type may be lost. Always use a separate transaction
 for changes to the shape and distribution of a light.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The LightShape is the argument that is being validated
 The LightShape is not valid because it of a different derived type than the current LightShape derived type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

