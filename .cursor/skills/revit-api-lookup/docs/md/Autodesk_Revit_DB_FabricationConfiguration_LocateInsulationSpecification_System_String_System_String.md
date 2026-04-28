---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.LocateInsulationSpecification(System.String,System.String)
source: html/a3f54ebb-06df-0683-2541-984ed525476e.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.LocateInsulationSpecification Method

Gets the insulation specification by group and name.

## Syntax (C#)
```csharp
public int LocateInsulationSpecification(
	string group,
	string name
)
```

## Parameters
- **group** (`System.String`) - The insulation specification group.
- **name** (`System.String`) - The insulation specification name.

## Returns
The insulation specification identifier. Returns -1 if not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

