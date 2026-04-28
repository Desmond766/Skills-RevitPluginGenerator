---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.LocateMaterial(System.String,System.String)
source: html/d3466136-f845-f453-9456-9981cd4d4fdd.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.LocateMaterial Method

Gets material by group and name.

## Syntax (C#)
```csharp
public int LocateMaterial(
	string group,
	string name
)
```

## Parameters
- **group** (`System.String`) - The material group.
- **name** (`System.String`) - The group name.

## Returns
The material identifier. Returns -1 if not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

