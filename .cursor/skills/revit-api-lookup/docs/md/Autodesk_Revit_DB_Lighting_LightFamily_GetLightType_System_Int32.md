---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightFamily.GetLightType(System.Int32)
source: html/4418e7fd-50f4-22ed-9655-067e406af4b3.htm
---
# Autodesk.Revit.DB.Lighting.LightFamily.GetLightType Method

Return a LightType object for the light type at the given index

## Syntax (C#)
```csharp
public LightType GetLightType(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the light type

## Returns
A LightType object for the light type at the given index

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index is the argument that is being validated
 The index is not valid because it does not correspond to a valid light type

