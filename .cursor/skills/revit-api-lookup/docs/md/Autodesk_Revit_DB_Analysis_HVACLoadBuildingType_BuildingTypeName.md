---
kind: property
id: P:Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.BuildingTypeName
source: html/57a7fea5-4711-0cb8-8e9d-24b137387276.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.BuildingTypeName Property

The building type name.

## Syntax (C#)
```csharp
public string BuildingTypeName { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: name is an empty string or contains only whitespace.
 -or-
 When setting this property: name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 When setting this property: The given value for name is already in use as a building type name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

