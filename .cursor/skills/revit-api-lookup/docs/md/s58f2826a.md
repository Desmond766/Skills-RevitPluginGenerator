---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.LocateSpecification(System.String,System.String)
source: html/39c265d3-b467-4277-d3ad-78e1d1c31fe4.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.LocateSpecification Method

Gets the specification identifier by group and name.

## Syntax (C#)
```csharp
public int LocateSpecification(
	string group,
	string name
)
```

## Parameters
- **group** (`System.String`) - The specification group.
- **name** (`System.String`) - The specification name.

## Returns
The specification identifier. Returns -1 if not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

