---
kind: method
id: M:Autodesk.Revit.DB.PropertySetElement.SetStructuralAsset(Autodesk.Revit.DB.StructuralAsset)
source: html/1979648f-faa4-1cb9-f108-b9dd805cc0b5.htm
---
# Autodesk.Revit.DB.PropertySetElement.SetStructuralAsset Method

Sets a copy of the given StucturalAsset to be used in the PropertySetElement.

## Syntax (C#)
```csharp
public void SetStructuralAsset(
	StructuralAsset structuralAsset
)
```

## Parameters
- **structuralAsset** (`Autodesk.Revit.DB.StructuralAsset`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the name of the asset is empty, contains prohibited characters, or is not unique
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

