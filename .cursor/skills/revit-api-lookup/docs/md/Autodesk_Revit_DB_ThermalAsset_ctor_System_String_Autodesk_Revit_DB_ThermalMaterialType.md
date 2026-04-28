---
kind: method
id: M:Autodesk.Revit.DB.ThermalAsset.#ctor(System.String,Autodesk.Revit.DB.ThermalMaterialType)
source: html/5a5e5fb9-d295-1bbd-de8d-c595584c037e.htm
---
# Autodesk.Revit.DB.ThermalAsset.#ctor Method

Constructs an instance of ThermalAsset.

## Syntax (C#)
```csharp
public ThermalAsset(
	string name,
	ThermalMaterialType materialType
)
```

## Parameters
- **name** (`System.String`) - The name of the asset.
- **materialType** (`Autodesk.Revit.DB.ThermalMaterialType`) - The type of thermal material that this asset will describe.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

