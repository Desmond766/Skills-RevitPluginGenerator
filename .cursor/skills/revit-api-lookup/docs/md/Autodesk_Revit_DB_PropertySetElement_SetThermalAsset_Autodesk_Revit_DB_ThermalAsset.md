---
kind: method
id: M:Autodesk.Revit.DB.PropertySetElement.SetThermalAsset(Autodesk.Revit.DB.ThermalAsset)
source: html/59b437ed-b9ec-85d9-5b12-e9b7dd7992ab.htm
---
# Autodesk.Revit.DB.PropertySetElement.SetThermalAsset Method

Sets a copy of the given ThermalAsset to be used in the PropertySetElement.

## Syntax (C#)
```csharp
public void SetThermalAsset(
	ThermalAsset thermalAsset
)
```

## Parameters
- **thermalAsset** (`Autodesk.Revit.DB.ThermalAsset`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the name of the asset is empty, contains prohibited characters, or is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

