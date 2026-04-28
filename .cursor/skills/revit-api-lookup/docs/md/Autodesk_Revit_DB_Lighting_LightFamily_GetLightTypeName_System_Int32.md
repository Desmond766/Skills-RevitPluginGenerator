---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightFamily.GetLightTypeName(System.Int32)
source: html/a21d46ba-4754-ee32-04af-74df95f9fb46.htm
---
# Autodesk.Revit.DB.Lighting.LightFamily.GetLightTypeName Method

Return the name for the light type at the given index

## Syntax (C#)
```csharp
public string GetLightTypeName(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the light type

## Returns
The name of the light type at the given index

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index is the argument that is being validated
 The index is not valid because it does not correspond to a valid light type

