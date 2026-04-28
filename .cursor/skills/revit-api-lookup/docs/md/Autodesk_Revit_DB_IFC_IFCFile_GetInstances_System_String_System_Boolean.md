---
kind: method
id: M:Autodesk.Revit.DB.IFC.IFCFile.GetInstances(System.String,System.Boolean)
source: html/a06d31f4-9866-4fce-2a68-314627e6dde5.htm
---
# Autodesk.Revit.DB.IFC.IFCFile.GetInstances Method

Gets IFC instances of one particular type.

## Syntax (C#)
```csharp
public IList<IFCAnyHandle> GetInstances(
	string entityName,
	bool includeSubTypes
)
```

## Parameters
- **entityName** (`System.String`) - The name of the instance type.
- **includeSubTypes** (`System.Boolean`) - True to retrieve instances of sub types.

## Returns
The instance handles.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

