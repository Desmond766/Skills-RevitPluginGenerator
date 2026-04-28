---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.GetInstanceCount(System.String,System.Boolean)
source: html/e3f72078-890f-d2a6-c942-f9a5cb6b5fb5.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.GetInstanceCount Method

Counts IFC instances of one particular type.

## Syntax (C#)
```csharp
public int GetInstanceCount(
	string entityName,
	bool includeSubTypes
)
```

## Parameters
- **entityName** (`System.String`) - The name of the instance type.
- **includeSubTypes** (`System.Boolean`) - True to count instances of sub types.

## Returns
The count.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

